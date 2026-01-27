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
    [SerializeField] BoardPositions GetBoardPositions;

    public PlayerController(string ID)
    {
        PlayerId = ID;
    }


    internal string PlayerId = string.Empty;
    internal Transform position;
    internal int playerNumber = 1;
    internal bool hasRolled = false;
    internal bool hasWon = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        position = GetBoardPositions.AllPositions[0];
    }
    // Update is called once per frame
    void Update()
    {

    }

    public int RollDie()
    {
        int result = UnityEngine.Random.Range(1, DieFaces.Count + 1);
        StartCoroutine(RollDieAnimation(result));
        Debug.Log(result);
        hasRolled = true;
        
        return result; 
    }

    private IEnumerator RollDieAnimation(int finalResult)
    {
        //Only play animation once
        if (!hasRolled)
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
    }

    public void Move()
    {
        //Find our current board position and update it
        int currentPosIndex = GetBoardPositions.AllPositions.IndexOf(position);
        currentPosIndex += RollDie();

        //If we are at or past the final index, set win. Prevents index out of range
        if (currentPosIndex >= GetBoardPositions.AllPositions.Count)
        {
            hasWon = true;
        }
        //Else, we are still playing and have a space we can move too
        else
        {
            position = GetBoardPositions.AllPositions[currentPosIndex];
        }

    }

   

}
