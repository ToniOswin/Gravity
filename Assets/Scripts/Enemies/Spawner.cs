using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
     // Lista de objetos para instanciar
    public List<GameObject> objectsToSpawn = new List<GameObject>();

    // Tiempo entre disparos
    public float timeBetweenShots = 3f;

    // Tiempo acumulado para contar el próximo disparo
    private float elapsedTime = 0f;

    void Update()
    {
        // Actualiza el tiempo acumulado
        elapsedTime += Time.deltaTime;

        // Verifica si es tiempo de disparar
        if (elapsedTime >= timeBetweenShots)
        {
            // Resetea el contador de tiempo
            elapsedTime = 0f;

            // Dispara un objeto al azar
            SpawnRandomObject();
        }
    }

    // Función para instanciar un objeto al azar de la lista
    void SpawnRandomObject()
    {
        if (objectsToSpawn.Count == 0)
        {
            Debug.LogWarning("No hay objetos en la lista para instanciar.");
            return;
        }

        // Escoge un índice aleatorio dentro del rango de la lista
        int randomIndex = Random.Range(0, objectsToSpawn.Count);

        // Instancia el objeto seleccionado en la posición del spawner
        Instantiate(objectsToSpawn[randomIndex], transform.position, Quaternion.identity);
    }
}
