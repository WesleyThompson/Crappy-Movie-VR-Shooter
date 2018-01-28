using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class TriggerOnAudioEnd : MonoBehaviour {

    public AudioClip clip = new AudioClip();
    public UnityEvent onClipEnd;

    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        source.loop = false;
        source.playOnAwake = false;

        if(!clip)
        {
            enabled = false;
        }
    }

    public void StartAudio()
    {
        StartCoroutine(PlayClip());
    }

    IEnumerator PlayClip()
    {
        source.clip = clip;
        source.Play();
        yield return new WaitForSeconds(clip.length);
        onClipEnd.Invoke();
    }
}
