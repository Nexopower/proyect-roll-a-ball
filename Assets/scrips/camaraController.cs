using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraController : MonoBehaviour
{
    public GameObject jugador;
    private Vector3 offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = transform.position - jugador.transform.position;
    }

    void LateUpdate()
    {
        transform.position = jugador.transform.position + offset;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
