using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desk : MonoBehaviour
{
    private Animator desk;

    // Start is called before the first frame update
    void Start()
    {
        desk = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        desk.SetTrigger("OpenTrigger");
    }
}

