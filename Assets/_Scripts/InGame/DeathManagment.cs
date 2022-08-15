using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManagment : MonoBehaviour
{
    BrainManager brainManager;
    private AudioSource persistentAudio;
    public AudioClip click;

    private void Awake() {
        brainManager = GameObject.Find("Brain").GetComponent<BrainManager>();
        persistentAudio = brainManager.GetComponentInChildren<AudioSource>();
    }

    public void OnClickMenu(){
        persistentAudio.PlayOneShot(click);
        brainManager.MenuAsked();
    }

    public void OnClickHub(){
        persistentAudio.PlayOneShot(click);
        brainManager.HubAsked();
    }
}
