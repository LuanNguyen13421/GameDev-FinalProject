using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public HealthBar healthBar;
    public float maxHealth = 20.0f;
    public float level = 0.0f;
    public float health { get { return currentHealth; }}
    public float attackSpeed = 0.5f;
    public float damage = 1f;
    public float posX { get { return transform.position.x; } }
    public float posY { get { return transform.position.y; } }
    public float attackForce = 5.0f;
    public float knockBack = 1.0f;
    public GameObject projectilePrefab;
    public GameObject projectileMeleePrefab;
    public Animator animator;

    float currentHealth;
    float currentExp;
    float attackCooldown;
    [SerializeField] bool isMeleeCombat = false;
    bool isAttackable = true;

    AudioSource audioSrc;
    public AudioClip AttackSound;
    void Start()
    {
        currentHealth = maxHealth;
        currentExp = 0;
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
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
        playSound(AttackSound);
    }

    void MeleeAttack()
    {
        // Play animation
        animator.SetTrigger("MeleeAttack");
        GameObject projectile = Instantiate(projectileMeleePrefab, transform.position, transform.rotation);
        projectile.GetComponent<ProjectileForMelee>().SetDamage(damage);
        projectile.GetComponent<ProjectileForMelee>().SetSource(gameObject.transform.tag);
        projectile.GetComponent<ProjectileForMelee>().SetKnockBack(knockBack);
        Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 source = new Vector2(transform.position.x, transform.position.y);
        projectile.GetComponent<Rigidbody2D>().AddForce((target - source).normalized * attackForce, ForceMode2D.Impulse);
        playSound(AttackSound);


    }

    public void ModifyHealth(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
    }

    public void ModifyExp(float amount)
    {
        currentExp += amount;
        //CheckLevel();
    }

    public void CheckLevel()
    {
        if (currentExp >= 10 && currentExp < 20) level = 1;
        else if (currentExp >= 20 && currentExp < 30) level = 2;
        else if (currentExp >= 30 && currentExp < 40) level = 3;
        else if (currentExp >= 40 && currentExp < 50) level = 4;
        else if (currentExp >= 50) level = 5;

        switch(level)
        {
            case 1:
            {
                maxHealth = maxHealth * 1.1f;
                damage = damage * 1.1f;
                transform.localScale = new Vector3(1.2f, 1.2f, 1.0f);
                break;
            }
            case 2:
            {
                maxHealth = maxHealth * 1.2f;
                damage = damage * 1.2f;
                transform.localScale = new Vector3(1.4f, 1.4f, 1.0f);
                break;
            }
            case 3:
            {
                maxHealth = maxHealth * 1.3f;
                damage = damage * 1.3f;
                transform.localScale = new Vector3(1.6f, 1.6f, 1.0f);
                break;
            }
            case 4:
            {
                maxHealth = maxHealth * 1.4f;
                damage = damage * 1.4f;
                transform.localScale = new Vector3(1.8f, 1.8f, 1.0f);
                break;
            }
            case 5:
            {
                maxHealth = maxHealth * 1.5f;
                damage = damage * 1.5f;
                transform.localScale = new Vector3(2.0f, 2.0f, 1.0f);
                break;
            }
        }
    }

    public void playSound(AudioClip clip)
    {
        audioSrc.PlayOneShot(clip);
    }
}
