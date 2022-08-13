using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GreenUnlockTexte : MonoBehaviour
{
    private TMP_Text text;

    private void Awake() {
        text = GetComponent<TMP_Text>();
        string monsterkilled = PlayerPrefs.GetInt("GreenMonsterKill", 0).ToString();
        text.text = "Kill 20 slime, you've already killed : " + monsterkilled;
        
    }
}
