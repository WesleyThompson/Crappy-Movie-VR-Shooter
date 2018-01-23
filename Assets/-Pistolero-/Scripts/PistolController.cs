using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolController : MonoBehaviour {

    public int bulletCapacity;
    public int bulletCount;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        if(!animator)
        {
            Debug.LogError("No Animator detected");
        }

        SetBulletCount(bulletCount);
    }

    public void Fire()
    {
        bulletCount--;
        SetBulletCount(bulletCount);
        animator.SetTrigger("Fire");
    }

    public void Reload()
    {
        bulletCount = bulletCapacity;
        animator.SetTrigger("Reload");
    }

    private void SetBulletCount(int bulletCount)
    {
        animator.SetInteger("Bullets", bulletCount);
    }
}
