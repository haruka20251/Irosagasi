using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

//パスワード入力用のキャンバスを扱うクラス
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
        // キャンバスを非表示にする
        gameObject.SetActive(false);

        // GameObject.Find の結果を null チェック
        fieldObj = GameObject.Find("InputField");
        if (fieldObj != null)
        {
            inputField = fieldObj.GetComponent<InputField>();
        }
        else
        {
            Debug.LogError("InputField オブジェクトが見つかりません。");
        }

        cube = GameObject.Find("Torus.003");
        if (cube != null)
        {
            desk = cube.GetComponent<Animator>();
        }
        else
        {
            Debug.LogError("Torus.003 オブジェクトが見つかりません。");
        }

        // Animator コンポーネントがアタッチされているかチェック
        desk = GetComponent<Animator>();
        if (desk == null)
        {
            Debug.LogError("Animator コンポーネントがアタッチされていません。");
        }
    }

    public void InputText()
    {
        // inputField が null でないことを確認
        if (inputField != null)
        {
            if (inputField.text == "MARCH" || inputField.text == "march")
            {
                // desk が null でないことを確認
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
            Debug.LogError("InputField が初期化されていません。");
        }
    }

    // クリックイベントでキャンバスを表示する関数
    public void ShowPasswordCanvas()
    {
        gameObject.SetActive(true);
    }
}