using UnityEngine;
using UnityEngine.UI;

public class TypeManager : MonoBehaviour
{
    // GameManagerへの参照
    public GameManager gameManager;

    public Text japaneseText;
    public Text romajiText;

    // ランダムで取得したローマ字と日本語のペアを保持する変数
    private string currentRomaji;
    private string currentJapanese;

    void Start()
    {
        // 最初にランダムな単語を取得してテキストに表示する
        GetRandomWordPair();
        UpdateTextDisplay();
    }

    void Update()
    {
        // キーボードからの入力を取得する
        if (Input.anyKeyDown)
        {
            // 入力された文字と現在のローマ字の先頭文字が一致するかチェックする
            if (Input.inputString.Equals(currentRomaji.Substring(0, 1)))
            {
                // 先頭の文字を消去する
                currentRomaji = currentRomaji.Substring(1);
                UpdateTextDisplay(); // テキスト表示を更新する
            }

            // もしローマ字の文字列が空になったら
            if (currentRomaji.Length == 0)
            {
                // 新しい単語を取得してテキストに表示する
                GetRandomWordPair();
                UpdateTextDisplay();
            }
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
}
