using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class CanvasEffects : MonoBehaviour
{
    public Color[] colors;
    public float colorChangeInterval = 1f;

    private int currentColorIndex = 0;
    private int lastColorIndex = 0;
    private float colorChangeTimer = 0f;    
    // public Image sliderBorder;
    // public TextMeshProUGUI points;

    void Start()
    {
        // Establecer el color inicial
        if (colors.Length > 0)
        {
            if(gameObject.GetComponent<Image>())
            {
                gameObject.GetComponent<Image>().color = colors[currentColorIndex];
            }
            if(gameObject.GetComponent<TextMeshProUGUI>()){

                gameObject.GetComponent<TextMeshProUGUI>().color = colors[currentColorIndex];
            }
        }
    }

    void Update()
    {
        // Cambiar de color si hay más de un color definido y ha pasado el intervalo de tiempo
        if (colors.Length > 1)
        {
            colorChangeTimer += Time.deltaTime;
            if (colorChangeTimer >= colorChangeInterval)
            {
                // Cambiar al siguiente color
                lastColorIndex = currentColorIndex;
                currentColorIndex = (currentColorIndex + 1 < colors.Length) ? currentColorIndex + 1 : 0;
                // Reiniciar el temporizador
                colorChangeTimer = 0f;
            }

            // Calcular el progreso de la transición
            float t = Mathf.Clamp01(colorChangeTimer / colorChangeInterval);

            // Interpolar entre el color actual y el siguiente color
            Color lerpedColor = Color.Lerp(colors[lastColorIndex], colors[currentColorIndex], t);

            // Asignar el color interpolado a los elementos
            if(gameObject.GetComponent<Image>())
            {
                gameObject.GetComponent<Image>().color = lerpedColor;
            }
            if(gameObject.GetComponent<TextMeshProUGUI>()){

                gameObject.GetComponent<TextMeshProUGUI>().color = lerpedColor;
            }
        }
    }
}
