using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TypeManager : MonoBehaviour
{
    // GameManagerへの参照
    public GameManager gameManager;

    // 仕様に従い、Prefab化した物体を4つ保持する変数
    public GameObject[] prefabObjects = new GameObject[4];

    public Text japaneseText;
    public Text romajiText;

    // ランダムで取得したローマ字と日本語のペアを保持する変数
    private string currentRomaji;
    private string currentJapanese;

    // 現在移動中のGameObjectを保持する変数
    private GameObject currentObject;

    // 現在の移動方向を示す変数
    private int moveDirection = 1; // 1: 右から左へ, -1: 左から右へ

    // タイピング開始時刻を記録する変数
    private float typingStartTime;

    void Start()
    {
        // 最初にランダムな単語を取得してテキストに表示する
        GetRandomWordPair();
        UpdateTextDisplay();

        // タイピング開始時刻を初期化
        typingStartTime = Time.time;

        // 仕様に従い、最初のGameObjectを生成して移動を開始する
        GenerateAndMoveObject();
    }

    void Update()
    {
        // 以下は既存の入力処理と同じです...

        // キーボードからの入力を取得する
        if (Input.anyKeyDown)
        {
            // 入力された文字と現在のローマ字の先頭文字が一致するかチェックする
            if (Input.inputString.Equals(currentRomaji.Substring(0, 1)))
            {
                // 先頭の文字を消去する
                currentRomaji = currentRomaji.Substring(1);
                UpdateTextDisplay(); // テキスト表示を更新する

                // もしローマ字の文字列が空になったら
                if (currentRomaji.Length == 0)
                {
                    // 新しい単語を取得してテキストに表示する
                    GetRandomWordPair();
                    UpdateTextDisplay();
                    NotifyGameManager(); // GameManagerに通知を送る

                    // タイピング開始時刻を初期化
                    typingStartTime = Time.time;

                    // 仕様に従い、GameObjectを生成して移動を開始する
                    GenerateAndMoveObject();
                }
            }
        }

        // タイピング開始から5秒以上経過しているかチェック
        if (Time.time - typingStartTime >= 5 && currentRomaji.Length > 0)
        {
            // 新しい単語を取得してテキストに表示する
            GetRandomWordPair();
            UpdateTextDisplay();

            // タイピング開始時刻を更新
            typingStartTime = Time.time;

            // 仕様に従い、GameObjectを生成して移動を開始する
            GenerateAndMoveObject();
        }
    }

    // ランダムな単語をGameManagerから取得するメソッド
    private void GetRandomWordPair()
    {
        // GameManagerからランダムな単語を取得する
        int randomIndex = Random.Range(0, gameManager.wordPairs.Length);
        currentRomaji = gameManager.wordPairs[randomIndex].romaji;
        currentJapanese = gameManager.wordPairs[randomIndex].japanese;
    }

    // テキスト表示を更新するメソッド
    private void UpdateTextDisplay()
    {
        romajiText.text = currentRomaji; // ローマ字のテキストを更新する
        japaneseText.text = currentJapanese; // 日本語のテキストを更新する
    }

    // GameManagerに通知を送るメソッド
    private void NotifyGameManager()
    {
        gameManager.NotifyInputComplete();
        Debug.Log("入力完了");
    }

    // 仕様に従い、PrefabからGameObjectを生成して移動を開始するメソッド
    private void GenerateAndMoveObject()
    {
        // 現在のGameObjectがあれば削除する
        if (currentObject != null)
            Destroy(currentObject);

        // ランダムなPrefabを選択して生成する
        int randomIndex = Random.Range(0, prefabObjects.Length);
        currentObject = Instantiate(prefabObjects[randomIndex], new Vector3(Random.Range(-9f, 9f), 0f, transform.position.z), Quaternion.identity);

        // 仕様に従い、生成したGameObjectを移動させるコルーチンを開始する
        StartCoroutine(MoveObjectCoroutine(currentObject));
    }

    // 仕様に従い、GameObjectをx座標の-9から9へ移動させるコルーチン
    private IEnumerator MoveObjectCoroutine(GameObject obj)
    {
        float elapsedTime = 0f; // 経過時間の初期化
        Vector3 startPos = new Vector3(-9f, 0f, 0f); // 開始位置
        Vector3 endPos = new Vector3(9f, 0f, 0f); // 終了位置

        // 移動処理
        while (elapsedTime < 5f) // 5秒間移動する
        {
            obj.transform.position = Vector3.Lerp(startPos, endPos, elapsedTime / 5f); // 線形補間で移動
            elapsedTime += Time.deltaTime; // 経過時間の更新
            yield return null; // 1フレーム待機
        }

        obj.transform.position = endPos; // 最終的な位置の確定
    }
}
