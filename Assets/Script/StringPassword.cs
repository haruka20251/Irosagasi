using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StringPassword : MonoBehaviour
{
    // ボタンに表示する文字
    public string chars = "0123456789";

    // ボタンのテキストを管理する配列
    public Text[] texts;

    // 各ボタンが現在どの文字を表示しているかを管理する配列
    public int[] nows;

    public string Answer;

    public UnityEvent OnCorrect;

    private bool isAnimationPlaying = false;
    public GameObject targetObject;
    public AudioSource audioSource;

    public void ChangeText(int n)
    {
        // 次の文字へ変更
        nows[n] += 1;

        // 文字数を超えたら0に戻す（ループ）
        if (nows[n] >= chars.Length)
        {
            nows[n] = 0;
        }

        // ボタンのテキストを更新
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
            Debug.Log("正解");
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
