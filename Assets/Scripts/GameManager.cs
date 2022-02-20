using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    int indicePregunta = 0;
    // Start is called before the first frame update
    void Start()
    {
        textoPreguntas.text = preguntas[0];

        palabrasGuardadas = new string[preguntas.Length];
        //palabrasGuardadas[0] = preguntas[0];

    }


    public void Guardar_Respuesta()
    {
        //Guardar lo que escribió el jugador
      
        palabrasGuardadas[indicePregunta] = inputRespuesta.text;

        //Limpiar el texto para que el jugador pueda escribir de nuevo
        inputRespuesta.text = null; // o "" ambas funcionan

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
        textoHistoria.text = historia;


        //TODO ocultar los elementos que no se utilizan
        textoPreguntas.gameObject.SetActive(false);
        botonRespuesta.SetActive(false);
        inputRespuesta.gameObject.SetActive(false);
    }
}
