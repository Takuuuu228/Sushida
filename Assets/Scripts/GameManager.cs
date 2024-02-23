using UnityEngine;
using UnityEditor; // UnityEditorを使用するために必要

public class GameManager : MonoBehaviour
{
    // インスペクター上で設定可能な単語を保持するための変数を定義する
    public WordPair[] wordPairs;

    private int score = 0; // スコアを格納するための変数を定義する

    void Start()
    {

    }

    // 単語とその日本語訳を保持するクラスを定義する
    [System.Serializable]
    public class WordPair
    {
        public string romaji; // ローマ字の単語を保持する変数
        public string japanese; // 日本語の訳を保持する変数
    }
}