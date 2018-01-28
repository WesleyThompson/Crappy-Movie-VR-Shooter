using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

[RequireComponent(typeof(Animator))]
public class PistolController : MonoBehaviour {

    public VRTK_ControllerEvents controllerEvents;
    public int bulletCapacity;
    public int bulletCount;
    public float maxTime = .005f;
    public float timeRemaining;

    AnimatorClipInfo[] m_CurrentClipInfo;
    string m_ClipName;

    [SerializeField] private AudioSource fireSound;
    [SerializeField] private AudioSource reloadSound;
    [SerializeField] private AudioSource dropMagSound;
    [SerializeField] private AudioSource emptyMagFireSound;
    [SerializeField] private ParticleSystem flash;

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

        timeRemaining = 0;

        //Setup events
        controllerEvents.TriggerClicked += new ControllerInteractionEventHandler(Fire);
        controllerEvents.GripPressed += new ControllerInteractionEventHandler(Reload);
    }

    private void Update()
    {
        if(timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
    }

    public void Fire(object sender, ControllerInteractionEventArgs e)
    {
        
        if (timeRemaining <= 0)
        {
            if (!isEmpty)
            {

                fireSound.Play();
                flash.Play();
                bulletCount--;
                SetBulletCount(bulletCount);
                if (bulletCount == 0)
                {
                    isEmpty = true;
                }
                animator.SetTrigger("Fire");

                //Shoot enemies and stuff
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit))
                {
                    Debug.Log("Hit: " + hit.transform.name);
                    if (hit.transform.CompareTag("enemy"))
                    {
                        hit.transform.GetComponent<EnemyDying>().EnemyDies();
                    }
                    else if (hit.transform.CompareTag("menu"))
                    {
                        hit.transform.GetComponent<PistoleroMenuObj>().ShotMenu();
                    }
                }
                timeRemaining = maxTime;
            }
            else
            {
                emptyMagFireSound.Play();
                animator.Play("PistolMovingPartsFireLast");
            }
        }
        
    }

    public void Reload(object sender, ControllerInteractionEventArgs e)
    {
        if (bulletCount == 0)
        {
            reloadSound.Play();
            bulletCount = bulletCapacity;
            SetBulletCount(bulletCount);
            isEmpty = false;
            animator.SetTrigger("Reload");
        } 
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
