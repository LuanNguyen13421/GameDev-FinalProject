using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Transform target;
    public float speed = 2f;
    public float range = 10f;

    bool isFollowingTarget = false;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, target.position) <= range)
        {
            Debug.Log("Target is in range");
            isFollowingTarget = true;
        }
        else
        {
            isFollowingTarget = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isFollowingTarget)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
        }
    }


}
