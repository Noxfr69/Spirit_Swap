using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public Transform cameraTransform;
    private Vector3 lastCameraPosition;
    public Vector2 parallaxMultiplayer;



    private void Start() {
        lastCameraPosition = cameraTransform.position;
        Sprite sprite = GetComponentInChildren<SpriteRenderer>().sprite;
    }


    private void LateUpdate() {
        Vector3 delta = cameraTransform.position - lastCameraPosition;
        
        transform.position += new Vector3(delta.x * parallaxMultiplayer.x, delta.y * parallaxMultiplayer.y) ;
        lastCameraPosition = cameraTransform.position;
    }






}
