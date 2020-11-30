﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableScript : MonoBehaviour
{
    public int health = 100;

    public Animator animator;

    void Start()
    {  
        animator = GetComponent<Animator>();

        InvokeRepeating("ResetHitTrigger", 1.0f, 1.0f);

        if(animator != null)
        {
            //Setting the health as an integer in the animator
            animator.SetInteger("HP", health);
        }
    }

    public void TakeDamage (int damage)
    {
        health -= damage;
        animator.SetTrigger("isHit");
        animator.ResetTrigger("isHit");

        if(animator != null)
        {  
            //Setting the HP integer accordingly
            animator.SetInteger("HP", health);
        }

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if(animator != null)
        {
            //Destroying the gameobject after a short pause to play the animation, gotta find a better way
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void ResetHitTrigger()
    {
        animator.ResetTrigger("isHit");
    }

}
