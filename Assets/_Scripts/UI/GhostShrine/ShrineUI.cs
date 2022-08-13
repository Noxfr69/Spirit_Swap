using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShrineUI : MonoBehaviour
{
    private GhostChest shrine;
    public List<GameObject> SpellInfo = new List<GameObject>();
    private int currentSlide = 0;
    public PlayerPower playerPower;
    public GameObject CantUnlockTexte;
    public GameObject power1Pics;
    public GameObject power2Pics;
    public GameObject power3Pics;

    private void OnEnable() {
        BrainManager.CloseYourUI += CloseUI;    
    }
    private void OnDisable() {
        BrainManager.CloseYourUI -= CloseUI;    
    }

    private void Start() {
        
        SpellInfo[0].SetActive(true);
        SpellInfo[1].SetActive(false);
        SpellInfo[2].SetActive(false);
        CantUnlockTexte.SetActive(false);
    }

    public void CloseUI(){
        gameObject.SetActive(false);
    }

    public void OnclickCLose(){
        shrine.wasJustClosed = true;
        Time.timeScale = 1;
        shrine.StartCoroutine(shrine.justClosed());
        gameObject.SetActive(false);
    }

    public void Onopen(GhostChest ghostChest){
       shrine = ghostChest;

       if(playerPower.isPower1Unlocked){
        power1Pics.SetActive(true);
       }else{power1Pics.SetActive(false);}

       if(playerPower.isPower2Unlocked){
        power2Pics.SetActive(true);
       }else{power2Pics.SetActive(false);}

       if(playerPower.isPower3Unlocked){
        power3Pics.SetActive(true);
       }else{power3Pics.SetActive(false);}
       
    }
    

    public void OnArrowRight(){
        SpellInfo[currentSlide].SetActive(false);
        currentSlide++;
        if(currentSlide > 2){currentSlide = 2;}
        SpellInfo[currentSlide].SetActive(true);
        
    }
    public void OnArrowLeft(){
        SpellInfo[currentSlide].SetActive(false);
        currentSlide--;
        if(currentSlide < 0){currentSlide = 0;}
        SpellInfo[currentSlide].SetActive(true);
    }

    public void OnClickUnlock(){
        if(currentSlide == 0){
            PlayerPrefs.SetInt("isPower1Unlocked", 1);
            playerPower.UpdatePowers();
            power1Pics.SetActive(true);
        }
        if(currentSlide == 1){
            //unlock logic
            if(PlayerPrefs.GetInt("Level1FinishInTime", 0) == 1){
                PlayerPrefs.SetInt("isPower2Unlocked", 1);
                playerPower.UpdatePowers();
                power2Pics.SetActive(true);
            }else{
            StartCoroutine(Cantunlockthis());
            }
        }
        if(currentSlide == 2){
            if(PlayerPrefs.GetInt("GreenMonsterKill", 0) >= 20){
                PlayerPrefs.SetInt("isPower3Unlocked", 1);
                playerPower.UpdatePowers();
                power3Pics.SetActive(true);
            }else StartCoroutine(Cantunlockthis());
        }
    }

    public IEnumerator Cantunlockthis(){
        CantUnlockTexte.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        CantUnlockTexte.SetActive(false);
    }
}
