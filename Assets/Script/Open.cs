using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour
{
    public Animator doorAnimator; // ����Animator�R���|�[�l���g

    public void OpenDoor()
    {
        doorAnimator.SetTrigger("OpenTrigger"); // �g���K�[��ݒ肵�ăA�j���[�V�������Đ�
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
