using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using VRTK;
using VRTK.UnityEventHelper;

public class PistoleroGameManager : MonoBehaviour {

    public UnityEvent onStartGame;

    [Header("Wave One")]
    public int wave1Count;
    public float wave1SpawnDelay;
    public TriggerOnAudioEnd wave1Success;
    public TriggerOnAudioEnd wave1Fail;
    public VRTK_HeadsetFade wave1Fade;
    public UnityEvent onStartWave1;
    [Header("Wave Two")]
    public int wave2Count;
    public float wave2SpawnDelay;
    public TriggerOnAudioEnd wave2Success;
    public TriggerOnAudioEnd wave2Fail;
    public VRTK_HeadsetFade wave2Fade;
    public UnityEvent onStartWave2;
    [Header("Wave Three")]
    public int wave3Count;
    public float wave3SpawnDelay;
    public TriggerOnAudioEnd wave3Success;
    public TriggerOnAudioEnd wave3Fail;
    public VRTK_HeadsetFade wave3Fade;
    public UnityEvent onStartWave3;

    public SpawnController spawnController;
    public VRTK_HeadsetFade EndFade;
    public GameObject leftPistol;
    public GameObject rightPistol;

    private int currentWave = 1;
    private bool inWave = false;
    private VRTK_HeadsetFade fade;

    private void Awake()
    {
    }

    private void Update()
    {
        if(inWave)
        {
            if(spawnController.activeEnemies.Count == 0 && spawnController.firstSpawn == true)
            {
                EndWave(true);
            }
        }
    }

    public void StartGame()
    {
        onStartGame.Invoke();
    }

    public void StartWave(int waveNum)
    {
        currentWave = waveNum;
        inWave = true;
        switch(currentWave)
        {
            case 1:
                onStartWave1.Invoke();
                spawnController.StartWave(wave1Count, wave1SpawnDelay);
                break;
            case 2:
                onStartWave2.Invoke();
                spawnController.StartWave(wave2Count, wave2SpawnDelay);
                break;
            case 3:
                onStartWave3.Invoke();
                spawnController.StartWave(wave3Count, wave3SpawnDelay);
                break;
            default:
                Debug.Log("Cats and dogs living together.");
                break;
        }
    }

    public void EndWave(bool success)
    {
        if (inWave)
        {
            inWave = false;

            if (success)
            {
                switch (currentWave)
                {
                    case 1:
                        wave1Success.StartAudio();
                        break;
                    case 2:
                        wave2Success.StartAudio();
                        break;
                    case 3:
                        wave3Success.StartAudio();
                        break;
                    default:
                        Debug.Log("Cats and dogs living together.2");
                        break;
                }
            }
            else
            {
                switch (currentWave)
                {
                    case 1:
                        wave1Fail.StartAudio();
                        break;
                    case 2:
                        wave2Fail.StartAudio();
                        break;
                    case 3:
                        wave3Fail.StartAudio();
                        break;
                    default:
                        Debug.Log("Cats and dogs living together.2");
                        break;
                }
            }
        }
    }

    public void FailFade()
    {
        switch (currentWave)
        {
            case 1:
                wave1Fade.Fade(Color.black, 3);
                break;
            case 2:
                wave2Fade.Fade(Color.black, 3);
                break;
            case 3:
                wave3Fade.Fade(Color.black, 3);
                break;
            default:
                Debug.Log("Cats and dogs living together.2");
                break;
        }
    }

    public void EndGame()
    {
        EndFade.Fade(Color.black, 1);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void EnableGuns()
    {

    }

    public void DisableGuns()
    {

    }

    public void RecallAllEnemy()
    {
        foreach (GettingUpAndRunning g in GameObject.FindObjectsOfType<GettingUpAndRunning>())
        {
            g.EnemyGetsUp();
            g.EnemyRunsBack();
        }
    }

    public void DestroyAllEnemy()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("enemy"))
        {
            Destroy(obj);
        }
    }
}
