using NUnit.Framework;
using TMPro;
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Unity.Multiplayer.PlayMode;


public class PlayerData
{
    internal string Name;
    internal int Number;
    internal Transform Position;
    internal PlayerPiece PlayerPiece;
}

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject MainMenuPanel;
    [SerializeField] GameObject GameAssignmentPanel;
    [SerializeField] GameObject PlayerUIPanel;
    [SerializeField] GameObject Player;
    [SerializeField] TMP_InputField InputUI;
    [SerializeField] UIManager UI;

    internal PlayerController currentPlayer;
    private int currentPlayerIndex;
    private List<PlayerData> players = new List<PlayerData>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPlayer && currentPlayer.hasRolled)
        {
            currentPlayer.hasRolled = false;
            currentPlayerIndex++;
            if (currentPlayerIndex >= players.Count) currentPlayerIndex = 0;
            StartTurn();
        }
    }

    public void AssignPlayers()
    {
        if (string.IsNullOrEmpty(InputUI.text))
        {
            //If players is not between 2-6, stop game
            if (players.Count < 2 || players.Count > 6)
            {
                EndGame();
            }
            else
            {
                StartTurn();
                GameAssignmentPanel.SetActive(false);
            }
        }
        else
        {
            Debug.Log(InputUI.text);
            players.Add(new PlayerData { Name = InputUI.text, Number = players.Count + 1});
            InputUI.text = "";
            Debug.Log($"Added player. Total players: {players.Count}");
        }
    }


    public void StartTurn()
    {
        currentPlayer = Player.GetComponent<PlayerController>();
        PlayerData current = players[currentPlayerIndex];
        currentPlayer.PlayerId = current.Name;
        currentPlayer.playerTransform = current.Position;
        currentPlayer.playerPiece = current.PlayerPiece;
        currentPlayer.playerNumber = current.Number;
        PlayerUIPanel.SetActive(true);
        UI.ShowTurn(currentPlayer);

    }

    public void StartGame()
    {
        MainMenuPanel.SetActive(false);
        GameAssignmentPanel.SetActive(true);
    }
    public void EndGame()
    {
        UnityEditor.EditorApplication.ExitPlaymode();
        Application.Quit();
    }
}
