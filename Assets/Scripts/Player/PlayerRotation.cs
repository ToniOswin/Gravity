using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
   private float objectZDistance;
   public float flipSmoothing = 5f;
    public Transform spriteTransform;

    void Start()
    {
        objectZDistance = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);
    }

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = objectZDistance;

        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 direction = (mouseWorldPosition - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        bool flipY = angle > 90f || angle < -90f;

        float targetScaleY = flipY ? -1f : 1f;
        float currentScaleY = spriteTransform.localScale.y;
        float smoothedScaleY = Mathf.Lerp(currentScaleY, targetScaleY, flipSmoothing * Time.deltaTime);

        spriteTransform.localScale = new Vector3(spriteTransform.localScale.x, smoothedScaleY, spriteTransform.localScale.z);
    }
    
}
