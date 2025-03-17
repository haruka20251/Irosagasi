using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cancelbutton : MonoBehaviour
{
    public GameObject targetObject; // 非アクティブにしたいオブジェクト

    public void DeactivateObject()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Target object is not assigned.");
        }
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
