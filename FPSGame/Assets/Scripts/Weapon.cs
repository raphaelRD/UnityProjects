using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public ObjectPool bulletPool;
    public Transform muzzle;

    public int curAmmo;
    public int maxAmmo;
    public bool infintieAmmo;

    public float bulletSpeed;
    
    public float shootRate;
    private float lastShootTime;
    private bool isPlayer;
    public AudioClip shootSfx;
    private AudioSource audioSource;

    void Awake()
    {
        if(GetComponent<Player>())
            isPlayer = true;

        audioSource = GetComponent<AudioSource>();
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
        audioSource.PlayOneShot(shootSfx);
        GameObject bullet = bulletPool.GetObject();
        bullet.transform.position = muzzle.position;
        bullet.transform.rotation = muzzle.rotation;
        bullet.GetComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed;

        if(isPlayer){
            GameUI.instance.UpdateAmmoText(curAmmo,maxAmmo);
        }
    }

    
}
