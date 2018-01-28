using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PistoleroMenuObj : MonoBehaviour {

    public UnityEvent OnShoot;
    public bool isSingleUse = false;

    private bool used = false;

    public void ShotMenu()
    {
        if (isSingleUse)
        {
            if(!used)
            {
                used = true;
                OnShoot.Invoke();
            }
        }
        else
        {
            OnShoot.Invoke();
        } 
    }
}
