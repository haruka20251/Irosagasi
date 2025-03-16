using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // �Ď��ΏۃI�u�W�F�N�g
    public GameObject[] targetObjects;

    // �������I�u�W�F�N�g
    public GameObject moveObjects;

    // ����̑傫���i�e�I�u�W�F�N�g���Ƃɐݒ�j
    public Vector3[] targetSizes;

    // ���e�덷
    public float tolerance = 0.01f;

    // ���ׂẴI�u�W�F�N�g������̑傫���ɂȂ�����
    private bool allTargetsReached = false;

    private float movingTimer = 1.0f;


    void Update()
    {
        // ���ׂẴI�u�W�F�N�g������̑傫���ɂȂ������m�F
        allTargetsReached = true; // �����l��true�ɐݒ�

        for (int i = 0; i < targetObjects.Length; i++)
        {
            // �덷���l�������͈͔���
            if (Vector3.Distance(targetObjects[i].transform.localScale, targetSizes[i]) > tolerance)
            {
                allTargetsReached = false; // ��ł������𖞂����Ȃ��I�u�W�F�N�g�������false�ɐݒ�
                break; // ���[�v�𔲂���
            }
        }

        // ���ׂẴI�u�W�F�N�g������̑傫���ɂȂ�����A�����I�u�W�F�N�g�𓮂���
        if (allTargetsReached)
        {
            MoveObject();
           
        }
    }

    void MoveObject()
    {
        // �����I�u�W�F�N�g�𓮂�������
        if (moveObjects != null)
        {
            moveObjects.transform.position += Vector3.back * Time.deltaTime; // ��F�E�Ɉړ�
            movingTimer -= Time.deltaTime;
            if (movingTimer <= 0)
            {
                moveObjects = null;
            }
        }
    }
}