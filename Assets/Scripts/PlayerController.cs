using NUnit.Framework;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;

public class PlayerController : MonoBehaviour
{
    [SerializeField] List<Texture2D> DieFaces;
    [SerializeField] RawImage DieFace;
    [SerializeField] BoardPositions GetBoardPositions;
    [SerializeField] List<PlayerPiece> AllPlayerPieces;

    public PlayerController(string ID)
    {
        PlayerId = ID;
    }


    internal string PlayerId = string.Empty;
    internal Transform playerTransform;
    internal PlayerPiece playerPiece;
    internal int playerNumber = 1;
    internal bool hasRolled = false;
    internal bool hasWon = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("Init", 0.1f);
    }
    // Update is called once per frame

    private void Init()
    {

        playerTransform = GetBoardPositions.AllPositions[0];
        playerPiece = AllPlayerPieces[0];
        Instantiate(playerPiece, playerTransform);
    }
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
        if (GetBoardPositions)
        {
            int currentPosIndex = GetBoardPositions.AllPositions.IndexOf(playerTransform);
            currentPosIndex += RollDie();

            //If we are at or past the final index, set win. Prevents index out of range
            if (currentPosIndex >= GetBoardPositions.AllPositions.Count)
            {
                hasWon = true;
            }
            //Else, we are still playing and have a space we can move too
            else
            {
                playerTransform = GetBoardPositions.AllPositions[currentPosIndex];
                playerPiece = AllPlayerPieces[playerNumber - 1];
                playerPiece.transform.position = playerTransform.position;

                Invoke("CheckTile(currentPosIndex)", 2);

                playerTransform = GetBoardPositions.AllPositions[currentPosIndex];
                playerPiece = AllPlayerPieces[playerNumber - 1];
                playerPiece.transform.position = playerTransform.position;
            }
        }
    }
    private void CheckTile(int index)
    {
        foreach (var coords in GetBoardPositions.TileCoordinates)
        {
            string tileType = "";
            if (index == coords.Key)
            {
                switch (tileType)
                {
                    case "ES_Base":
                        index = 15;
                        break;
                    case "EL_Tail":
                        index = 2;
                        break;
                }


            }
        }
    }
}
