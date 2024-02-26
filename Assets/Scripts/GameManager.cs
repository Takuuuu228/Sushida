using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance; // GameManager�̃C���X�^���X���i�[����ϐ�

    public WordPair[] wordPairs; // �C���X�y�N�^�[��Őݒ�\�ȒP���ێ����邽�߂̕ϐ�

    public static int score = 0; // �X�R�A���i�[���邽�߂̕ϐ�

    private ScoreManager scoreManager; // �X�R�A�}�l�[�W���[�ւ̎Q��

    // �C���X�^���X���擾����ÓI���\�b�h
    public static GameManager Instance
    {
        get
        {
            // GameManager�̃C���X�^���X�����݂��Ȃ��ꍇ�͐V�����쐬����
            if (instance == null)
            {
                // GameManager�̃C���X�^���X����������
                instance = FindObjectOfType<GameManager>();

                // GameManager�̃C���X�^���X���܂����݂��Ȃ��ꍇ�̓G���[���O���o�͂���
                if (instance == null)
                {
                    Debug.LogError("GameManager�̃C���X�^���X��������܂���ł���");
                }
            }
            return instance;
        }
    }

    void Start()
    {
        // GameManager���V�[���Ԃŉi���I�ɑ��݂���悤�ɂ���
        DontDestroyOnLoad(gameObject);

        scoreManager = FindObjectOfType<ScoreManager>(); // ScoreManager��T���ĎQ�Ƃ��擾����

        // Main�V�[�����ǂݍ��܂ꂽ�Ƃ��Ascore��0�Ƀ��Z�b�g����
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Main�V�[�����ǂݍ��܂ꂽ�Ƃ��̏���
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Main")
        {
            score = 0; // score��0�Ƀ��Z�b�g����
        }
    }

    // �P��Ƃ��̓��{����ێ�����N���X���`����
    [System.Serializable]
    public class WordPair
    {
        public string romaji; // ���[�}���̒P���ێ�����ϐ�
        public string japanese; // ���{��̖��ێ�����ϐ�
    }

    // TypeManager����̓��͊����ʒm���󂯎�郁�\�b�h
    public void NotifyInputComplete()
    {
        score += 100; // �X�R�A��100�����Z����
        scoreManager.DisplayScore(score); // �X�R�A��ScoreManager�ɑ���
    }
}
