using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public Material key;
    private float time = 1;//消える時間
    private float threshold;//Thresholdの箱
    private float targetthreshold = 1f;//最終の値
    private bool isFading = false;//消えている途中かどうか
    public AudioSource source;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameStart()
    {
        if (!isFading)
        {
            threshold = key.GetFloat("_Threshold"); // 現在のThresholdの値を取得
            source.Play();
            StartCoroutine(FadeThreshold());
        }
    }

    IEnumerator FadeThreshold()
    {
        isFading = true;
        float elapsedTime = 0f;

        while (elapsedTime < time)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / time);
            key.SetFloat("_Threshold", Mathf.Lerp(threshold, targetthreshold, t));
            yield return null;
        }

        key.SetFloat("_Threshold", targetthreshold); // 最終的な値を設定

        if (key.GetFloat("_Threshold") >= 1F)
        {
            SceneManager.LoadScene("SampleScene 1");
        }
        isFading = false;
    }
}

