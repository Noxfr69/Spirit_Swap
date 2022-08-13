using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManagment : MonoBehaviour
{
    BrainManager brainManager;

    private void Awake() {
        brainManager = GameObject.Find("Brain").GetComponent<BrainManager>();
    }

    public void OnClickMenu(){
        brainManager.MenuAsked();
    }

    public void OnClickHub(){
        brainManager.HubAsked();
    }
}
