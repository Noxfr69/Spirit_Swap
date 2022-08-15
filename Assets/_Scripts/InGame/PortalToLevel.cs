using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalToLevel : MonoBehaviour
{
    private BrainManager _brain;
    public int levelID;
    private AudioSource persitentAudio;
    public AudioClip portalSound;

    private void Awake() {
      var Brain = GameObject.Find("Brain");
      _brain = Brain.GetComponent<BrainManager>();
      persitentAudio = _brain.GetComponentInChildren<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
      if(other.gameObject.layer == 6 || other.gameObject.layer == 8){
        persitentAudio.PlayOneShot(portalSound);
        if(levelID == 1){
          _brain.StartGame();
          return;
        }
        if(levelID == 2){
          _brain.Level2Asked();
          return;
        }
        if(levelID == 3){
          _brain.Level3Asked();
          return;
        }
        if(levelID == 4){
          _brain.Level4Asked();
          return;
        }
      }

    }
        
    

}
