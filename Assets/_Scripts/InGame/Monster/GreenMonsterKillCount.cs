using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenMonsterKillCount : MonoBehaviour
{
   [SerializeField] private HealthComponent health;
    private int currentHEalth;
    private bool counted = false;


   private void Update() {
    currentHEalth = health.Health;
    if(currentHEalth <= 0 && !counted){
        counted = true;
        int monsterkilled = PlayerPrefs.GetInt("GreenMonsterKill", 0);
        monsterkilled ++;
        PlayerPrefs.SetInt("GreenMonsterKill", monsterkilled);
    }
   }
}
