using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controltutoscript : MonoBehaviour
{
    public GameObject controls;


    private void Awake() {
        controls.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D other) {
        controls.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other) {
        controls.SetActive(false);
    }



}
