using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalToLevel : MonoBehaviour
{
    private BrainManager _brain;
    public string destination;

    private void Awake() {
      var Brain = GameObject.Find("Brain");
      _brain = Brain.GetComponent<BrainManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("triggered");
        _brain.StartGame();
    }

}
