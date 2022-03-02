using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    [SerializeField] private string[] palabrasGuardadas;
    [SerializeField] private string[] preguntas;
    [SerializeField] private string historia;

    [SerializeField] TextMeshProUGUI textoPreguntas;
    [SerializeField] TMP_InputField inputRespuesta;
    [SerializeField] TextMeshProUGUI textoHistoria;
    [SerializeField] GameObject botonRespuesta;
    [SerializeField] GameObject botonReinicio;

    int indicePregunta = 0;

    // Start is called before the first frame update
    void Start()
    {
        //string nombre = "Toribio";
        //Debug.Log("Hola  yo me llamo " + nombre + "tengo " + 9.ToString() + "años");

        //Debug.Log($"Hola me llamo {nombre}, {9} años tengo");

        //string textoFormatear = "Soy {0} y tengo solo {1} años";
        //string mensaje = string.Format(textoFormatear, nombre, 9);
        //Debug.Log(mensaje);

        textoPreguntas.text = preguntas[indicePregunta];

        palabrasGuardadas = new string[preguntas.Length];
        botonReinicio.SetActive(false);
        //palabrasGuardadas[0] = preguntas[0];

    }


    public void Guardar_Respuesta()
    {
        //Guardar lo que escribió el jugador
      
        palabrasGuardadas[indicePregunta] = inputRespuesta.text;

        //Limpiar el texto para que el jugador pueda escribir de nuevo
        inputRespuesta.text = ""; // o null ambas funcionan

        //Poner la siguiente pregunta;
        indicePregunta++;

        //TODO Necesitamos una comprobación para saber si quedan preguntas
        //TODO Si la comprobación es cierta ejecutar MostrarHistoria
        if (indicePregunta >= preguntas.Length)
        {
            MostrarHistoria();
        }

        else
        {
            textoPreguntas.text = preguntas[indicePregunta];
        }
    }

    void MostrarHistoria()
    {
        //TODO mostrar un nuevo TextMeshPro que tenga toda la historia
        textoHistoria.gameObject.SetActive(true);
        textoHistoria.text = string.Format(historia, palabrasGuardadas);
        botonReinicio.SetActive(true);


        //TODO ocultar los elementos que no se utilizan
        textoPreguntas.gameObject.SetActive(false);
        botonRespuesta.SetActive(false);
        inputRespuesta.gameObject.SetActive(false);
    }

    public void ReiniciarJuego()
    {
        /*Forma de reiniciar todo*/

        //indicePregunta = 0;
        //palabrasGuardadas = new string[preguntas.Length];

        //textoPreguntas.text = preguntas[indicePregunta];

        //textoPreguntas.gameObject.SetActive(true);
        //botonRespuesta.SetActive(true);
        //inputRespuesta.gameObject.SetActive(true);

        //textoHistoria.gameObject.SetActive(false);
        botonReinicio.SetActive(false);

        //Recargar la escena como estaba al proncipio
        int indexEscena = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(indexEscena);


    }
}
