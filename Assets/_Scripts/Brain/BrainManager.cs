using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class BrainManager : MonoBehaviour
{
  public BrainState _currenState;
  public BrainFactory _states;


  public bool _menuAsked = false;
  public bool _startAsked = false;
  public bool _hubAsked = false;
  public bool _DeathAsk = false;
  public bool _WinAsked = false;
  public static event Action CloseYourUI;
  public GameObject Timer;
  public float timer;
  public float finaltimer;
  public int CurrentLevelID;

    void Awake() {
        // setup the factory with the BrainManager as a parameter    
        _states = new BrainFactory(this);
        //Set the Basestate as the state launch from the Normal() factory call (So normal State)
        _currenState = _states.MainMenu();
        //Launch enterState on the current State
        _currenState.EnterState();
        Timer.SetActive(false);
    }





    void Update() {
        _currenState.UpdateState();
        if(Timer.activeSelf){
        timer += Time.deltaTime;
        string minutes = ((int) timer / 60).ToString();
        string seconds = (timer % 60).ToString("f2");
        Timer.GetComponentInChildren<TMP_Text>().text = minutes + ":" + seconds;
        }

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

    public void DeathAsk(){
        _DeathAsk = true;
        StartCoroutine(ChangeBool());
    }

    public void WinAsked(){
        _WinAsked = true;
        StartCoroutine(ChangeBool());
    }

    public IEnumerator ChangeBool(){
        yield return new WaitForSeconds(0.5f);
        _menuAsked = false;
        _hubAsked = false;
        _startAsked = false;
        _DeathAsk = false;
        _WinAsked = false;
    }

    #endregion

    public void CloseUI(){
        StartCoroutine(Close());
    }
    public IEnumerator Close(){
        yield return new WaitForSeconds(0.01f);
        CloseYourUI?.Invoke();
    }

}
