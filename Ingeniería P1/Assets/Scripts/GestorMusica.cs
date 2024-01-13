using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestorMusica : MonoBehaviour
{
    public static GestorMusica instancia;

    private void Awake()
    {
        instancia = this;
        DontDestroyOnLoad(gameObject);
    }

    public static void PonerMusica(AudioClip cancion, AudioSource reproductor, bool debeRepetirse)
    {
        reproductor.clip = cancion;
        reproductor.loop = debeRepetirse;
        reproductor.Play();
    }

    public static void QuitarMusica(AudioSource reproductor)
    {
        reproductor.Stop();
    }

}
