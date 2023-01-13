using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 3f;
    float maxHealth;
    //[SerializeField] AreEnemiesDead controlEnemy;
    GameObject player;

    enum Species { none, bigDemon, doc, imp, lizard, necromancer, pumpkin, shamanOrc, wogol, bigZombie, chort, goblin, maskedOrc, orge, skeleton, swampy, tinyZombie, warriorOrc}
    enum EnemyTypes { normal, elite, boss}
    enum AttackTypes { melee, range }

    Dictionary<Species, string> speciesAsset = new Dictionary<Species, string>();

    [SerializeField] EnemyTypes enemyType;
    [SerializeField] Species species;
    [SerializeField] AttackTypes attackType;

    public float damage = 1f;
    public float attackRange = 0f;
    public float attackSpeed = 0f;
    public float attackForce = 7f;

    public GameObject projectilePrefab;

    public ParticleSystem deadEffect;

    public GameObject expParticle;
    int BossExpParticle = 5;
    int EliteExpParticle = 3;
    bool isParticleSpawn = false;

    float attackCooldown = 0f;
    bool isAttackable = false;

    Animator animator;

    float healthBarTimer;
    GameObject healthBar;
    Vector3 healthBarOffset;
    float healthBarScale;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    public void SetAttack(bool value)
    {
        isAttackable = value;
    }

    private void Awake()
    {
        speciesAsset.Add(Species.bigDemon, "big_demon");
        speciesAsset.Add(Species.doc, "doc");
        speciesAsset.Add(Species.imp, "imp");
        speciesAsset.Add(Species.lizard, "lizard");
        speciesAsset.Add(Species.necromancer, "necromancer");
        speciesAsset.Add(Species.pumpkin, "pumpkin");
        speciesAsset.Add(Species.shamanOrc, "shaman_orc");
        speciesAsset.Add(Species.wogol, "wogol");
        speciesAsset.Add(Species.bigZombie, "big_zombie");
        speciesAsset.Add(Species.chort, "chort");
        speciesAsset.Add(Species.goblin, "goblin");
        speciesAsset.Add(Species.maskedOrc, "maskedOrc");
        speciesAsset.Add(Species.orge, "orge");
        speciesAsset.Add(Species.skeleton, "skeleton");
        speciesAsset.Add(Species.swampy, "swampy");
        speciesAsset.Add(Species.tinyZombie, "tiny_zombie");
        speciesAsset.Add(Species.warriorOrc, "warriorOrc");
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        
        player = GameObject.FindGameObjectWithTag("Player");

        healthBarOffset = new Vector3(0, 0.15f, 0);
        healthBarScale = 1f;

        if (enemyType == EnemyTypes.boss)
        {
            gameObject.transform.localScale *= 3f;
            healthBarOffset.y = 0.45f;
            healthBarScale = 3f;


        } else if (enemyType == EnemyTypes.elite)
        {
            gameObject.transform.localScale *= 1.5f;
            healthBarOffset.y = 0.25f;
            healthBarScale = 1.5f;
        }
        if (species == Species.none)
        {
            if (attackType == AttackTypes.range)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Monster/wogol");
                animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animation/Monster/wogol");
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Monster/goblin");
                animator.GetComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animation/Monster/goblin");
            }
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Art/Monster/" + speciesAsset[species]);
            animator.GetComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animation/Monster/" + speciesAsset[species]);
        }

        if (attackType == AttackTypes.melee)
        {
            attackRange = 0.2f;
        }

        maxHealth = health;

        healthBar = Instantiate((GameObject)Resources.Load("Prefab/HealthBar"), transform.position, transform.rotation);
        healthBar.transform.parent = transform;
        healthBar.transform.position += healthBarOffset;
        Vector3 temp = healthBar.transform.localScale;
        temp.x *= healthBarScale;
        temp.y *= healthBarScale/1.4f;
        healthBar.transform.localScale = temp;
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

        if (healthBarTimer > 0)
        {
            healthBarTimer -= Time.deltaTime;
        }
        if (healthBarTimer <= 0)
        {
            HideHealthBar();
        }

        if (health <= 0)
        {
            if (isParticleSpawn == false)
            {
                isParticleSpawn= true;
                if (enemyType == EnemyTypes.boss)
                {
                    for (int i = 0; i < BossExpParticle; i++)
                    {
                        GameObject particle = Instantiate(expParticle, 
                            new Vector3(Random.Range(transform.position.x, transform.position.x + 0.3f), 
                                        Random.Range(transform.position.y, transform.position.y + 0.3f), 
                                        transform.position.z), 
                            transform.rotation);
                    }
                }
                else if (enemyType == EnemyTypes.elite)
                {
                    for (int i = 0; i < EliteExpParticle; i++)
                    {
                        GameObject particle = Instantiate(expParticle,
                            new Vector3(Random.Range(transform.position.x, transform.position.x + 0.3f),
                                        Random.Range(transform.position.y, transform.position.y + 0.3f),
                                        transform.position.z),
                            transform.rotation);
                    }

                }
                else
                {
                    GameObject particle = Instantiate(expParticle,
                            new Vector3(Random.Range(transform.position.x, transform.position.x + 0.3f),
                                        Random.Range(transform.position.y, transform.position.y + 0.3f),
                                        transform.position.z),
                            transform.rotation);
                }
            }
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
        //controlEnemy.KilledEnemy(gameObject);
        GameObject.Destroy(gameObject);
    }

    public void ModifyHealth(float amount)
    {
        health += amount;
        healthBarTimer = 3;
        Vector3 temp = healthBar.transform.GetChild(1).transform.localScale;
        temp.x = 0.5f * (health / maxHealth);
        if (temp.x < 0)
        {
            temp.x = 0;
        }
        healthBar.transform.GetChild(1).transform.localScale = temp;
        ShowHealthBar();
    }

    void ShowHealthBar()
    {
        healthBar.gameObject.SetActive(true);
    }   
    
    void HideHealthBar()
    {
        healthBar.gameObject.SetActive(false);
    }

    void Attack()
    {
        if (enemyType == EnemyTypes.boss)
        {
            BossAttack();
            return;
        }
        
        GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        projectile.GetComponent<Projectile>().SetDamage(damage);
        projectile.GetComponent<Projectile>().SetSource(gameObject.transform.tag);
        //projectile.GetComponent<Projectile>().SetKnockBack(knockBack);
        Vector2 target = new Vector2(player.transform.position.x, player.transform.position.y);
        Vector2 source = new Vector2(transform.position.x, transform.position.y);
        projectile.GetComponent<Rigidbody2D>().AddForce((target - source).normalized * attackForce, ForceMode2D.Impulse);
    }

    int normalAttackCount = 0;
    int specialAttackCount = 0;
    int specialAttack2Count = 0;
    int beamCount = 5;
    int summonCount = 15;
    bool hasSummoned = false;

    void BossAttack()
    {
        if (health/maxHealth <= 0.5)
        {
            beamCount = 10;
            Summon();
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }

        if (normalAttackCount <= 2)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
            projectile.transform.localScale *= 2f;
            projectile.GetComponent<Projectile>().SetDamage(damage);
            projectile.GetComponent<Projectile>().SetSource(gameObject.transform.tag);
            //projectile.GetComponent<Projectile>().SetKnockBack(knockBack);
            Vector2 target = new Vector2(player.transform.position.x, player.transform.position.y);
            Vector2 source = new Vector2(transform.position.x, transform.position.y);
            projectile.GetComponent<Rigidbody2D>().AddForce((target - source).normalized * attackForce, ForceMode2D.Impulse);
            normalAttackCount++;
        }
        else
        {
            normalAttackCount = 0;
            for (int i = 0; i < beamCount; i++)
            {
                GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
                projectile.transform.localScale *= 2f;
                projectile.GetComponent<Projectile>().SetDamage(damage);
                projectile.GetComponent<Projectile>().SetSource(gameObject.transform.tag);
                float angleInRad = Mathf.Rad2Deg * (360 / beamCount) * (i + 1);
                Vector2 direction;
                direction.x = Vector2.up.x * Mathf.Cos(angleInRad) - Vector2.up.y * Mathf.Sin(angleInRad);
                direction.y = Vector2.up.x * Mathf.Sin(angleInRad) + Vector2.up.y * Mathf.Cos(angleInRad);
                Debug.Log(direction);
                projectile.GetComponent<Rigidbody2D>().AddForce(direction.normalized * attackForce, ForceMode2D.Impulse);
            }
        }
    }

    void Summon()
    {
        if (hasSummoned)
        {
            return;
        }
        
        hasSummoned = true;
        float spawnRange = gameObject.GetComponent<EnemyController>().lookRange;

        for (int i = 0; i < summonCount; i++)
        {
            Vector2 spawnPosition;
            spawnPosition.x = Random.Range(-1 * spawnRange, spawnRange);
            spawnPosition.y = Random.Range(-1 * spawnRange, spawnRange);
            GameObject mob = Instantiate((GameObject)Resources.Load("Prefab/Mob"), spawnPosition, transform.rotation);
            mob.transform.parent = transform.parent;
            mob.GetComponent<EnemySpawner>().StartSpawnCount();
        }    
    }
}
