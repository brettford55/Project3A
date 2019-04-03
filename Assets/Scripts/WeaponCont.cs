using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCont : MonoBehaviour
{
    public float fireRate;
    private float timeUntilFire = 0;
   
   

    public Transform firePoint;
    public GameObject bullet;

    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && Time.time > timeUntilFire)
        {
            timeUntilFire = Time.time + 1 / fireRate;
            Shoot();
        }

    }

    void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        FindObjectOfType<SFXManager>().Play("Laser");
    }

    public void SetVolume(float volume)
    {
        AudioSource audioSource = FindObjectOfType<SFXManager>().GetSound("Laser");
        audioSource.volume = volume;
    }

}
