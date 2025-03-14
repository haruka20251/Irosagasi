using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    void OnMouseDown()
    {
        if (isOpen)
        {
            // Š÷‚ªŠJ‚¢‚Ä‚¢‚éê‡‚Í•Â‚¶‚é
            desk.SetTrigger("CloseTrigger");
            closeSound.Play();
            isOpen = false;
        }
        else
        {
            // Š÷‚ª•Â‚¶‚Ä‚¢‚éê‡‚ÍŠJ‚­
            desk.SetTrigger("OpenTrigger");
            openSound.Play();
            isOpen = true;
        }
    }
}

