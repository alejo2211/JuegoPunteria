using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Contador : MonoBehaviour
{
    public int puntos = 0;
    public Text puntajeTexto;
    
    public void PuntajeActulizado(int punto)
    {
        puntos += punto;
        puntajeTexto.text = "Score: " + puntos.ToString();
    }

}
