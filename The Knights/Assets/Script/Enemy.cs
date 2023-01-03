using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 3f;

    GameObject player;

    enum EnemyTypes { normal, elite, boss}

    enum AttackTypes { melee, range }

    [SerializeField] EnemyTypes enemyType;
    [SerializeField] AttackTypes attackType;

    public float damage = 1f;
    public float attackRange = 0f;
    public float attackSpeed = 0f;
    public float attackForce = 7f;

    public GameObject projectilePrefab;

    public ParticleSystem deadEffect;

    float attackCooldown = 0f;
    bool isAttackable = true;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (enemyType == EnemyTypes.boss)
        {
            gameObject.transform.localScale *= 2f;
        } else if (enemyType == EnemyTypes.elite)
        {
            gameObject.transform.localScale *= 1.5f;
        }

        if (attackType == AttackTypes.range)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (attackCooldown > 0)
        {
            attackCooldown -= Time.deltaTime;
        }
        if (attackCooldown <= 0)
        {
            isAttackable = true;
        }

        if (health <= 0)
        {
            var effect = Instantiate(deadEffect, transform.position, transform.rotation, gameObject.transform);
            Destroy(effect, effect.main.duration);
            Invoke("Destroy", effect.main.duration);
        }

        if (Vector2.Distance(transform.position, player.transform.position) <= attackRange && isAttackable)
        {
            Attack();
            attackCooldown = attackSpeed;
            isAttackable = false;
        }
    }

    private void Destroy()
    {
        GameObject.Destroy(gameObject);
    }

    public void ModifyHealth(float amount)
    {
        health += amount;
    }

    void Attack()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        projectile.GetComponent<Projectile>().SetDamage(damage);
        projectile.GetComponent<Projectile>().SetSource(gameObject.transform.tag);
        //projectile.GetComponent<Projectile>().SetKnockBack(knockBack);
        Vector2 target = new Vector2(player.transform.position.x, player.transform.position.y);
        Vector2 source = new Vector2(transform.position.x, transform.position.y);
        projectile.GetComponent<Rigidbody2D>().AddForce((target - source).normalized * attackForce, ForceMode2D.Impulse);
    }
}
