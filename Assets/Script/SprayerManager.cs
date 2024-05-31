using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayerManager : MonoBehaviour
{
    [SerializeField]   
    private Vector3 startPos;
    private Vector3 screenPoint;
    private Vector3 offset;

    public ParticleSystem spray;

    private bool holdingSpray = false;
    public int maxParticles = 2000;

    void Start()
    {
        startPos = gameObject.transform.position;    
    }

    private void Update()
    {
        if (holdingSpray)
        {
            if (Input.GetMouseButtonDown(1))
            {
                spray.maxParticles = maxParticles;
                spray.Play();
            }
        }
    }

    void OnMouseDown()
    {
        holdingSpray = true;

        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;

    }

    private void OnMouseUp()
    {
        holdingSpray = false;
        transform.position = startPos;
        spray.maxParticles = 0;
    }
    
}
