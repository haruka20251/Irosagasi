using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastKey : MonoBehaviour
{

    public Material key;
    private float time = 1;//�����鎞��
    private float threshold;//Threshold�̔�
    private float targetthreshold = 1f;//�ŏI�̒l
    private bool isFading = false;//�����Ă���r�����ǂ���
    public AudioSource source;
    public GameObject cube;
    public GameObject targetObject;
    private float timer = 2;
    // Start is called before the first frame update
    void Start()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(false); // ������Ԃ��A�N�e�B�u��
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
                targetObject.SetActive(false); // ��A�N�e�B�u�ɂ���
            }
        }
    }
        void OnMouseDown()
        {

            if (!isFading)
            {
                threshold = key.GetFloat("_Threshold"); // ���݂�Threshold�̒l���擾
                source.Play();
            if (targetObject != null)
            {
                targetObject.SetActive(true); // �\������
                timer = 2; // �^�C�}�[�����Z�b�g
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

            key.SetFloat("_Threshold", targetthreshold); // �ŏI�I�Ȓl��ݒ�

            if (key.GetFloat("_Threshold") >= 1F)
            {
                if (cube != null) // Cube�I�u�W�F�N�g�����݂���ꍇ�̂ݏ���
                {
                    Destroy(cube);
                }
                else
                {
                    Debug.LogWarning("Cube�I�u�W�F�N�g���ݒ肳��Ă��܂���I");
                }


            }
            isFading = false;
        }
}
