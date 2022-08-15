using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutoscript : MonoBehaviour
{
private void Awake() {
    if(PlayerPrefs.GetInt("TutoDone",0)==1){
        gameObject.SetActive(true);
    }else{gameObject.SetActive(false);}
}
}
