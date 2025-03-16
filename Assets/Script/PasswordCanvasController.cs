using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

//�p�X���[�h���͗p�̃L�����o�X�������N���X
public class PasswordCanvasController : MonoBehaviour
{
    private bool isOpened = false;

    private Animator desk;

    public AudioSource openSound;
    public AudioSource closeSound;

    [SerializeField] GameObject cube;
    [SerializeField] GameObject fieldObj;
    private InputField inputField;

    void Start()
    {
        // �L�����o�X���\���ɂ���
        gameObject.SetActive(false);

        // GameObject.Find �̌��ʂ� null �`�F�b�N
        fieldObj = GameObject.Find("InputField");
        if (fieldObj != null)
        {
            inputField = fieldObj.GetComponent<InputField>();
        }
        else
        {
            Debug.LogError("InputField �I�u�W�F�N�g��������܂���B");
        }

        cube = GameObject.Find("Torus.003");
        if (cube != null)
        {
            desk = cube.GetComponent<Animator>();
        }
        else
        {
            Debug.LogError("Torus.003 �I�u�W�F�N�g��������܂���B");
        }

        // Animator �R���|�[�l���g���A�^�b�`����Ă��邩�`�F�b�N
        desk = GetComponent<Animator>();
        if (desk == null)
        {
            Debug.LogError("Animator �R���|�[�l���g���A�^�b�`����Ă��܂���B");
        }
    }

    public void InputText()
    {
        // inputField �� null �łȂ����Ƃ��m�F
        if (inputField != null)
        {
            if (inputField.text == "MARCH" || inputField.text == "march")
            {
                // desk �� null �łȂ����Ƃ��m�F
                if (desk != null)
                {
                    desk.SetTrigger("OpenTrigger");
                }
                if (openSound != null)
                {
                    openSound.Play();
                }
            }
        }
        else
        {
            Debug.LogError("InputField ������������Ă��܂���B");
        }
    }

    // �N���b�N�C�x���g�ŃL�����o�X��\������֐�
    public void ShowPasswordCanvas()
    {
        gameObject.SetActive(true);
    }
}