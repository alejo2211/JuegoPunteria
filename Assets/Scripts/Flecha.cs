using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Flecha : MonoBehaviour
{
    public Rigidbody rb;
    public bool activo = true;
    private bool diana = false;
    public UnityEngine.XR.Interaction.Toolkit.XRGrabInteractable interactuador;
    public Transform puntaFlecha;
    public float radio = 0.5f;
    public float puntajeMaximo = 100;
    public float puntajeMinimo = 10;
    private int puntos = 0;
    public TextMeshProUGUI textoPuntos;



    public int puntuacion { get; internal set; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="posicionar" && activo)
        {
            activo = false;
            interactuador.enabled = false;
            transform.parent = Arco.singleton.transform;
            Arco.singleton.flecha = this;
            transform.localPosition = new Vector3(0, 0, 0);
            transform.localEulerAngles = Vector3.zero;
            rb.isKinematic = true;

        }
        if (other.CompareTag ("Diana") && !diana)
        {
            Debug.Log("hizo trigger" + other.name +" - " + this.name + " - " + this.GetInstanceID());
           
            float distancia = Vector3.Distance(puntaFlecha.position, other.transform.position);
            Debug.Log("la distancia es : " + distancia);
            diana = true;
            rb.velocity = Vector3.zero;
            rb.isKinematic = true;
            transform.parent = other.transform;
            float t = distancia / radio;
            int puntaje = Mathf.FloorToInt(Mathf.Lerp(puntajeMaximo, puntajeMinimo, t));
            puntos += puntaje;
            Debug.Log("el puntaje obtenido es : " + puntaje);
            
            textoPuntos.text = "Puntos obtenidos: " + puntos.ToString();
            Contador scoreManager = FindObjectOfType<Contador>();
            scoreManager.PuntajeActulizado(puntaje);

        }
    }
    
}
