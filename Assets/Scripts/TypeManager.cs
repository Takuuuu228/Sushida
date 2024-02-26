using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TypeManager : MonoBehaviour
{
    // GameManager�ւ̎Q��
    public GameManager gameManager;

    // �d�l�ɏ]���APrefab���������̂�4�ێ�����ϐ�
    public GameObject[] prefabObjects = new GameObject[4];

    public Text japaneseText;
    public Text romajiText;

    // �����_���Ŏ擾�������[�}���Ɠ��{��̃y�A��ێ�����ϐ�
    private string currentRomaji;
    private string currentJapanese;

    // ���݈ړ�����GameObject��ێ�����ϐ�
    private GameObject currentObject;

    // ���݂̈ړ������������ϐ�
    private int moveDirection = 1; // 1: �E���獶��, -1: ������E��

    // �^�C�s���O�J�n�������L�^����ϐ�
    private float typingStartTime;

    void Start()
    {
        // �ŏ��Ƀ����_���ȒP����擾���ăe�L�X�g�ɕ\������
        GetRandomWordPair();
        UpdateTextDisplay();

        // �^�C�s���O�J�n������������
        typingStartTime = Time.time;

        // �d�l�ɏ]���A�ŏ���GameObject�𐶐����Ĉړ����J�n����
        GenerateAndMoveObject();
    }

    void Update()
    {
        // �ȉ��͊����̓��͏����Ɠ����ł�...

        // �L�[�{�[�h����̓��͂��擾����
        if (Input.anyKeyDown)
        {
            // ���͂��ꂽ�����ƌ��݂̃��[�}���̐擪��������v���邩�`�F�b�N����
            if (Input.inputString.Equals(currentRomaji.Substring(0, 1)))
            {
                // �擪�̕�������������
                currentRomaji = currentRomaji.Substring(1);
                UpdateTextDisplay(); // �e�L�X�g�\�����X�V����

                // �������[�}���̕����񂪋�ɂȂ�����
                if (currentRomaji.Length == 0)
                {
                    // �V�����P����擾���ăe�L�X�g�ɕ\������
                    GetRandomWordPair();
                    UpdateTextDisplay();
                    NotifyGameManager(); // GameManager�ɒʒm�𑗂�

                    // �^�C�s���O�J�n������������
                    typingStartTime = Time.time;

                    // �d�l�ɏ]���AGameObject�𐶐����Ĉړ����J�n����
                    GenerateAndMoveObject();
                }
            }
        }

        // �^�C�s���O�J�n����5�b�ȏ�o�߂��Ă��邩�`�F�b�N
        if (Time.time - typingStartTime >= 5 && currentRomaji.Length > 0)
        {
            // �V�����P����擾���ăe�L�X�g�ɕ\������
            GetRandomWordPair();
            UpdateTextDisplay();

            // �^�C�s���O�J�n�������X�V
            typingStartTime = Time.time;

            // �d�l�ɏ]���AGameObject�𐶐����Ĉړ����J�n����
            GenerateAndMoveObject();
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

    // GameManager�ɒʒm�𑗂郁�\�b�h
    private void NotifyGameManager()
    {
        gameManager.NotifyInputComplete();
        Debug.Log("���͊���");
    }

    // �d�l�ɏ]���APrefab����GameObject�𐶐����Ĉړ����J�n���郁�\�b�h
    private void GenerateAndMoveObject()
    {
        // ���݂�GameObject������΍폜����
        if (currentObject != null)
            Destroy(currentObject);

        // �����_����Prefab��I�����Đ�������
        int randomIndex = Random.Range(0, prefabObjects.Length);
        currentObject = Instantiate(prefabObjects[randomIndex], new Vector3(Random.Range(-9f, 9f), 0f, transform.position.z), Quaternion.identity);

        // �d�l�ɏ]���A��������GameObject���ړ�������R���[�`�����J�n����
        StartCoroutine(MoveObjectCoroutine(currentObject));
    }

    // �d�l�ɏ]���AGameObject��x���W��-9����9�ֈړ�������R���[�`��
    private IEnumerator MoveObjectCoroutine(GameObject obj)
    {
        float elapsedTime = 0f; // �o�ߎ��Ԃ̏�����
        Vector3 startPos = new Vector3(-9f, 0f, 0f); // �J�n�ʒu
        Vector3 endPos = new Vector3(9f, 0f, 0f); // �I���ʒu

        // �ړ�����
        while (elapsedTime < 5f) // 5�b�Ԉړ�����
        {
            obj.transform.position = Vector3.Lerp(startPos, endPos, elapsedTime / 5f); // ���`��Ԃňړ�
            elapsedTime += Time.deltaTime; // �o�ߎ��Ԃ̍X�V
            yield return null; // 1�t���[���ҋ@
        }

        obj.transform.position = endPos; // �ŏI�I�Ȉʒu�̊m��
    }
}
