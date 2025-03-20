using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StringPassword : MonoBehaviour
{
    // �{�^���ɕ\�����镶��
    public string chars = "0123456789";

    // �{�^���̃e�L�X�g���Ǘ�����z��
    public Text[] texts;

    // �e�{�^�������݂ǂ̕�����\�����Ă��邩���Ǘ�����z��
    public int[] nows;

    public string Answer;

    public UnityEvent OnCorrect;

    private bool isAnimationPlaying = false;
    public GameObject targetObject;
    public AudioSource audioSource;

    public void ChangeText(int n)
    {
        // ���̕����֕ύX
        nows[n] += 1;

        // �������𒴂�����0�ɖ߂��i���[�v�j
        if (nows[n] >= chars.Length)
        {
            nows[n] = 0;
        }

        // �{�^���̃e�L�X�g���X�V
        texts[n].text = chars[nows[n]].ToString();
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
                StartCoroutine(HideTargetObjectWithDelay(0.5f));
            }
        }
    }
    private IEnumerator HideTargetObjectWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        targetObject.SetActive(false);
        isAnimationPlaying = false;
    }

}
