using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BackgroundFullscreen : MonoBehaviour
{
    [SerializeField] private Transform camera;
    [Range(0f, 1f)]
    [SerializeField] private float parallaxFactor = 1f;
    private float tileWidth;
    private float startX;
    void Start()
    {
        if (camera == null)
        { 
        camera = Camera.main.transform;
        startX = transform.position.x;
        tileWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        }
       
    }

    void LateUpdate()
    {
        float distance = camera.position.x * parallaxFactor;
        float newX = startX + distance;
        float temp = camera.position.x * (1f - parallaxFactor);
        if (temp > startX + tileWidth)
        {
            startX += tileWidth;
        }
        else if (temp < startX - tileWidth)
        {
            startX -= tileWidth;
        }
        transform.position = new Vector3(startX + distance, transform.position.y, transform.position.z);
    }
}
