using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Books : MonoBehaviour
{
    public Vector3[] scales;
    public float[] yOffsets; // Y���̃I�t�Z�b�g���i�[����z��
    private int currentIndex = 0;
    private Vector3 initialPosition; // �����ʒu��ێ�

    void Start()
    {
        Debug.Log("yOffsets Length: " + yOffsets.Length);
        initialPosition = transform.position; // �����ʒu��ۑ�
        if (yOffsets.Length > 0)
        {
            Vector3 newPosition = initialPosition;
            newPosition.y += yOffsets[0]; // �����ʒu�ɃI�t�Z�b�g�����Z
            transform.position = newPosition;
        }
        else
        {
            Debug.LogError("yOffsets array is empty!");
        }
    }

    void Update()
    {
        
    }
    void OnMouseDown() // �}�E�X�ŃN���b�N���ꂽ�Ƃ��ɌĂяo�����
    {
        ChangeObjectState();
    }

    void ChangeObjectState()
    {
        if (scales.Length > 0 && yOffsets.Length > 0)
        {
            transform.localScale = scales[currentIndex];
            Vector3 newPosition = initialPosition; // �����ʒu����ɂ���
            newPosition.y += yOffsets[currentIndex]; // �I�t�Z�b�g�����Z
            transform.position = newPosition;
            currentIndex = (currentIndex + 1) % scales.Length;
        }
    }
}