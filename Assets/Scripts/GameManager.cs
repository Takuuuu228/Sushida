using UnityEngine;
using UnityEditor; // UnityEditor���g�p���邽�߂ɕK�v

public class GameManager : MonoBehaviour
{
    // �C���X�y�N�^�[��Őݒ�\�ȒP���ێ����邽�߂̕ϐ����`����
    public WordPairGroup[] wordPairGroups;
    public int magnification;

    private int score = 0; // �X�R�A���i�[���邽�߂̕ϐ����`����

    void Start()
    {
        // �X�R�A���v�Z����
        CalculateScore();
    }

    // �X�R�A���v�Z���郁�\�b�h
    private void CalculateScore()
    {
        // �e�P��O���[�v�̕������ɉ����ăX�R�A�����Z����
        foreach (var group in wordPairGroups)
        {
            foreach (var pair in group.wordPairs)
            {
                score += pair.japanese.Length * magnification; // ���[�}���Ɠ��{��̕����������Z����
            }
        }
    }

    // �P��Ƃ��̓��{����ێ�����N���X���`����
    [System.Serializable]
    public class WordPair
    {
        public string romaji; // ���[�}���̒P���ێ�����ϐ�
        public string japanese; // ���{��̖��ێ�����ϐ�
    }

    // �P��O���[�v��ێ�����N���X���`����
    [System.Serializable]
    public class WordPairGroup
    {
        public WordPair[] wordPairs; // �P��Ƃ��̓��{����ێ�����z��
    }
}
