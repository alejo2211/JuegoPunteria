using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reinicio : MonoBehaviour
{
   public void EscenaCargada(string level)
    {
        SceneManager.LoadScene(level);
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            EscenaCargada(SceneManager.GetActiveScene().name);
        }
    }


}

