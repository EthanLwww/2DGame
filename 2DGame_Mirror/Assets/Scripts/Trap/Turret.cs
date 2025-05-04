/*
This Script is used for turret to shoot bullet.
The turret prefab have a firepoint and a bullet.
When use,just drag the turret prefab to the scene.You can set the firepoint as you like.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public enum Direction //Fire firection
    {
        Up,
        Down,
        Left,
        Right
    }

    [Header("Bullet Settings")]
    public GameObject bulletPrefab;//bullet prefab
    public Transform firePoint;//fire point
    public float bulletSpeed = 3f;// bullet speed
    public float lifeTime = 1f;//bullet life time
    [Header("Fire Direction")]
    public Direction fireDirection = Direction.Right; //fire direction

    [Header("Fire Settings")]
    public float fireRate = 1f; // fire rate(seconds)
    private float nextFireTime = 0f; // next fire time

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);//create a bullet

        //get bullet's rigidbody and set speed
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb == null)
            Debug.LogError("Bullet prefab does not have a Rigidbody2D component.");
        switch (fireDirection)
        {
            case Direction.Up:
                rb.velocity = firePoint.up * bulletSpeed;
                break;
            case Direction.Down:
                rb.velocity = -firePoint.up * bulletSpeed;
                break;
            case Direction.Left:
                rb.velocity = -firePoint.right * bulletSpeed;
                break;
            case Direction.Right:
                rb.velocity = firePoint.right * bulletSpeed;
                break;
        }
        Destroy(bullet, lifeTime);//destroy bullet after life time
    }
}
