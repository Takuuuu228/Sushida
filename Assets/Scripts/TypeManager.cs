using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TypeManager : MonoBehaviour
{
    public Text nameDisplay;
    public Text stringsDisplay;
    private List<GameManager.WordPair> wordPairs = new List<GameManager.WordPair>();
    private string currentRomaji = ""; // ���ݓ��͒��̃��[�}���������ێ�����ϐ�

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
        // �L�[�{�[�h����̓��͂��Ď�����
        if (Input.anyKeyDown)
        {
            // ���͂��ꂽ�������擾
            string input = Input.inputString;

            // ���݂̃��[�}��������Ƃ̔�r
            if (wordPairs.Count > 0 && wordPairs[0].romaji.StartsWith(input))
            {
                // ���͂��ꂽ�����񂪃��[�}��������̐擪�ƈ�v����ꍇ�A���[�}��������̐擪1�������폜
                wordPairs[0].romaji = wordPairs[0].romaji.Remove(0, 1);
            }

            // �e�L�X�g�\�����X�V
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
            stringsText += wordPair.romaji + "\n"; // ���[�}��������݂̂�\��
        }
        nameDisplay.text = nameText;
        stringsDisplay.text = stringsText;
    }
}
