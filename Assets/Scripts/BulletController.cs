﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;
    public float bulletLifeTime;
    public GameObject particle;
   

    void FixedUpdate()
    {
        this.transform.Translate(Vector2.up * speed * Time.deltaTime);
    }


    void Start()
    {
        StartCoroutine(SelfDestruct());
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(bulletLifeTime);
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {

            Asteroid enemy = other.gameObject.GetComponent<Asteroid>();
            enemy.health -= 5;
            Destroy(this.gameObject);
            GameObject part = Instantiate(particle, other.transform.position, Quaternion.identity);
            part.GetComponent<ParticleSystem>().Play();
            Destroy(part, 1);

        }
    }


    
}


