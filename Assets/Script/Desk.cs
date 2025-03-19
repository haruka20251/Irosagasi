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
            // �����J���Ă���ꍇ�͕���
            desk.SetTrigger("CloseTrigger");
            closeSound.Play();
            isOpen = false;
        }
        else
        {
            // �������Ă���ꍇ�͊J��
            desk.SetTrigger("OpenTrigger");
            openSound.Play();
            isOpen = true;
        }
    }
}

