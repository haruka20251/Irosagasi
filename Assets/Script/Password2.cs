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
                StartCoroutine(HideTargetObjectWithDelay(0.5f));
            }
        }
        else
        {
            resultText.text = "Incorrect password";
        }
    }
    private IEnumerator HideTargetObjectWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        targetObject.SetActive(false);
        isAnimationPlaying = false;
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
