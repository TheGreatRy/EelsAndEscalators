using TMPro;

using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI PlayerOneText;
    [SerializeField] TextMeshProUGUI PlayerTwoText;
    [SerializeField] TextMeshProUGUI PlayerThreeText;
    [SerializeField] TextMeshProUGUI PlayerFourText;
    [SerializeField] TextMeshProUGUI PlayerFiveText;
    [SerializeField] TextMeshProUGUI PlayerSixText;
    [SerializeField] TextMeshProUGUI CurrentPlayerText;
    [SerializeField] TextMeshProUGUI CurrentPlayer;
    [SerializeField] GameManager gameManager;

    

    private TextMeshProUGUI[] playerTexts;
    private Color normalColor = Color.white;
    private Color activeColor = Color.cyan; // Or new Color(0, 1, 1) for cyan

   

    void Start()
    {
        
        // Store references in an array for easy access
        playerTexts = new TextMeshProUGUI[]
        {
            PlayerOneText, PlayerTwoText, PlayerThreeText,
            PlayerFourText, PlayerFiveText, PlayerSixText
        };
    }

    internal void ShowTurn(PlayerController player)
    {
        CurrentPlayer.text = gameManager.currentPlayer.PlayerId;
        // Reset all colors to normal
        foreach (var text in playerTexts)
        {
            if (text != null)
                text.color = normalColor;
        }

        // Highlight current player
        int index = player.playerNumber - 1; // Convert to 0-based index
        if (index >= 0 && index < playerTexts.Length && playerTexts[index] != null)
        {
            playerTexts[index].text = player.PlayerId + ": " + player.playerTransform;
            playerTexts[index].color = activeColor;
        }

        CurrentPlayerText.text = player.PlayerId;
    }

    // Optional: Update a specific player's text without changing turn
    internal void UpdatePlayerPosition(int playerNumber, string playerId, int position)
    {
        int index = playerNumber - 1;
        if (index >= 0 && index < playerTexts.Length && playerTexts[index] != null)
        {
            playerTexts[index].text = playerId + " " + position;
        }
    }
}