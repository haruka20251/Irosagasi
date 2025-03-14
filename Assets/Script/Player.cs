using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private Rigidbody playerRb;
    private float speed=0.01f;
    private float speedR=0.2f;
    public Camera subCamera;
    public float minRotation = -45f; // 最小回転角度
    public float maxRotation = 50f; // 最大回転角度


    // Start is called before the first frame update
    void Start()
    {
     
        playerRb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main != null) // カメラが存在するか確認
        {
            Vector3 cameraForward = Camera.main.transform.forward;
            cameraForward.y = 0; // Y軸方向の移動を無視
            cameraForward.Normalize();

            Vector3 cameraBack = -cameraForward; // カメラの逆方向
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * speed);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.back * speed);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0, -speedR, 0);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0, speedR, 0);
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
       

    }
}
