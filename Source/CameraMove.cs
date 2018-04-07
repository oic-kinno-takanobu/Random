using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    [SerializeField]
    Transform target;

    [SerializeField]
    float step;

    [SerializeField]
    float roteSpeed = 2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Move();
        Rote();
	}

    private void Rote()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, -roteSpeed, 0);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, roteSpeed, 0);
        }


    }

    private void Move()
    {
        Vector3 distans = target.position - transform.position;
        transform.position += distans / step;
    }
}
