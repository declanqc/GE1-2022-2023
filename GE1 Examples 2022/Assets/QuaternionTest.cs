using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class QuaternionTest : MonoBehaviour
{
    public float turnSpeed = 10;
    public Transform Player;
    public Transform Cube1;
    public Transform Cube2;
    public Quaternion start;
    public Quaternion end;
    public bool isLooking;
    void Start()
    {
    }

   


    void Update()
    {
       
    }

    public void LookAtPlayer()
    {
         
        
            Vector3 dir = Player.position - transform.position;
            Quaternion lookRot = Quaternion.LookRotation(dir);
            lookRot.x = 0; lookRot.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Mathf.Clamp01(3.0f * Time.maximumDeltaTime));
        
        
    }


    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isLooking = true;
            LookAtPlayer();
            Debug.Log("looking");
        }
        else
        {
            isLooking = false;  
        }
    }
}
