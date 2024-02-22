using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TypeManager : MonoBehaviour
{
    public Text nameDisplay;
    public Text stringsDisplay; // 単語を表示するためのテキストUI
    private List<GameManager.WordPair> wordPairs = new List<GameManager.WordPair>(); // GameManagerから受け取った単語

    void Start()
    {
        // GameManagerからWordPairを受け取る
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null && gameManager.wordPairGroups.Length > 0)
        {
            // GameManagerからランダムなWordPairを取得し、リストに追加する
            List<GameManager.WordPair> availablePairs = new List<GameManager.WordPair>(gameManager.wordPairGroups[0].wordPairs);
            for (int i = 0; i < Mathf.Min(3, availablePairs.Count); i++)
            {
                int randomIndex = Random.Range(0, availablePairs.Count);
                wordPairs.Add(availablePairs[randomIndex]);
                availablePairs.RemoveAt(randomIndex);
            }
        }

        // 受け取ったWordPairをテキストで表示する
        DisplayWordPairs();
    }

    // 受け取ったWordPairをテキストで表示するメソッド
    private void DisplayWordPairs()
    {
        string nameText = "";
        string stringsText = "";
        foreach (var wordPair in wordPairs)
        {
            nameText += wordPair.japanese + "\n";
            stringsText += wordPair.romaji + "\n";
        }
        nameDisplay.text = nameText;
        stringsDisplay.text = stringsText;
    }
}
