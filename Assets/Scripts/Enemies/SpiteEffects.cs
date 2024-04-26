using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiteEffects : MonoBehaviour
{
 // Velocidad de rotación en el eje Z
    public float rotationSpeed = 30f;

    // Colores para el cambio
    public Color[] colors;

    // Tiempo entre cambios de color
    public float colorChangeInterval = 2f;

    // Referencia al SpriteRenderer
    private SpriteRenderer spriteRenderer;

    // Índice del color actual
    private int currentColorIndex = 0;

    // Tiempo acumulado para el cambio de color
    private float colorChangeTimer = 0f;

    void Start()
    {
        // Obtener el componente SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Establecer el color inicial
        if (colors.Length > 0)
        {
            spriteRenderer.color = colors[currentColorIndex];
        }
    }

    void Update()
    {
        // Rotar el objeto en el eje Z
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        // Cambiar de color si hay más de un color definido y ha pasado el intervalo de tiempo
        if (colors.Length > 1)
        {
            colorChangeTimer += Time.deltaTime;
            if (colorChangeTimer >= colorChangeInterval)
            {
                // Cambiar al siguiente color
                currentColorIndex = (currentColorIndex + 1) % colors.Length;
                spriteRenderer.color = colors[currentColorIndex];

                // Reiniciar el temporizador
                colorChangeTimer = 0f;
            }
        }
    }
}
