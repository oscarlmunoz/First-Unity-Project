using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 2f;
    public Vector2 direcction;

    public float livingTime = 3f;
    private Color _initialColor = Color.white;
    public Color finalColor;

    private SpriteRenderer _renderer;
    private float _startingTime;


    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _startingTime = Time.time;

        Destroy(this.gameObject, livingTime);
    }

    // Update is called once per frame
    void Update()
    {
        // //transform.position = new Vector2(transform.position.x + movement.x, transform.position.y + movement.y);

        Vector2 movement = direcction.normalized * speed * Time.deltaTime;
        transform.Translate(movement);

        float _timeSinceStarted = Time.time - _startingTime;
        float _percentageCompleted = _timeSinceStarted / livingTime;

        _renderer.color = Color.Lerp(_initialColor, finalColor, _percentageCompleted);

    }


}
