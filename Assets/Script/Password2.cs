using System.Collections;
using System.Collections.Generic;
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
    public GameObject targetObject;
    private bool isAnimationPlaying = false;

    public void CheckAnswer() //引数を削除
    {
        string enteredText = inputField.text; //InputFieldからテキストを取得

        if (enteredText == "STAR" || enteredText == "star" || enteredText == "Star")
        {
            resultText.text = "Password correct!";
            audioSource.Play();
            OnCorrect.Invoke();
            if (targetObject != null)
            {

                targetObject.SetActive(false);
                isAnimationPlaying = false;
            }
        }
        else
        {
            resultText.text = "Incorrect password";
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
