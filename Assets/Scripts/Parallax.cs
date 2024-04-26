using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ParallaxLayer
{
    public Transform backgroundLayer;
    public float layerSpeed;
    public float backgroundWidth;
}
public class Parallax : MonoBehaviour
{
   public ParallaxLayer[] layers;

    void Update()
    {
        foreach (ParallaxLayer layer in layers)
        {
            // Calcular el desplazamiento
            float offsetX = Time.deltaTime * layer.layerSpeed;

            // Mover la capa de fondo
            layer.backgroundLayer.position += Vector3.left * offsetX;

            // Verificar si la capa de fondo ha salido completamente de la pantalla por la izquierda
            if (layer.backgroundLayer.position.x < -layer.backgroundWidth)
            {
                // Reposicionar la capa de fondo al lado derecho de la pantalla para crear un efecto de bucle
                layer.backgroundLayer.position += Vector3.right * (layer.backgroundWidth * 2);
            }
        }
    }
}
