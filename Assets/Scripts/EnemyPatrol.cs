using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 1f;
    public float minX;
    public float maxX;
    public float waitingTime = 2f;

    private GameObject _target;

    // Start is called before the first frame update
    void Start()
    {
        UpdateTarget();
        StartCoroutine("PatrolToTarget");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateTarget()
    {
        if(_target == null)
        {
            _target = new GameObject("Target");
            _target.transform.position = new Vector2(minX, transform.position.y);
            transform.localScale = new Vector3(-1, 1, 1);
            return; //Para que la primera vez no empiece a caminar
        }

        if(_target.transform.position.x == minX)
        {
            _target.transform.position = new Vector2(maxX, transform.position.y);
            transform.localScale = new Vector3(1, 1, 1);
        } else if (_target.transform.position.x == maxX)
        {
            _target.transform.position = new Vector2(minX, transform.position.y);
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private IEnumerator PatrolToTarget()
    {
        //Comprueba la distancia entre mi posición y el target
        while(Vector2.Distance(transform.position, _target.transform.position) > 0.05f) {
            // Nos movemos hacia el target
            Vector2 direction = _target.transform.position - transform.position;
            float xDirection = direction.x;

            transform.Translate(direction.normalized * speed * Time.deltaTime);

            yield return null; //Important (Sigue llamándote hasta que no se cumpla el while)
        }

        transform.position = new Vector2(_target.transform.position.x, transform.position.y); //Target reached (Tomamos la posición del target)

        yield return new WaitForSeconds(waitingTime); //Important

        UpdateTarget(); // End waiting
        StartCoroutine("PatrolToTarget");
    }
}
