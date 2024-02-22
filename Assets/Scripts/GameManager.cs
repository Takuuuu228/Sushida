using UnityEngine;
using UnityEditor; // UnityEditorを使用するために必要

public class GameManager : MonoBehaviour
{
    // インスペクター上で設定可能な単語を保持するための変数を定義する
    public WordPairGroup[] wordPairGroups;
    public int magnification;

    private int score = 0; // スコアを格納するための変数を定義する

    void Start()
    {
        // スコアを計算する
        CalculateScore();
    }

    // スコアを計算するメソッド
    private void CalculateScore()
    {
        // 各単語グループの文字数に応じてスコアを加算する
        foreach (var group in wordPairGroups)
        {
            foreach (var pair in group.wordPairs)
            {
                score += pair.japanese.Length * magnification; // ローマ字と日本語の文字数を加算する
            }
        }
    }

    // 単語とその日本語訳を保持するクラスを定義する
    [System.Serializable]
    public class WordPair
    {
        public string romaji; // ローマ字の単語を保持する変数
        public string japanese; // 日本語の訳を保持する変数
    }

    // 単語グループを保持するクラスを定義する
    [System.Serializable]
    public class WordPairGroup
    {
        public WordPair[] wordPairs; // 単語とその日本語訳を保持する配列
    }
}
