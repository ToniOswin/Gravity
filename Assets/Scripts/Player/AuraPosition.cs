using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraPosition : MonoBehaviour
{
        public Transform objetivo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
     void FixedUpdate(){
        if (objetivo != null)
                {
                    // Mantener la posición del objeto igual a la posición del objetivo
                    transform.position = objetivo.position;
                    transform.rotation = objetivo.rotation;
                }
                else
                {
                    Debug.LogWarning("El objetivo al que seguir no está asignado.");
                }
    }
}
