using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Arco : MonoBehaviour
{
    public InputActionProperty dedo;
    public Transform mano;
    public bool detector;
    private Vector3 posicionCubo;
    public LineRenderer linea1;
    public LineRenderer linea2;
    private float distancia;
    public static Arco singleton;
    public float distanciaMaxima=0.9f;
    public Flecha flecha;
    public float fuerzaDisparo = 30;
   
    

    Vector3 direccion;
    public bool agarrado;

    void Start()
    {
        posicionCubo = transform.localPosition;
        singleton = this;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="mano")
        {
            detector = true;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag=="mano")
        {
            detector = false;
        }
    }
    void Update()
    {
        if (detector)
        {
            if (dedo.action.ReadValue<float>()>0.8f)
            {
                Vector3 diferencia = transform.parent.position - transform.position;
                agarrado = true;
                direccion = diferencia.normalized;
                distancia = diferencia.magnitude;
                
                if (distancia<distanciaMaxima)
                {
                    transform.position = mano.position;
                }
                else
                {
                    Soltar();
                    //transform.position = transform.parent.position + diferencia.normalized * distanciaMaxima;
                }
                if (flecha!=null)
                {
                    flecha.transform.LookAt(transform.parent);
                }
                
            }
            else
            {
                if (agarrado)
                {
                    Soltar();
                    Disparar();

                }
            }
        }
        else
        {
            Soltar();
        }
        linea1.SetPosition(0, linea1.transform.position);
        linea1.SetPosition(1, transform.position);
        linea2.SetPosition(0, linea2.transform.position);
        linea2.SetPosition(1, transform.position);
    }
    void Soltar()
    {
        agarrado = false;
        transform.localPosition = posicionCubo;
        detector = false;
    }
    void Disparar()
    {
        if (flecha==null)
        {
            return;
        }
        
        flecha.transform.parent = null;
        flecha.rb.isKinematic = false;
        flecha.rb.velocity = (direccion * fuerzaDisparo) * distancia / distanciaMaxima;
        //flecha.enabled = false;
        flecha = null;
    }
}
