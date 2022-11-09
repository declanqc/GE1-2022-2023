using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Tank;
    public int MaxEnemies = 0;
    public bool spawned;
    
    System.Collections.IEnumerator Spawn()
    {
  
        while(spawned == true)
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-10, 11), 10, Random.Range(-10, 11));
            GameObject g = Tank; //GameObject.CreatePrimitive(PrimitiveType.Cube);
            //g.AddComponent<Rigidbody>();
            Instantiate(g, randomSpawnPosition, Quaternion.identity);
            MaxEnemies++;
            g.transform.position = transform.position;
        

            yield return new WaitForSeconds(1f);


        }
    }
    // Start is called before the first frame update
    void Start()
    {
        spawned = true;
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(MaxEnemies);

        if (MaxEnemies > 4)
        {
            spawned = false;
        }

    }
}
