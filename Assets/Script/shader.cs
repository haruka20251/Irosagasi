using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shader : MonoBehaviour
{
    public Material targetMaterial; // Threshold�����Z�b�g�������}�e���A��

    void Start()
    {
        if (targetMaterial != null)
        {
            targetMaterial.SetFloat("_Threshold", 0f);
        }
    }


// Update is called once per frame
void Update()
    {
        
    }
}
