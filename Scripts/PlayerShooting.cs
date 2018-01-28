﻿using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;     

    float timer;                                 
    Ray shootRay;                                  
    RaycastHit shootHit;                           
    int shootableMask;                            
    ParticleSystem gunParticles;                    
    LineRenderer gunLine;                             
    Light gunLight;                                 
    float effectsDisplayTime = 0.4f;     
    GameObject player;
    Animator anim;

    void Awake ()
    {
        player = player = GameObject.FindGameObjectWithTag ("Player");
        anim = player.GetComponent<Animator>();
        shootableMask = LayerMask.GetMask ("Shootable");
        gunParticles = GetComponent<ParticleSystem> ();
        gunLine = GetComponent <LineRenderer> ();
        gunLight = GetComponent<Light> ();
    }

    void Update ()
    {
        timer += Time.deltaTime;

        if(timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects ();
        }
    }

    public void DisableEffects ()
    {
       gunLine.enabled = false;
        gunLight.enabled = false;
    }
 
    public void Fires(bool fires){
        anim.SetBool("IsFiring",fires);
    }

    public void Shoot ()
    {
        if( timer < timeBetweenBullets)
        {  
           return;
        }

        timer = 0f;
        gunLight.enabled = true;

        gunParticles.Stop ();
        gunParticles.Play ();

        gunLine.enabled = true;
        gunLine.SetPosition (0, transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if(Physics.Raycast (shootRay, out shootHit, range, shootableMask))
        {
            EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();

            if(enemyHealth != null)
            {
                enemyHealth.TakeDamage (damagePerShot);
            }

          gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
            //gunLine.SetPosition (1, shootHit.point);
        }
        else
        {
            gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
        }
    }

}