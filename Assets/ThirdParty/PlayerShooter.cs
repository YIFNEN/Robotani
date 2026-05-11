using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [Header("발사 설정")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 15f;
    public float fireRate = 0.5f;

    [Header("오디오")]
    public AudioClip shootSFX;
    private AudioSource audioSource;

    private float nextFireTime = 0f;

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        rb.velocity = firePoint.forward* bulletSpeed;



        if (shootSFX != null)
        {
            audioSource.PlayOneShot(shootSFX);
            
        }

        AudioManager.Instance?.PlayShoot();

        Destroy(bullet, 7f);


    }

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }
    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate; 
        }
        
    }
}
