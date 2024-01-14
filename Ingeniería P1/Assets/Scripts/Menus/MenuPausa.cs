using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuPausa : MonoBehaviour
{

    [SerializeField] private GameObject menuPausa;

    public static bool juegoPausado = false;
    
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(juegoPausado)
            {
                Reanudar();
            }
            else
            {
                Pausa();
            
            }
            
        }
    
    }

    public void Pausa()
    {
        Cursor.visible = true;
        juegoPausado = true;
        Time.timeScale = 0f;
        menuPausa.SetActive(true);
    }
   
    public void Reanudar()
    {
        Cursor.visible = false;
        juegoPausado = false;
        Time.timeScale = 1f;
        menuPausa.SetActive(false);
    }

    public void Cerrar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
    

}





