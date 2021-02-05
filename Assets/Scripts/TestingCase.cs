using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingCase : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 1. Mouse (0. Left, 1. Rigth, 2, Center)
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("button pressed");
        }
        if (Input.GetMouseButton(0))
        {
            Debug.Log("button is pressed");
        }
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("button released");
        }

        // 2. Keyboard button events
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Player jumping");
        }
            // Edit > Project Settings > Input
            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log("Player jumping");
            }

        // 3. Getting Axis for movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if(horizontal != 0f)
        {
            Debug.Log("Horizontal = " + horizontal);
        }
        if (vertical != 0f)
        {
            Debug.Log("vertical = " + vertical);
        }

    }
}