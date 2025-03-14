using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desk : MonoBehaviour
{
    private Animator desk;
    private bool isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        desk = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        if (isOpen)
        {
            // �����J���Ă���ꍇ�͕���
            desk.SetTrigger("CloseTrigger");
            isOpen = false;
        }
        else
        {
            // �������Ă���ꍇ�͊J��
            desk.SetTrigger("OpenTrigger");
            isOpen = true;
        }
    }
}

