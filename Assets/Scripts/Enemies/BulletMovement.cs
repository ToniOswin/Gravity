using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum MovementType{
    Straight,
    ZigZag,
    circular,
    sinus
}
public class BulletMovement : MonoBehaviour
{
    public MovementType MovType;
   
    public float speed = 1f;
    public float zigzagIntensity = 0.05f;
    public float circularSpeed  = 1f;
    public float circularRadius  = 1f;

    public float sineFrequency  = 1f;
    public float sineAmplitude  = 1f;

    
    private Transform player;

    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").transform;

        
        if (player == null)
        {
            Debug.LogWarning("El jugador no se encontró. Asegúrate de etiquetar al jugador como 'Player'.");
        }
    }

    void Update()
    {
        
        if (player != null)
        {
            switch (MovType){
                case MovementType.Straight:
                    MoveTowardsPlayer();
                    break;
                case MovementType.ZigZag:
                    MoveTowardsPlayerZigzag();
                    break;
                case MovementType.circular:
                    MoveTowardsPlayerCircular();
                    break;
                case MovementType.sinus:
                    MoveTowardsPlayerSinusoidal();
                    break;
                default:
                    MoveTowardsPlayer();
                    break;

            }
        }
    }

    
    void MoveTowardsPlayer()
    {
        
        Vector3 direction = (player.position - transform.position).normalized;

        
        Vector3 movement = direction * speed * Time.deltaTime;

        
        transform.Translate(movement, Space.World);
    }

        void MoveTowardsPlayerZigzag()
    {
        
        Vector3 direction = (player.position - transform.position).normalized;

        
        Vector3 movement = direction * speed * Time.deltaTime;

        
        if (Time.time % 2 < 1) 
        {
            movement += Vector3.Cross(direction, Vector3.forward) * zigzagIntensity;
        }
        else
        {
            movement -= Vector3.Cross(direction, Vector3.forward) * zigzagIntensity;
        }

        
        transform.Translate(movement, Space.World);
    }




        void MoveTowardsPlayerCircular()
    {
        
        Vector3 direction = (player.position - transform.position).normalized;

        
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle += Time.time * circularSpeed;

        
        Vector3 offset = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0f) * circularRadius;

        
        Vector3 movement = offset * Time.deltaTime;

        
        transform.Translate(movement, Space.World);
    }

    void MoveTowardsPlayerSinusoidal()
    {
        
        Vector3 direction = (player.position - transform.position).normalized;

        
        Vector3 movement = direction * speed * Time.deltaTime;

        
        float sineWave = Mathf.Sin(Time.time * sineFrequency) * sineAmplitude;
        movement += Vector3.Cross(direction, Vector3.forward) * sineWave;

        
        transform.Translate(movement, Space.World);
    }


}
