using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health = 10.0f;
    public float attackSpeed = 0.5f;
    public float damage = 1f;
    public float attackForce = 5.0f;
    public float knockBack = 1.0f;
    public GameObject projectilePrefab;
    public Animator animator;

    float attackCooldown;
    bool isMeleeCombat = false;
    //bool isShootable = true;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // attackCooldown -= Time.deltaTime;
        // if (attackCooldown <= 0)
        // {
        //     isShootable = true;
        // }
        if (attackCooldown > 0)
        {
            attackCooldown -= Time.deltaTime;
        }

        // Change attack range
        

        // Attack
        if(Input.GetButtonDown("Fire1"))
        {
            if (isMeleeCombat)
            {
                if (attackCooldown <= 0)
                {

                }
            }
            else
            {
                if (attackCooldown <= 0)
                {
                    RangedAttack();
                    attackCooldown = attackSpeed;
                    //isShootable = false;
                }
            }
        }
    }

    void RangedAttack()
    {
        // Play animation
        animator.SetTrigger("Attack");
        // Create projectile
        GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        projectile.GetComponent<Projectile>().SetDamage(damage);
        projectile.GetComponent<Projectile>().SetSource(gameObject.transform.tag);
        projectile.GetComponent<Projectile>().SetKnockBack(knockBack);
        Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 source = new Vector2(transform.position.x, transform.position.y);
        projectile.GetComponent<Rigidbody2D>().AddForce((target - source).normalized * attackForce, ForceMode2D.Impulse);
    }

    void MeleeAttack()
    {
        // Play animation

        // Detect enemy in attack range

        // Damage enemy
        
    }

    public void ModifyHealth(float amount)
    {
        health += amount;
    }
}
