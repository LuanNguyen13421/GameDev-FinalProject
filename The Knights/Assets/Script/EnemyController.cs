using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Transform target;
    public float speed = 2f;
    public float lookRange = 10f;
    public float roamingSpeed = 1f;
    public float roamingRange = 10f;
    public float timeBeforeNextRoam = 1f;
     
    float timeCounter = 0f;
    Vector2 roamingTarget;
    bool isFollowingTarget = false;
    bool isRoaming = false;
    
    Vector2 rootPosition;
    Animator animator;

    Vector2 oldPosition;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rootPosition = transform.position;
        animator = GetComponent<Animator>();
    }
    private void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lookRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, roamingRange);
    }

    private void Update()
    {
        if ((transform.position.x - oldPosition.x)*transform.localScale.x < 0)
        {
            Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;

            Vector3 healthBarScale = transform.Find("HealthBar(Clone)").transform.localScale;
            healthBarScale.x *= -1;
            transform.Find("HealthBar(Clone)").localScale = healthBarScale;
        }

        if (Vector2.Distance(transform.position, target.position) <= lookRange)
        {
            isFollowingTarget = true;
            isRoaming = false;
        }
        else
        {
            if(isFollowingTarget)
            {
                rootPosition = transform.position;
            }    
            isFollowingTarget = false;
        }

        if (timeCounter > 0)
        {
            timeCounter -= Time.deltaTime;
        }
        if (timeCounter <= 0 && !isRoaming)
        {
            isRoaming = true;
            roamingTarget.x = Random.Range(rootPosition.x - roamingRange, rootPosition.x + roamingRange);
            roamingTarget.y = Random.Range(rootPosition.y - roamingRange, rootPosition.y + roamingRange);
        }

        if (isFollowingTarget || isRoaming)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        oldPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isFollowingTarget)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
            //Debug.Log("Following target");
        } else if (isRoaming)
        {
            transform.position = Vector2.MoveTowards(transform.position, roamingTarget, roamingSpeed * Time.fixedDeltaTime);
            //Debug.Log("Roaming");
            if (new Vector2(transform.position.x, transform.position.y) == roamingTarget)
            {
                isRoaming = false;
                timeCounter = timeBeforeNextRoam;
            }
        }
    }


}
