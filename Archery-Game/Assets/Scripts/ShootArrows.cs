using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootArrows : MonoBehaviour
{
    [SerializeField]
    private GameObject arrowPrefab;

    [SerializeField]
    private Transform arrowTransform;

    [SerializeField]
    private float maximumArrowForce = 200f;

    private AudioSource bowStretchSound;
    private float currentArrowForce;
    
    private float maxLerpTime = 1f;
    private float currentLerpTime;

    private Animator bowAnimator;
    
    // Start is called before the first frame update
    void Start()
    {
        bowAnimator = GetComponent<Animator>();
        bowStretchSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                DrawBow();
            }

            if (Input.GetMouseButton(0))
            {
                PowerUpBow();
            }

            if (Input.GetMouseButtonUp(0))
            {
                ReleaseBow();
            }
        }
        else if (!GameManager.gameStarted)
        {
            bowAnimator.SetBool("drawing", false);
            currentArrowForce = 0;
            bowStretchSound.Stop();
        }
    }

    private void DrawBow()
    {
        bowAnimator.SetBool("drawing", true);
        bowStretchSound.Play();
    }

    private void PowerUpBow()
    {
        if (bowAnimator.GetBool("drawing"))
        {
            currentLerpTime += Time.deltaTime;

            if (currentLerpTime > maxLerpTime)
            {
                currentLerpTime = maxLerpTime;
            }

            float perc = currentLerpTime / maxLerpTime;
            currentArrowForce = Mathf.Lerp(0, maximumArrowForce, perc);
        }
    }

    private void ReleaseBow()
    {
        bowAnimator.SetBool("drawing", false);

        GameObject arrow = Instantiate(arrowPrefab, arrowTransform.position, arrowTransform.rotation) as GameObject;
        arrow.GetComponent<Rigidbody>().AddForce(arrowTransform.forward * currentArrowForce);

        currentLerpTime = 0;
        currentArrowForce = 0;
        
        bowStretchSound.Stop();
    }
}
