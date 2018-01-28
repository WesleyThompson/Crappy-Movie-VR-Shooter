using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

    private AudioSource audio;
    public float musicVolume;

    // Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.X))
        {
            FadeSong();
            StartCoroutine("FadeSong");
        }
        if (Input.GetKeyUp(KeyCode.B))
        {
            StopSong();
        }
        if (Input.GetKeyUp(KeyCode.P))
        {
            PlaySong();
        }
    }

    public void PlaySong()
    {
        audio.volume = musicVolume;
        audio.time = 54.85f;
        audio.Play();

    }

    IEnumerator FadeSong()
    {
        if (audio.isPlaying)
        {
            while(audio.volume > 0)
            {
                audio.volume -= .06f;
                yield return new WaitForSeconds(.1f);
            }
        }
    }

    public void StopSong()
    {
        audio.Stop();
        Debug.Log("i'm getting called for no reason");
    }
}
