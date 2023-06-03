using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonManager : MonoBehaviour
{
   
    public void VolverAJugar()
    {
        SceneManager.LoadScene("Arqueria"); // Carga la escena principal nuevamente
    }
}
