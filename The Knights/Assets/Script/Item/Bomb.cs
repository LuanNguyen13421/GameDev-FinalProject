using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float damage = 2.0f;
    Animator anim;
    public float bombWaitTime = 1.5f;
    float timer;
    bool flagExplode = false;
    float range = 1.5f;
    float posX = 0.0f;
    float posY = 0.0f;
    Player controller;
    AudioSource bombAudioSrc;
    public AudioClip explodeClip;
    bool playSoundFlag = true;
    void Start()
    {
        anim = GetComponent<Animator>();
        bombAudioSrc = GetComponent<AudioSource>();
        timer = bombWaitTime;
    }
    void Update()
    {
        if (flagExplode)
        {
            if (playSoundFlag)
            {
                bombAudioSrc.PlayOneShot(explodeClip);
                playSoundFlag = false;
            }
            posX = controller.posX;
            posY = controller.posY;
            float xObj = transform.position.x;
            float yObj = transform.position.y;
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                float Dx = Mathf.Abs(Mathf.Max(xObj, posX) - Mathf.Min(xObj, posX));
                float Dy = MathF.Abs(Mathf.Max(yObj, posY) - Mathf.Min(yObj, posY));
                float distance = MathF.Sqrt(Dx * Dx + Dy * Dy);
                if (distance < range)
                {
                    controller.ModifyHealth(-1.0f * damage);
                }
                Destroy(gameObject);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        controller = other.GetComponent<Player>();
        if (controller != null)
        {
            anim.SetBool("isTrigger", true);
            flagExplode = true;
        }
    }
}
