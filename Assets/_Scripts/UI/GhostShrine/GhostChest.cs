using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostChest : MonoBehaviour
{
    private GameObject PowerCanvas;
    ShrineUI shrineUI;
    public bool wasJustClosed = false;

    private void Awake() {
        PowerCanvas = GameObject.Find("ChoosePowers");
        shrineUI = PowerCanvas.GetComponent<ShrineUI>();
        Debug.Log(shrineUI);
        PowerCanvas.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other);
        if(other.gameObject.layer == 6 ){
            if(!wasJustClosed){
                PowerCanvas.SetActive(true);
                 Time.timeScale = 0;
                shrineUI.Onopen(this);
            }
        }
    }
    public IEnumerator justClosed(){
        Debug.Log("in the coroutine");
        yield return new WaitForSeconds(0.75f);
        wasJustClosed = false;
    }    
}
