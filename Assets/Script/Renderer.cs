using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Renderer : MonoBehaviour
{
    public RenderTexture renderTexture;
    public Camera targetCamera;

    void Start()
    {
        if (targetCamera != null && renderTexture != null)
        {
            targetCamera.targetTexture = renderTexture;
        }
    }
}
