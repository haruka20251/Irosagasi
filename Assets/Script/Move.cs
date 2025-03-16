using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // 監視対象オブジェクト
    public GameObject[] targetObjects;

    // 動かすオブジェクト
    public GameObject moveObjects;

    // 特定の大きさ（各オブジェクトごとに設定）
    public Vector3[] targetSizes;

    // 許容誤差
    public float tolerance = 0.01f;

    // すべてのオブジェクトが特定の大きさになったか
    private bool allTargetsReached = false;

    private float movingTimer = 1.0f;


    void Update()
    {
        // すべてのオブジェクトが特定の大きさになったか確認
        allTargetsReached = true; // 初期値をtrueに設定

        for (int i = 0; i < targetObjects.Length; i++)
        {
            // 誤差を考慮した範囲判定
            if (Vector3.Distance(targetObjects[i].transform.localScale, targetSizes[i]) > tolerance)
            {
                allTargetsReached = false; // 一つでも条件を満たさないオブジェクトがあればfalseに設定
                break; // ループを抜ける
            }
        }

        // すべてのオブジェクトが特定の大きさになったら、動くオブジェクトを動かす
        if (allTargetsReached)
        {
            MoveObject();
           
        }
    }

    void MoveObject()
    {
        // 動くオブジェクトを動かす処理
        if (moveObjects != null)
        {
            moveObjects.transform.position += Vector3.back * Time.deltaTime; // 例：右に移動
            movingTimer -= Time.deltaTime;
            if (movingTimer <= 0)
            {
                moveObjects = null;
            }
        }
    }
}