using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionTest : MonoBehaviour
{

    public Transform Cube1;
    public Transform Cube2;
    public Quaternion start;
    public Quaternion end;
    // Start is called before the first frame update
    void Start()
    {
        //  Quaternion q;

         Vector3 toTarget = Cube1.position - transform.position;
         /* toTarget.Normalize();
          float dot = Vector3.Dot(toTarget, transform.forward);
          float theta = Mathf.Acos(dot);

          q = Quaternion.AngleAxis(theta * Mathf.Rad2Deg, Vector3.up);*/



        Quaternion q = Quaternion.LookRotation(toTarget);
       // transform.rotation = q;

        Vector3 a = new Vector3(0, 0, 10);

        Quaternion q1 = Quaternion.AngleAxis(90, Vector3.up);
        Quaternion q2 = Quaternion.AngleAxis(90, Vector3.right);


        a = q1 * a;

        Debug.Log(a);

        start = q;

        end = Quaternion.LookRotation(Cube2.position - transform.position);

       



    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
