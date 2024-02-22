using UnityEngine;
using UnityEngine.UI; // Unity��UI�@�\���g�p���邽�߂ɕK�v
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    public float timeRemaining = 60f; // �������Ԃ�\���ϐ���錾���A�����l��60�b�ɐݒ肷��
    public Text countdownText; // �J�E���g�_�E����\������e�L�X�g�I�u�W�F�N�g��錾����

    void Update()
    {
        // �c�莞�Ԃ��X�V���A���Ԃ��J�E���g�_�E������
        timeRemaining -= Time.deltaTime;

        // �c�莞�Ԃ��e�L�X�g�ŕ\������
        countdownText.text = "�c�莞��: " + Mathf.Round(timeRemaining).ToString(); // �c�莞�Ԃ𐮐��ɕϊ����A�e�L�X�g�ɔ��f����

        // �c�莞�Ԃ�0�ȉ��ɂȂ����ꍇ�AResult�V�[���ɑJ�ڂ���
        if (timeRemaining <= 0)
        {
            // �V�[���}�l�[�W���[���g�p����Result�V�[���ɑJ�ڂ���
            SceneManager.LoadScene("Result");
        }
    }
}
