using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAudio : MonoBehaviour {

    private AudioSource audio;
    public AudioClip zombie1;
    public AudioClip zombie2;
    public AudioClip zombie3;
    private List<AudioClip> audioList = new List<AudioClip>();

    private void Awake()
    {
        AddZombieSounds();
        audio = GetComponent<AudioSource>();
        audio.clip = audioList[Random.Range(0, audioList.Count - 1)];
    }

    // Use this for initialization
    void Start () {
        audio.volume = .05f;
        audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void AddZombieSounds()
    {
        audioList.Add(zombie1);
        audioList.Add(zombie2);
        audioList.Add(zombie3);
    }
}
