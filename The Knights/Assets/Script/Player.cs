using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxHealth = 10.0f;
    public float health { get { return currentHealth; } }
    public float attackSpeed = 0.5f;
    public float damage = 1f;
    public float attackForce = 5.0f;
    public float knockBack = 1.0f;
    public GameObject projectilePrefab;
    public Animator animator;

    float currentHealth;
    float attackCooldown;
    bool isMeleeCombat = false;
    bool isAttackable = true;

    void Start()
    {
        currentHealth = maxHealth - 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (attackCooldown > 0)
        {
            attackCooldown -= Time.deltaTime;
        }
        if (attackCooldown <= 0)
        {
            isAttackable = true;
        }

        // Change attack range according to model


        // Attack
        if (Input.GetButtonDown("Fire1"))
        {
            if (isAttackable)
            {
                if (isMeleeCombat)
                {
                    MeleeAttack();
                }
                else
                {
                    RangedAttack();
                }
                attackCooldown = attackSpeed;
                isAttackable = false;
            }
        }
    }

    void RangedAttack()
    {
        // Play animation
        animator.SetTrigger("RangedAttack");
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
        animator.SetTrigger("MeleeAttack");
        // Create projectile


    }

    public void ModifyHealth(float amount)
    {
        currentHealth = currentHealth + amount;
    }
}
