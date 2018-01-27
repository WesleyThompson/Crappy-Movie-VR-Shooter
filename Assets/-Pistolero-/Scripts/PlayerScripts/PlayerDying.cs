using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDying : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.CompareTag("enemy"))
        {
            Debug.Log("You died idiot");
        }
    }
}
