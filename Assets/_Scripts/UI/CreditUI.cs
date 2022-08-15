using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditUI : MonoBehaviour
{
    private BrainManager brainManager;
    private AudioSource persistentAudio;
    public AudioClip click;



    private void Awake() {
        brainManager = GameObject.Find("Brain").GetComponent<BrainManager>();
        persistentAudio = brainManager.GetComponentInChildren<AudioSource>();
    }

    public void OnCLickMenu(){
        brainManager.MenuAsked();
    }
    
    public void OnCLick(){
        persistentAudio.PlayOneShot(click);
    }
}
