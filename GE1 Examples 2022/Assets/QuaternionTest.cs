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


    Coroutine shootCR = null;

    public float fireRate = 5;


    public GameObject bulletPrefab;
    public Transform bulletSpawn;
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
    IEnumerator ShootCoroutine()
    {
        while (true)
        {
            GameObject bullet = GameObject.Instantiate<GameObject>(bulletPrefab);
            bullet.transform.rotation = transform.rotation;
            bullet.transform.forward = bullet.transform.forward;
            bullet.transform.position = bulletSpawn.position;
            bullet.GetComponent<AudioSource>().pitch = Random.Range(0.5f, 3.0f);
            bullet.GetComponent<AudioSource>().Play();

            yield return new WaitForSeconds(1 / (float)fireRate);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isLooking = true;
            LookAtPlayer();
            Debug.Log("looking");
            shootCR = StartCoroutine(ShootCoroutine());
        }
        else
        {
            isLooking = false;  
        }
    }
}
