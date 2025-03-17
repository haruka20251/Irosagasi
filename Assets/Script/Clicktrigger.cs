using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicktrigger : MonoBehaviour
{
    public GameObject targetObject; // �\��/��\����؂�ւ������I�u�W�F�N�g

    void OnMouseDown()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(!targetObject.activeSelf);
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
