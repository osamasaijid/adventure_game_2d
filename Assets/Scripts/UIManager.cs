using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject winPanel;
    public GameObject losePanel;

    private void Start()
    {
        GameManager.Instance.GameEnded += ShowGameEndResult;
    }

    public void ShowGameEndResult(bool isWon)
    {
        if (isWon)
        {
            winPanel.SetActive(true);
        }
        else
        {
            losePanel.SetActive(true);
        }
    }

    public void PlayAgain()
    {
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        GameManager.Instance.StartGame();
    }
}
