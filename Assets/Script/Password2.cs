using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class Password2 : MonoBehaviour
{
    public Text resultText;
    //public GameObject targetObject;
    public AudioSource audioSource;
    public UnityEvent OnCorrect;
    public InputField inputField;

    public void CheckAnswer() //引数を削除
    {
        string enteredText = inputField.text; //InputFieldからテキストを取得

        if (enteredText == "STAR" || enteredText == "star" || enteredText == "Star")
        {
            resultText.text = "パスワード一致！";
            audioSource.Play();
            OnCorrect.Invoke();
        }
        else
        {
            resultText.text = "パスワード不一致";
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
