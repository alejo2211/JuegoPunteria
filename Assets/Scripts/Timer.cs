using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timer = 10f;
    public float tiempoRestante;
    public TextMeshProUGUI textoTimer;
    public GameObject gameOver;
    public bool juegoTerminado = false;
    

    private void Start()
    {
        tiempoRestante = timer;
    }

    void Update()
    {
        textoTimer.text = "" + (Mathf.CeilToInt(tiempoRestante)).ToString();
        if (tiempoRestante <= 0f)
        {
           
            gameOver.SetActive(true);
        }
        else
        {

            tiempoRestante -= Time.deltaTime;
        }
        if (tiempoRestante<=0f)
        {
            FinDelJuego();
        }
        void FinDelJuego()
        {
            juegoTerminado = true;
            SceneManager.LoadScene("GameOver"); // Carga la escena de game over
        }   
    }

    //void PausarJuego()
    //{
    //    Time.timeScale = 0f;
    //}
}
