using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastKey : MonoBehaviour
{

    public Material key;
    private float time = 1;//消える時間
    private float threshold;//Thresholdの箱
    private float targetthreshold = 1f;//最終の値
    private bool isFading = false;//消えている途中かどうか
    public AudioSource source;
    public GameObject cube;
    public GameObject targetObject;
    private float timer = 2;
    // Start is called before the first frame update
    void Start()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(false); // 初期状態を非アクティブに
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (targetObject != null && targetObject.activeSelf)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                targetObject.SetActive(false); // 非アクティブにする
            }
        }
    }
        void OnMouseDown()
        {

            if (!isFading)
            {
                threshold = key.GetFloat("_Threshold"); // 現在のThresholdの値を取得
                source.Play();
            if (targetObject != null)
            {
                targetObject.SetActive(true); // 表示する
                timer = 2; // タイマーをリセット
            }
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
                if (cube != null) // Cubeオブジェクトが存在する場合のみ消去
                {
                    Destroy(cube);
                }
                else
                {
                    Debug.LogWarning("Cubeオブジェクトが設定されていません！");
                }


            }
            isFading = false;
        }
}
