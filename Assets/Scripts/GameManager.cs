using UnityEngine;
using UnityEditor; // UnityEditor���g�p���邽�߂ɕK�v

public class GameManager : MonoBehaviour
{
    // �C���X�y�N�^�[��Őݒ�\�ȒP���ێ����邽�߂̕ϐ����`����
    public WordPair[] wordPairs;

    private int score = 0; // �X�R�A���i�[���邽�߂̕ϐ����`����

    void Start()
    {

    }

    // �P��Ƃ��̓��{����ێ�����N���X���`����
    [System.Serializable]
    public class WordPair
    {
        public string romaji; // ���[�}���̒P���ێ�����ϐ�
        public string japanese; // ���{��̖��ێ�����ϐ�
    }
}