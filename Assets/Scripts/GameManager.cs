using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreUI;
    [SerializeField] TMP_Text coinUI;
    [SerializeField] float scoreFactor;
    float score = 0;
    int coin = 0;
    private void Update()
    {
        score = Time.time * scoreFactor;
        scoreUI.text = ((int)score).ToString();
    }

    public void ChangeCoin(int amount)
    {
        coin += amount;
        coinUI.text = coin.ToString();
    }
}
