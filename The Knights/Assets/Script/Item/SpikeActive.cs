using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeActive : MonoBehaviour
{
    bool isActive = false;
    Animator anim;
    public float waitTime = 3.0f;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        timer = waitTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            
            if (isActive)
            {
                anim.SetBool("isActive", false);
                isActive = false;
            }
            else
            {
                anim.SetBool("isActive", true);
                isActive = true;
            }
            timer = waitTime;
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        Player controller = other.GetComponent<Player>();

        if (controller != null && isActive == true)
        {
            controller.ModifyHealth(-1);
        }
    }
}
