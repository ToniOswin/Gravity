using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auras : MonoBehaviour
{
    public bool shield = false;
    BulletStats bulletScript;
    GameManager _gameManager;
    public GameObject defendEffect;
    public GameObject eatEffect;


    public AudioClip blockSound;
    public AudioClip absorbSound;

    void Start(){
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            bulletScript =  other.GetComponent<BulletStats>();
            if(bulletScript.canBeAbsorb){
                if(shield){
                    SoundManager.instance.PlaySound(blockSound);
                }else{
                    SoundManager.instance.PlaySound(absorbSound);
                    _gameManager.AddPoint(bulletScript.points);
                    Instantiate(eatEffect,gameObject.transform.position,Quaternion.identity,gameObject.transform.parent);
                }
                Destroy(other.gameObject);
            }else{
                if(shield){
                    Instantiate(defendEffect,gameObject.transform.position,Quaternion.identity, gameObject.transform.parent);
                    _gameManager.AddPoint(bulletScript.points);
                    SoundManager.instance.PlaySound(blockSound);
                }else{
                    _gameManager.getDamage(bulletScript.damage);
                }
                Destroy(other.gameObject);
            }
            
        }
    }
}
