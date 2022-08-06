using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainManager : MonoBehaviour
{
  public BrainState _currenState;
  public BrainFactory _states;


    void Awake() {
        // setup the factory with the BrainManager as a parameter    
        _states = new BrainFactory(this);
        //Set the Basestate as the state launch from the Normal() factory call (So normal State)
        _currenState = _states.MainMenu();
        //Launch enterState on the current State
        _currenState.EnterState();
    }




    void Update() {
        _currenState.UpdateState();
    }
}
