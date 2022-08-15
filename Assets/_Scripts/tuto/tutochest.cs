using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutochest : MonoBehaviour
{
    public static bool ShrineChecked = false;


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.layer == 6){
            ShrineChecked = true;
        }
    }
}
