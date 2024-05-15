using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    [SerializeField] private AudioClip[] jumpSoundsClips;
    [SerializeField] private AudioClip soundClip;
    private AudioSource soundSource;
    private int lastPlayedIndex;


    private  void Start()
    {
        soundSource = GetComponent<AudioSource>();
    }

    public void PlayJumpSound()
    {
        if (soundSource != null && jumpSoundsClips != null && jumpSoundsClips.Length > 0)
        {
            int randomIndex = GetRandomNonRepeatingIndex(jumpSoundsClips.Length);
            soundSource.clip = jumpSoundsClips[randomIndex];
            soundSource.Play();
            lastPlayedIndex = randomIndex;
        }
    }

    int GetRandomNonRepeatingIndex(int leng)
    {
        int randomIndex = Random.Range(0, leng);
        while (randomIndex == lastPlayedIndex)
        {
            randomIndex = Random.Range(0, leng);
        }
        return randomIndex;
    }
}

