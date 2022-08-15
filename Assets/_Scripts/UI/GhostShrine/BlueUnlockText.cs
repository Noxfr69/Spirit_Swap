using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlueUnlockText : MonoBehaviour
{

    private TMP_Text unlocktext;

    private void Awake() {
        unlocktext = GetComponent<TMP_Text>();
        var bestTimer = PlayerPrefs.GetFloat("BestTimeLevel2", 99999);
        string minutes1 = ((int) bestTimer / 60).ToString();
        string seconds1 = (bestTimer % 60).ToString("f2"); 
        unlocktext.text = "Finish the first level in less than 20seconds, your current best time is : "+minutes1+":"+seconds1;
    }


}
