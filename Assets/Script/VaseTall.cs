using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (isOpen)
        {
            // Š÷‚ªŠJ‚¢‚Ä‚¢‚éê‡‚Í•Â‚¶‚é
            vaseTall.SetTrigger("DownTrigger");
            downSound.Play();
            isOpen = false;
        }
        else
        {
            // Š÷‚ª•Â‚¶‚Ä‚¢‚éê‡‚ÍŠJ‚­
            vaseTall.SetTrigger("UpTrigger");
            
            isOpen = true;
        }
    }
}
