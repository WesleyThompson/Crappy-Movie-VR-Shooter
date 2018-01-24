using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

[RequireComponent(typeof(Animator))]
public class PistolController : MonoBehaviour {

    public VRTK_ControllerEvents controllerEvents;
    public int bulletCapacity;
    public int bulletCount;

    [SerializeField] private AudioSource fireSound;
    [SerializeField] private AudioSource reloadSound;
    [SerializeField] private AudioSource dropMagSound;
    [SerializeField] private AudioSource emptyMagFireSound;

    private bool isEmpty = false;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        SetBulletCount(bulletCount);
        if(bulletCount == 0)
        {
            isEmpty = true;
            animator.Play("PistolMovingPartsEmpty");
        }

        //Setup events
        controllerEvents.TriggerClicked += new ControllerInteractionEventHandler(Fire);
    }

    public void Fire(object sender, ControllerInteractionEventArgs e)
    {
        if(!isEmpty)
        {
            fireSound.Play();
            bulletCount--;
            SetBulletCount(bulletCount);
            if (bulletCount == 0)
            {
                isEmpty = true;
            }
            animator.SetTrigger("Fire");
        }
        else
        {
            emptyMagFireSound.Play();
        }
    }

    public void Reload(object sender, ControllerInteractionEventArgs e)
    {
        reloadSound.Play();
        bulletCount = bulletCapacity;
        isEmpty = false;
        animator.SetTrigger("Reload");
    }

    public void DropMag(object sender, ControllerInteractionEventArgs e)
    {
        bulletCount = 0;
        SetBulletCount(bulletCount);
        animator.Play("PistolMovingPartsEmpty");
        dropMagSound.Play();
    }

    private void SetBulletCount(int bulletCount)
    {
        animator.SetInteger("Bullets", bulletCount);
    }
}
