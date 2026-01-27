
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;





public class AudioCycle : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<AudioClip> Audio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(AudioPlay());
    }

    // Update is called once per frame
    void Update()
    {
        if (audioSource != null)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.clip = Audio[Random.Range(0, Audio.Count)];
                audioSource.Play();
            }
        }
    }

    IEnumerator AudioPlay()
    {
        yield return new WaitForSeconds(2);

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Audio[Random.Range(0, Audio.Count)];
        audioSource.Play();
        
    }
}
