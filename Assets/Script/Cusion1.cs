using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cusion1 : MonoBehaviour
{
    private float speed = 3.5f;
    public AudioSource audioSource;
    private Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }


        rigidbody.AddForce(Vector3.up * speed , ForceMode.Impulse);
        audioSource.Play();
    }
}
