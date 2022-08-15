using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


public class BrainUI : MonoBehaviour
{
    private BrainManager _brain;
    private AudioSource persistentAudio;
    public AudioClip click;


    private void Awake() {
        var brainGO = GameObject.Find("Brain");
        _brain = brainGO.GetComponent<BrainManager>();
        persistentAudio = _brain.GetComponentInChildren<AudioSource>();
    }



    public void OnMenuClick(){
        _brain.MenuAsked();
    }

    public void OnQuitClick(){
        Application.Quit();
    }

    public void OnPlayGameClick(){
        _brain.StartGame();
    }

    public void OnHubClick(){
        _brain.HubAsked();
    }

    public void OnCreditCLick(){
        _brain.CreditAsked();
    }

    public void OnCLick(){
        persistentAudio.PlayOneShot(click);
    }

    public void OnClickTutorial(){
        _brain.TutorialAsked();
    }

}
