using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cusion : MonoBehaviour
{
    private float speed = 50f;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
            
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            audioSource.Play();
    }
}
