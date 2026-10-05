using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomSounds : MonoBehaviour
{
    [SerializeField] private List<AudioClip> sounds;
    private AudioSource audioSource;
    [SerializeField] private float minDelay = 3f;
    [SerializeField] private float maxDelay = 8f;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        StartCoroutine(PlayRandomSounds());
    }

    private IEnumerator PlayRandomSounds()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
            int soundIndex = Random.Range(0, sounds.Count);
            audioSource.PlayOneShot(sounds[soundIndex]);
        }
    }
}
