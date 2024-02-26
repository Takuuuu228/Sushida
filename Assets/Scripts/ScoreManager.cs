// ScoreManager.cs

using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; // �X�R�A��\������e�L�X�gUI

    private void Start()
    {
        DisplayScore(GameManager.score);
    }

    // �X�R�A��\�����郁�\�b�h
    public void DisplayScore(int score)
    {
        scoreText.text = "Score: " + score.ToString(); // �X�R�A��\������
    }
}
