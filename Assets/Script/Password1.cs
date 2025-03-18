using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Password1 : MonoBehaviour
{
    // �{�^���ɕ\�����镶��
    public string chars = "JHAQMKRC";

    // �{�^���̃e�L�X�g���Ǘ�����z��
    public Text[] texts;

    // �e�{�^�������݂ǂ̕�����\�����Ă��邩���Ǘ�����z��
    public string[] nows;

    public string Answer;

    public UnityEvent OnCorrect;
    public AudioSource audioSource;

    private bool isAnimationPlaying = false;
    public GameObject targetObject;

    void Start()
    {
        nows = new string[texts.Length];
        for (int i = 0; i < texts.Length; i++)
        {
            nows[i] = chars[0].ToString(); // �ŏ��̕�����ݒ�
            texts[i].text = nows[i]; // �e�L�X�g���X�V
        }
    }

    public void ChangeText(int n)
    {
        int currentIndex = chars.IndexOf(nows[n]);

        // ���̕����̃C���f�b�N�X���v�Z
        int nextIndex = (currentIndex + 1) % chars.Length;

        // �{�^���̃e�L�X�g���X�V
        nows[n] = chars[nextIndex].ToString();
        texts[n].text = nows[n];
        CheckAnswer();
    }

    public void CheckAnswer()
    {
        string answer = "";
        foreach (Text text in texts)
        {
            answer += text.text;
        }
        if (answer == Answer)
        {
            Debug.Log("����");
            OnCorrect.Invoke();
            audioSource.Play();

            if (targetObject != null)
            {
                targetObject.SetActive(false);
                isAnimationPlaying = false;
            }
        }
    }
}