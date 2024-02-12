using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform muzzle;

    public int curAmmo;
    public int maxAmmo;
    public bool infintieAmmo;

    public float bulletSpeed;
    
    public float shootRate;
    private float lastShootTime;
    private bool isPlayer;

    void Awake()
    {
        if(GetComponent<Player>())
            isPlayer = true;
    }

    public bool CanShoot()
    {
        if(Time.time - lastShootTime >= shootRate)
        {
            if (curAmmo>0 || infintieAmmo==true)
            {
                return true;
            }
        }
        return false;
    }

    public void Shoot()
    {
        lastShootTime = Time.time;
        curAmmo--;

        GameObject bullet = Instantiate(bulletPrefab, muzzle.position,muzzle.rotation);
        bullet.GetComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed;
    }

    
}
