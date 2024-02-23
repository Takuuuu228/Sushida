using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TypeManager : MonoBehaviour
{
    public Text nameDisplay;
    public Text stringsDisplay;
    private List<GameManager.WordPair> wordPairs = new List<GameManager.WordPair>();
    private string currentRomaji = ""; // 現在入力中のローマ字文字列を保持する変数

    void Start()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null && gameManager.wordPairGroups.Length > 0)
        {
            List<GameManager.WordPair> availablePairs = new List<GameManager.WordPair>(gameManager.wordPairGroups[0].wordPairs);
            for (int i = 0; i < Mathf.Min(3, availablePairs.Count); i++)
            {
                int randomIndex = Random.Range(0, availablePairs.Count);
                wordPairs.Add(availablePairs[randomIndex]);
                availablePairs.RemoveAt(randomIndex);
            }
        }

        DisplayWordPairs();
    }

    void Update()
    {
        // キーボードからの入力を監視する
        if (Input.anyKeyDown)
        {
            // 入力された文字を取得
            string input = Input.inputString;

            // 現在のローマ字文字列との比較
            if (wordPairs.Count > 0 && wordPairs[0].romaji.StartsWith(input))
            {
                // 入力された文字列がローマ字文字列の先頭と一致する場合、ローマ字文字列の先頭1文字を削除
                wordPairs[0].romaji = wordPairs[0].romaji.Remove(0, 1);
            }

            // テキスト表示を更新
            DisplayWordPairs();
        }
    }

    private void DisplayWordPairs()
    {
        string nameText = "";
        string stringsText = "";
        foreach (var wordPair in wordPairs)
        {
            nameText += wordPair.japanese + "\n";
            stringsText += wordPair.romaji + "\n"; // ローマ字文字列のみを表示
        }
        nameDisplay.text = nameText;
        stringsDisplay.text = stringsText;
    }
}
