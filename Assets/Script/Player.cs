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
    public float minRotation = -45f; // 最小回転角度
    public float maxRotation = 50f; // 最大回転角度
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
        if (Camera.main != null) // カメラが存在するか確認
        {
            Vector3 cameraForward = Camera.main.transform.forward;
            cameraForward.y = 0; // Y軸方向の移動を無視
            cameraForward.Normalize();
            Vector3 velocity = Vector3.zero;
               isMoving = false;

            Vector3 cameraBack = -cameraForward; // カメラの逆方向
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

            if (isMoving && !footSource.isPlaying) // 移動中で、かつ音が再生中でない場合のみ再生
            {
                footSource.Play();
            }
            else if (!isMoving && footSource.isPlaying) // 停止中で、かつ音が再生中の場合停止
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

                // 角度制限（ラップアラウンドを考慮）
                if (currentRotationX > 180) currentRotationX -= 360; // 360度を超えた場合
                if (currentRotationX < -180) currentRotationX += 360; // 0度を下回った場合

                currentRotationX = Mathf.Clamp(currentRotationX, minRotation, maxRotation);
                subCamera.transform.eulerAngles = new Vector3(currentRotationX, subCamera.transform.eulerAngles.y, subCamera.transform.eulerAngles.z);
            }
            else
            {
                Debug.LogError("サブカメラがアサインされていません！");
            }
        }

        Vector3 camerMoved= cameraMove.DoHeadBob(1.0f, isMoving);
        cameraTransform.localPosition= camerMoved;
    }
}
