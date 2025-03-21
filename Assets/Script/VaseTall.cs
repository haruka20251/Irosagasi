using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VaseTall : MonoBehaviour
{
    private Animator vaseTall;
    private bool isOpen = false;
    public AudioSource downSound;


    // Start is called before the first frame update
    void Start()
    {
        vaseTall = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (isOpen)
        {
            // 机が開いている場合は閉じる
            vaseTall.SetTrigger("DownTrigger");
            downSound.Play();
            isOpen = false;
        }
        else
        {
            // 机が閉じている場合は開く
            vaseTall.SetTrigger("UpTrigger");
            
            isOpen = true;
        }
    }
}
