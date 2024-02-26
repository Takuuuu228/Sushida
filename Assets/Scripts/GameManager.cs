using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance; // GameManagerのインスタンスを格納する変数

    public WordPair[] wordPairs; // インスペクター上で設定可能な単語を保持するための変数

    public static int score = 0; // スコアを格納するための変数

    private ScoreManager scoreManager; // スコアマネージャーへの参照

    // インスタンスを取得する静的メソッド
    public static GameManager Instance
    {
        get
        {
            // GameManagerのインスタンスが存在しない場合は新しく作成する
            if (instance == null)
            {
                // GameManagerのインスタンスを検索する
                instance = FindObjectOfType<GameManager>();

                // GameManagerのインスタンスがまだ存在しない場合はエラーログを出力する
                if (instance == null)
                {
                    Debug.LogError("GameManagerのインスタンスが見つかりませんでした");
                }
            }
            return instance;
        }
    }

    void Start()
    {
        // GameManagerがシーン間で永続的に存在するようにする
        DontDestroyOnLoad(gameObject);

        scoreManager = FindObjectOfType<ScoreManager>(); // ScoreManagerを探して参照を取得する

        // Mainシーンが読み込まれたとき、scoreを0にリセットする
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Mainシーンが読み込まれたときの処理
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Main")
        {
            score = 0; // scoreを0にリセットする
        }
    }

    // 単語とその日本語訳を保持するクラスを定義する
    [System.Serializable]
    public class WordPair
    {
        public string romaji; // ローマ字の単語を保持する変数
        public string japanese; // 日本語の訳を保持する変数
    }

    // TypeManagerからの入力完了通知を受け取るメソッド
    public void NotifyInputComplete()
    {
        score += 100; // スコアに100を加算する
        scoreManager.DisplayScore(score); // スコアをScoreManagerに送る
    }
}
