using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public int loops = 10;
    public GameObject prefab;
    void Start()
    {

        for (int i = 0; i <= loops; i++)
        {
            float radius = 2f * i;
            int C = (int)(2 * Mathf.PI * radius);


            for (int l = 0; l < C; l++)
            {
                float cx = transform.position.x;
                float cy = transform.position.y;


                float angle = (2 * Mathf.PI / C) * l;

                float x = cx + radius * Mathf.Cos(angle);
                float y = cy + radius * Mathf.Sin(angle);

                GameObject instance = Instantiate(prefab);
                instance.transform.position = new Vector3(x, y, 0);

            }
        }

    }
}



      
