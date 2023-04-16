using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Contador : MonoBehaviour
{
    public int puntos = 0;
    public TextMeshProUGUI puntajeTexto;
    
    public void PuntajeActulizado(int punto)
    {
        puntos += punto;
        puntajeTexto.text = "Puntos Acumulados: " + puntos.ToString();
    }

}
