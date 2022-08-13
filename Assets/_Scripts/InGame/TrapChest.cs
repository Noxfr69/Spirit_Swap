using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapChest : MonoBehaviour
{
    public GameObject trap;

    private void Awake() {
        trap.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.layer == 6){
            trap.SetActive(true);
        }
    }
}
