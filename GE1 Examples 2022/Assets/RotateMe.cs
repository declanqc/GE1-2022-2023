using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMe : MonoBehaviour
{
    [Range(0, 360)]
    public float speed = 90;
    void Start()
    {
        
    }

    void Update()
    {

     transform.Rotate(Vector3.left * Time.deltaTime * speed);


    }
}
