using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowController : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 0.5f;
    
    [SerializeField]
    private Vector2 rotationRange = new Vector2(50, 95);
    
    private Vector3 targetAngle;
    private Quaternion startRotation;
    
    // Start is called before the first frame update
    void Start()
    {
        startRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        targetAngle.y += Input.GetAxis("Mouse X") * rotationSpeed;
        targetAngle.x += Input.GetAxis("Mouse Y") * rotationSpeed;

        targetAngle.y = Mathf.Clamp(targetAngle.y, -rotationRange.y * 0.5f, rotationRange.y * 0.5f);
        targetAngle.x = Mathf.Clamp(targetAngle.x, -rotationRange.x * 0.5f, rotationRange.x * 0.5f);
        
        Quaternion targetRotation = Quaternion.Euler(-targetAngle.x, targetAngle.y, 0);
        transform.localRotation = startRotation * targetRotation;
    }
}
