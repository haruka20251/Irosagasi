using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeskPass : MonoBehaviour
{
    public Animator deskAnimator; // 扉のAnimatorコンポーネント

    public void OpenDesk()
    {

        deskAnimator.SetTrigger("OpenTrigger"); // トリガーを設定してアニメーションを再生
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
