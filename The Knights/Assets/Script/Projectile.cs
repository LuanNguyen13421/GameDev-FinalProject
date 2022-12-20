using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    float damage;
    string source;
    float knockBack;

    public float flyingTime = 10f;

    void Start()
    {
        Invoke("Destroy", flyingTime);
    }

    public void SetDamage(float _damage)
    {
        damage = _damage;
    }

    public void SetSource(string _source)
    {
        source = _source;
    }

    public void SetKnockBack(float _knockBack)
    {
        knockBack = _knockBack;
    }    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (source == "Player")
        {
            if (collision.transform.tag == "Enemy")
            {
                collision.gameObject.GetComponent<Enemy>().ModifyHealth(-damage);
                Destroy();
            }
        } 
        else if (source == "Enemy")
        {
            if (collision.transform.tag == "Player")
            {
                collision.gameObject.GetComponent<Player>().ModifyHealth(-damage);
                Destroy();
            }
        }
    }

    private void Destroy()
    {
        GameObject.Destroy(gameObject);
    }
}
