using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Tank;
    public int MaxEnemies = 0;
    System.Collections.IEnumerator Spawn()
    {
  
        while(true)
        {
            GameObject g = Tank; //GameObject.CreatePrimitive(PrimitiveType.Cube);
            //g.AddComponent<Rigidbody>();
            Instantiate(g);
            MaxEnemies++;
            g.transform.position = transform.position;
        

            yield return new WaitForSeconds(1f);


        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {

        if (MaxEnemies >= 5)
        {
            CancelInvoke("Spawn");
        }

    }
}
