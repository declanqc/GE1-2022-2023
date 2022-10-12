using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{

    public GameObject head;
    public GameObject tail;

    [Range(0.0f, 5.0f)]
    public float Frequency;

    public int HeadAmplitude;
    public int TailAmplitude;
    public float theta;
    void Start()
    {
        
    }

    void Update()
    {


        Frequency += theta * Time.deltaTime;
        float HeadRotation = Mathf.Sin(Frequency) * HeadAmplitude;
        float TailRotation = Mathf.Sin(Frequency) * TailAmplitude;

        head.transform.localRotation = Quaternion.AngleAxis(HeadRotation, new Vector3(0, 0, 200));
        tail.transform.localRotation = Quaternion.AngleAxis(TailRotation, new Vector3(0, 0, 200));




    }
}
