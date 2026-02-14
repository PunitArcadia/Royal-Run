using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Playing,
        GameOver
    }

    [Header("UI References")]
    [SerializeField] private TMP_Text scoreUI;
    [SerializeField] private TMP_Text coinUI;
    [SerializeField] private TMP_Text lifeUI;
    [SerializeField] private GameObject gameOverUI;

    [Header("Score Settings")]
    [SerializeField] private float scoreFactor = 10f;

    private GameState currentState = GameState.Playing;

    private float score = 0;
    private int coin = 0;
    private int life = 3;

    public bool IsGameActive => currentState == GameState.Playing;

    private void Update()
    {
        if (!IsGameActive) return;

        score += Time.deltaTime * scoreFactor;
        scoreUI.text = ((int)score).ToString();
    }

    public void ChangeCoin(int amount)
    {
        coin += amount;
        coinUI.text = coin.ToString();
    }

    public void ChangeLife(int amount)
    {
        life += amount;
        lifeUI.text = life.ToString();

        if (life <= 0)
        {
            TriggerGameOver();
        }
    }

    private void TriggerGameOver()
    {
        if (currentState == GameState.GameOver) return;

        currentState = GameState.GameOver;
        gameOverUI.SetActive(true);
    }
}
