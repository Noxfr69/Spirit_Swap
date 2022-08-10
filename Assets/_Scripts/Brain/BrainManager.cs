using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainManager : MonoBehaviour
{
  public BrainState _currenState;
  public BrainFactory _states;


  public bool _menuAsked = false;
  public bool _startAsked = false;
  public bool _hubAsked = false;


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

    #region State change

    public void MenuAsked(){
        _menuAsked = true;
        StartCoroutine(ChangeBool());
    }

    public void StartGame(){
        _startAsked = true;
        StartCoroutine(ChangeBool());
    }

    public void HubAsked(){
        _hubAsked = true;
        StartCoroutine(ChangeBool());
    }

    public IEnumerator ChangeBool(){
        yield return new WaitForSeconds(0.5f);
        _menuAsked = false;
        _hubAsked = false;
        _startAsked = false;
    }

    #endregion
}
