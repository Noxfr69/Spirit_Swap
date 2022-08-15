using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portaltuto : MonoBehaviour
{
    private BrainManager _brain;
    public int levelID;
    private AudioSource persitentAudio;
    public AudioClip portalSound;
    public GameObject checkshrine;

    private void Awake() {
      var Brain = GameObject.Find("Brain");
      _brain = Brain.GetComponent<BrainManager>();
      persitentAudio = _brain.GetComponentInChildren<AudioSource>();
      checkshrine.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) {
      if(other.gameObject.layer == 6 && tutochest.ShrineChecked){
        if(levelID == 1){
          _brain.StartGame();
            persitentAudio.PlayOneShot(portalSound);
          return;
        }
      }else{
        checkshrine.SetActive(true);
      }
    }

    private void OnTriggerExit2D(Collider2D other) {
        checkshrine.SetActive(false);
    }
}
