// ScoreManager.cs

using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; // スコアを表示するテキストUI

    private void Start()
    {
        DisplayScore(GameManager.score);
    }

    // スコアを表示するメソッド
    public void DisplayScore(int score)
    {
        scoreText.text = "Score: " + score.ToString(); // スコアを表示する
    }
}
