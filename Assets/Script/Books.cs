using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Books : MonoBehaviour
{
    public Vector3[] scales;
    public float[] yOffsets; // Y軸のオフセットを格納する配列
    private int currentIndex = 0;
    private Vector3 initialPosition; // 初期位置を保持

    void Start()
    {
        Debug.Log("yOffsets Length: " + yOffsets.Length);
        initialPosition = transform.position; // 初期位置を保存
        if (yOffsets.Length > 0)
        {
            Vector3 newPosition = initialPosition;
            newPosition.y += yOffsets[0]; // 初期位置にオフセットを加算
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
    void OnMouseDown() // マウスでクリックされたときに呼び出される
    {
        ChangeObjectState();
    }

    void ChangeObjectState()
    {
        if (scales.Length > 0 && yOffsets.Length > 0)
        {
            transform.localScale = scales[currentIndex];
            Vector3 newPosition = initialPosition; // 初期位置を基準にする
            newPosition.y += yOffsets[currentIndex]; // オフセットを加算
            transform.position = newPosition;
            currentIndex = (currentIndex + 1) % scales.Length;
        }
    }
}