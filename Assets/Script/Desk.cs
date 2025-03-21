using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Desk : MonoBehaviour
{
    private Animator desk;
    private bool isOpen = false;
    public AudioSource openSound;
    public AudioSource closeSound;


    // Start is called before the first frame update
    void Start()
    {
        desk = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseDown()
    {
        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (isOpen)
        {
            // 机が開いている場合は閉じる
            desk.SetTrigger("CloseTrigger");
            closeSound.Play();
            isOpen = false;
        }
        else
        {
            // 机が閉じている場合は開く
            desk.SetTrigger("OpenTrigger");
            openSound.Play();
            isOpen = true;
        }
    }
}

