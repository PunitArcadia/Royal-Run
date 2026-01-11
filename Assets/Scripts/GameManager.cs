using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreUI;
    [SerializeField] TMP_Text coinUI;
    [SerializeField] TMP_Text lifeUI;
    [SerializeField] Image red;
    [SerializeField] GameObject GameOverUI;

    [SerializeField] float scoreFactor;

    float score = 0;
    int coin = 0;
    int life = 3;

    private void Update()
    {
        score = Time.time * scoreFactor;
        scoreUI.text = ((int)score).ToString();

        if (life <= 0)
        {
            GameOverUI.SetActive(true);
        }
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
    }
}
