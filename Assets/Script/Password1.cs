using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Password1 : MonoBehaviour
{
    // ボタンに表示する文字
    public string chars = "JHAQMKRC";

    // ボタンのテキストを管理する配列
    public Text[] texts;

    // 各ボタンが現在どの文字を表示しているかを管理する配列
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
            nows[i] = chars[0].ToString(); // 最初の文字を設定
            texts[i].text = nows[i]; // テキストを更新
        }
    }

    public void ChangeText(int n)
    {
        int currentIndex = chars.IndexOf(nows[n]);

        // 次の文字のインデックスを計算
        int nextIndex = (currentIndex + 1) % chars.Length;

        // ボタンのテキストを更新
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
            Debug.Log("正解");
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