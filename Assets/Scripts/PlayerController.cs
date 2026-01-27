using NUnit.Framework;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] List<Texture2D> DieFaces;
    [SerializeField] RawImage DieFace;
    
    public PlayerController(string ID)
    {
        PlayerId = ID;
    }


    internal string PlayerId = string.Empty;
    internal int position = 0;
    internal int playerNumber = 1;

    public int RollDie()
    {
        int result = UnityEngine.Random.Range(1, DieFaces.Count + 1);
        StartCoroutine(RollDieAnimation(result));
        Debug.Log(result);
        return result; 
    }

    private IEnumerator RollDieAnimation(int finalResult)
    {
        int randomCycle = UnityEngine.Random.Range(10, 20);
        float initialDelay = 0.05f;
        float delayIncrement = 0.02f;

        for (int i = 0; i < randomCycle; i++)
        {
            int faceIndex = i % DieFaces.Count;
            DieFace.texture = DieFaces[faceIndex];

            float delay = initialDelay + (delayIncrement * i);
            yield return new WaitForSeconds(delay);
        }

        DieFace.texture = DieFaces[finalResult - 1];
    }

    public void Move()
    {
        position += RollDie();

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

}
