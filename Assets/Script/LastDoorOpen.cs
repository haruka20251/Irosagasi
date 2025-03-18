using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class LastDoorOpen : MonoBehaviour
{
    public Animator doorKnobAnimator; // ドアノブのアニメーター
    public Animator doorAnimator;     // ドアのアニメーター
    public AudioSource openSound;    // オープンサウンド
    private float timer = 0;

    private bool knobTriggered = false; // ドアノブがトリガーされたか

    void OnMouseDown()
    {
        if (!knobTriggered)
        {
            // ドアノブのアニメーションを再生
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
            timer += Time.deltaTime; // knobTriggeredがtrueの場合のみカウント
            if (timer >= 1)
            {
                doorAnimator.SetTrigger("OpenTrigger");
                knobTriggered = false;
            }
        }
    }
    
}
