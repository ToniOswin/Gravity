using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerActions : MonoBehaviour
{

    PlayerRotation _rotationScript;
    public GameObject shield;
    public GameObject absorber;

    public GameObject[] FaceArray;
    bool shielding = false;
    bool absorbin = false;

    void Start(){
        _rotationScript = GetComponent<PlayerRotation>();
    }
     void Update()
    {
        if (Input.GetMouseButtonDown(0) && !Input.GetMouseButton(1))
        {
            Defend(true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            Defend(false);          
        }


        if (Input.GetMouseButtonDown(1) && !Input.GetMouseButton(0))
        {
            Absorb(true);
        }
        if (Input.GetMouseButtonUp(1))
        {
            Absorb(false);
        }
    }

     void Defend(bool active)
    {
        shield.SetActive(active);
        if(active){
            changeFace(1);
        }else{

            changeFace(0);
        }

    }

    void Absorb(bool active)
    {
        absorber.SetActive(active);
                if(active){
            changeFace(2);
        }else{

            changeFace(0);
        }

    }

    void changeFace(int face){
        for (int i = 0; i < FaceArray.Length; i++)
        {
            if(i == face)
            {
                FaceArray[i].SetActive(true);
                _rotationScript.spriteTransform = FaceArray[i].transform;
            }else{
                FaceArray[i].SetActive(false);
            }
        }
    }
}
