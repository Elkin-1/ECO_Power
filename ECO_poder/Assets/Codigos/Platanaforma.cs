using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platanaforma : MonoBehaviour
{
    private Rigidbody cuerpoRigido;
    public float velocidad = 2.0f;
    public float distancia = 5.95f;

    private Vector3 direccion = Vector3.forward;
    private Vector3 posicionInicial;

    // Start is called before the first frame update
    void Start()
    {
        cuerpoRigido = GetComponent<Rigidbody>();
        direccion = transform.forward;
        posicionInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float valor = Mathf.PingPong(Time.time * velocidad, distancia);
        Vector3 nuevaPosicion = posicionInicial + direccion * valor;
        cuerpoRigido.MovePosition(nuevaPosicion);
    }
}
