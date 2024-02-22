using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TypeManager : MonoBehaviour
{
    public Text nameDisplay;
    public Text stringsDisplay; // �P���\�����邽�߂̃e�L�X�gUI
    private List<GameManager.WordPair> wordPairs = new List<GameManager.WordPair>(); // GameManager����󂯎�����P��

    void Start()
    {
        // GameManager����WordPair���󂯎��
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null && gameManager.wordPairGroups.Length > 0)
        {
            // GameManager���烉���_����WordPair���擾���A���X�g�ɒǉ�����
            List<GameManager.WordPair> availablePairs = new List<GameManager.WordPair>(gameManager.wordPairGroups[0].wordPairs);
            for (int i = 0; i < Mathf.Min(3, availablePairs.Count); i++)
            {
                int randomIndex = Random.Range(0, availablePairs.Count);
                wordPairs.Add(availablePairs[randomIndex]);
                availablePairs.RemoveAt(randomIndex);
            }
        }

        // �󂯎����WordPair���e�L�X�g�ŕ\������
        DisplayWordPairs();
    }

    // �󂯎����WordPair���e�L�X�g�ŕ\�����郁�\�b�h
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
