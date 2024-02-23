using UnityEngine;
using UnityEngine.UI;

public class TypeManager : MonoBehaviour
{
    // GameManager�ւ̎Q��
    public GameManager gameManager;

    public Text japaneseText;
    public Text romajiText;

    // �����_���Ŏ擾�������[�}���Ɠ��{��̃y�A��ێ�����ϐ�
    private string currentRomaji;
    private string currentJapanese;

    void Start()
    {
        // �ŏ��Ƀ����_���ȒP����擾���ăe�L�X�g�ɕ\������
        GetRandomWordPair();
        UpdateTextDisplay();
    }

    void Update()
    {
        // �L�[�{�[�h����̓��͂��擾����
        if (Input.anyKeyDown)
        {
            // ���͂��ꂽ�����ƌ��݂̃��[�}���̐擪��������v���邩�`�F�b�N����
            if (Input.inputString.Equals(currentRomaji.Substring(0, 1)))
            {
                // �擪�̕�������������
                currentRomaji = currentRomaji.Substring(1);
                UpdateTextDisplay(); // �e�L�X�g�\�����X�V����
            }

            // �������[�}���̕����񂪋�ɂȂ�����
            if (currentRomaji.Length == 0)
            {
                // �V�����P����擾���ăe�L�X�g�ɕ\������
                GetRandomWordPair();
                UpdateTextDisplay();
            }
        }
    }

    // �����_���ȒP���GameManager����擾���郁�\�b�h
    private void GetRandomWordPair()
    {
        // GameManager���烉���_���ȒP����擾����
        int randomIndex = Random.Range(0, gameManager.wordPairs.Length);
        currentRomaji = gameManager.wordPairs[randomIndex].romaji;
        currentJapanese = gameManager.wordPairs[randomIndex].japanese;
    }

    // �e�L�X�g�\�����X�V���郁�\�b�h
    private void UpdateTextDisplay()
    {
        romajiText.text = currentRomaji; // ���[�}���̃e�L�X�g���X�V����
        japaneseText.text = currentJapanese; // ���{��̃e�L�X�g���X�V����
    }
}
