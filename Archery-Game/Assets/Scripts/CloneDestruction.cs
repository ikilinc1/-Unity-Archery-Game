using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneDestruction : MonoBehaviour
{
    [SerializeField]
    private float duration = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,duration);
    }
}
