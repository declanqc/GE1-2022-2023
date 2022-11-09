using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITank : MonoBehaviour
{
    public List<Vector3> waypoints;
    public int count = 5;
    public float radius = 5;

    public float speed;
    public float fov;

    public Transform player;

    void SetUpWaypoints()
    {
        waypoints = new List<Vector3>();
        waypoints.Clear();
        float theta = (Mathf.PI * 2.0f) / (float) count;

        for(int i = 0 ; i < count ; i ++)
        {
            float angle = i * theta;
            Vector3 p = new Vector3
                (
                    Mathf.Sin(angle) * radius, 
                    0,
                    Mathf.Cos(angle) * radius
                );
            p = transform.TransformPoint(p);
            waypoints.Add(p);

        }
    }

    void OnDrawGizmos()
    {
        if (!Application.isPlaying)
        {
            SetUpWaypoints();
            foreach (Vector3 v in waypoints)
            {
                Gizmos.DrawWireSphere(v, 0.5f);
            }
        }
    }

        // Start is called before the first frame update
        void Start()
    {
        SetUpWaypoints();

    }

    int current = 0;

    // Update is called once per frame
    void Update()
    {
        Vector3 totarget = waypoints[current] - transform.position;
        float dist = totarget.magnitude;
        if (dist < 1.0f)
        {
            current = (current + 1) % waypoints.Count;
        }
        Quaternion q = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(totarget), Time.deltaTime);
        //transform.rotation = q;
        //transform.Translate(0, 0, speed * Time.deltaTime);

        Vector3 toPlayer = player.position - transform.position;
        toPlayer.Normalize();
        float dot = Vector3.Dot(toPlayer, transform.forward);
       
        GameManager.Log((dot > 0) ? "In front" : "behind");            
        float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;
        if (angle < 45)
        {
            GameManager.Log("I can see you");
        }
        else
        {
            GameManager.Log("I can't see you");
        }
    }
    void StopFollowpath()
    {
        StopCoroutine("FollowPath");
    }
    IEnumerator FollowPath(Vector3[] waypoints)
    {
        transform.position = waypoints[0];
        int targetWaypointIndex = 1;
        Vector3 targetWaypoint = waypoints[targetWaypointIndex];
        transform.LookAt(targetWaypoint);

        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, speed * Time.deltaTime);
            if (transform.position == targetWaypoint)
            {
                targetWaypointIndex = (targetWaypointIndex + 1) % waypoints.Length;
                targetWaypoint = waypoints[targetWaypointIndex];
                yield return new WaitForSeconds(waitTime);
                yield return StartCoroutine(TurnToFace(targetWaypoint));
            }
            yield return null;
        }

    }

    IEnumerator TurnToFace(Vector3 lookTarget)
    {
        Vector3 dirToLookTarget = (lookTarget - transform.position).normalized;
        float targetAngle = 90 - Mathf.Atan2(dirToLookTarget.z, dirToLookTarget.x) * Mathf.Rad2Deg;

        while (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.y, targetAngle)) > 0.05f)
        {
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetAngle, turnSpeed * Time.deltaTime);
            transform.eulerAngles = Vector3.up * angle;
            yield return null;
        }
    }
    bool CanSeePlayer()
    {

        if (Vector3.Distance(transform.position, Player.position) < viewDistance)
        {
            Vector3 dirToPlayer = (Player.position - transform.position).normalized;
            float angleBetweenGuardAndPlayer = Vector3.Angle(transform.forward, dirToPlayer);
            if (angleBetweenGuardAndPlayer < viewAngle / 2f)
            {
                if (!Physics.Linecast(transform.position, Player.position, viewMask))
                {
                    return true;
                }
            }
        }
        return false;
    }
}
