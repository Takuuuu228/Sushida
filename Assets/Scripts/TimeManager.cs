using UnityEngine;
using UnityEngine.UI; // UnityのUI機能を使用するために必要
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    public float timeRemaining = 60f; // 制限時間を表す変数を宣言し、初期値を60秒に設定する
    public Text countdownText; // カウントダウンを表示するテキストオブジェクトを宣言する

    void Update()
    {
        // 残り時間を更新し、時間をカウントダウンする
        timeRemaining -= Time.deltaTime;

        // 残り時間をテキストで表示する
        countdownText.text = "残り時間: " + Mathf.Round(timeRemaining).ToString(); // 残り時間を整数に変換し、テキストに反映する

        // 残り時間が0以下になった場合、Resultシーンに遷移する
        if (timeRemaining <= 0)
        {
            // シーンマネージャーを使用してResultシーンに遷移する
            SceneManager.LoadScene("Result");
        }
    }
}
