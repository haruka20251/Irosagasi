using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private Rigidbody playerRb;
    private float speed=0.9f;
    private float speedR=0.2f;
    public Camera subCamera;
    public float minRotation = -45f; // �ŏ���]�p�x
    public float maxRotation = 50f; // �ő��]�p�x
    public AudioSource footSource;
    [SerializeField]private CameraMove cameraMove=new CameraMove();
    private Transform cameraTransform;
    private bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
     
        playerRb = GetComponent<Rigidbody>();
        cameraMove.Setup(subCamera, 1.0f);
        cameraTransform = subCamera.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main != null) // �J���������݂��邩�m�F
        {
            Vector3 cameraForward = Camera.main.transform.forward;
            cameraForward.y = 0; // Y�������̈ړ��𖳎�
            cameraForward.Normalize();
            Vector3 velocity = Vector3.zero;
               isMoving = false;

            Vector3 cameraBack = -cameraForward; // �J�����̋t����
            if (Input.GetKey(KeyCode.W))
            {
                velocity = cameraForward * speed;
                isMoving = true;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                velocity = cameraBack * speed;
                footSource.Play();
                isMoving = true;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0, -speedR, 0);
                isMoving=false;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0, speedR, 0);
                isMoving=false;
            }
            playerRb.velocity = velocity;

            if (isMoving && !footSource.isPlaying) // �ړ����ŁA�������Đ����łȂ��ꍇ�̂ݍĐ�
            {
                footSource.Play();
            }
            else if (!isMoving && footSource.isPlaying) // ��~���ŁA�������Đ����̏ꍇ��~
            {
                footSource.Stop();
            }

            if (subCamera != null)
            {
                float currentRotationX = subCamera.transform.eulerAngles.x;

                if (Input.GetKey(KeyCode.Q))
                {
                    currentRotationX -= speedR;
                }
                else if (Input.GetKey(KeyCode.E))
                {
                    currentRotationX += speedR;
                }

                // �p�x�����i���b�v�A���E���h���l���j
                if (currentRotationX > 180) currentRotationX -= 360; // 360�x�𒴂����ꍇ
                if (currentRotationX < -180) currentRotationX += 360; // 0�x����������ꍇ

                currentRotationX = Mathf.Clamp(currentRotationX, minRotation, maxRotation);
                subCamera.transform.eulerAngles = new Vector3(currentRotationX, subCamera.transform.eulerAngles.y, subCamera.transform.eulerAngles.z);
            }
            else
            {
                Debug.LogError("�T�u�J�������A�T�C������Ă��܂���I");
            }
        }

        Vector3 camerMoved= cameraMove.DoHeadBob(1.0f, isMoving);
        cameraTransform.localPosition= camerMoved;
    }
}
