using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeskPass : MonoBehaviour
{
    public Animator deskAnimator; // ����Animator�R���|�[�l���g

    public void OpenDesk()
    {

        deskAnimator.SetTrigger("OpenTrigger"); // �g���K�[��ݒ肵�ăA�j���[�V�������Đ�
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
