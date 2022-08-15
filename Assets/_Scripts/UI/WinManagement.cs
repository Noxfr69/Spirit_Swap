using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinManagement : MonoBehaviour
{
    BrainManager brainManager;
    public TMP_Text wintext;
    public TMP_Text besttimetext;
    private float timer;
    private float bestTimer;
    private string s;
    private AudioSource persistentAudio;
    public AudioClip click;

    private void Awake() {
        brainManager = GameObject.Find("Brain").GetComponent<BrainManager>();
        persistentAudio = brainManager.GetComponentInChildren<AudioSource>();
        timer = brainManager.finaltimer;
        string minutes = ((int) timer / 60).ToString();
        string seconds = (timer % 60).ToString("f2");
        wintext.text = "Congrats you finished this level in "+ minutes+":"+seconds;
        //////////////////////////////////////////////////////////////////////////////////
        s = brainManager.CurrentLevelID.ToString();
        bestTimer = PlayerPrefs.GetFloat("BestTimeLevel"+s, 99999);
        string minutes1 = ((int) bestTimer / 60).ToString();
        string seconds1 = (bestTimer % 60).ToString("f2"); 
        besttimetext.text = "Your best time on this level is "+minutes1+":"+seconds1;

    }

    public void OnClickMenu(){
        brainManager.MenuAsked();
    }

    public void OnClickHub(){
        brainManager.HubAsked();
    }

    public void OnCLick(){
        persistentAudio.PlayOneShot(click);
    }


}
