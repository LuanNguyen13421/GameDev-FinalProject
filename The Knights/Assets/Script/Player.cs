using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health = 3f;
    public float attackSpeed = 0.5f;
    public float damage = 1f;

    public float attackForce = 200f;
    public float knockBack = 10f;

    public GameObject projectilePrefab;

    float attackCooldown;
    bool isShootable = true;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        attackCooldown -= Time.deltaTime;
        if (attackCooldown <= 0)
        {
            isShootable = true;
        }
        if(Input.GetButtonDown("Fire1"))
        {
            if(isShootable)
            {
                Shoot();
                attackCooldown = attackSpeed;
                isShootable = false;
            }
        }
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        projectile.GetComponent<Projectile>().SetDamage(damage);
        projectile.GetComponent<Projectile>().SetSource(gameObject.transform.tag);
        projectile.GetComponent<Projectile>().SetKnockBack(knockBack);
        Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 source = new Vector2(transform.position.x, transform.position.y);
        projectile.GetComponent<Rigidbody2D>().AddForce((target - source).normalized * attackForce, ForceMode2D.Impulse);
    }

    public void ModifyHealth(float amount)
    {
        health += amount;
    }
}
