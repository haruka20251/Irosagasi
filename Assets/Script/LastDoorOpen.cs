using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class LastDoorOpen : MonoBehaviour
{
    public Animator doorKnobAnimator; // �h�A�m�u�̃A�j���[�^�[
    public Animator doorAnimator;     // �h�A�̃A�j���[�^�[
    public AudioSource openSound;    // �I�[�v���T�E���h
    private float timer = 0;

    private bool knobTriggered = false; // �h�A�m�u���g���K�[���ꂽ��

    void OnMouseDown()
    {
        if (!knobTriggered)
        {
            // �h�A�m�u�̃A�j���[�V�������Đ�
            doorKnobAnimator.SetTrigger("DownTrigger");
            knobTriggered = true;
            openSound.Play();
        
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (knobTriggered)
        {
            timer += Time.deltaTime; // knobTriggered��true�̏ꍇ�̂݃J�E���g
            if (timer >= 1)
            {
                doorAnimator.SetTrigger("OpenTrigger");
                knobTriggered = false;
            }
        }
    }
    
}
