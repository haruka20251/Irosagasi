using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public Material key;
    private float time = 1;//�����鎞��
    private float threshold;//Threshold�̔�
    private float targetthreshold = 1f;//�ŏI�̒l
    private bool isFading = false;//�����Ă���r�����ǂ���
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
            threshold = key.GetFloat("_Threshold"); // ���݂�Threshold�̒l���擾
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

        key.SetFloat("_Threshold", targetthreshold); // �ŏI�I�Ȓl��ݒ�

        if (key.GetFloat("_Threshold") >= 1F)
        {
            SceneManager.LoadScene("SampleScene 1");
        }
        isFading = false;
    }
}

