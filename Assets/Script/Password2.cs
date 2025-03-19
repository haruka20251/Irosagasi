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

    public void CheckAnswer() //�������폜
    {
        string enteredText = inputField.text; //InputField����e�L�X�g���擾

        if (enteredText == "STAR" || enteredText == "star" || enteredText == "Star")
        {
            resultText.text = "�p�X���[�h��v�I";
            audioSource.Play();
            OnCorrect.Invoke();
        }
        else
        {
            resultText.text = "�p�X���[�h�s��v";
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
