using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelState : BrainState
{
    public LevelState(BrainManager brainManager, BrainFactory brainFactory)
    : base (brainManager, brainFactory){}


    public override void CheckSwitchState()
    {
        // logic to execute to see if we want to change state
        // to change state call SwitchState(_Factory.StateNameinFactory()); 
        if(_Brain._menuAsked){
            SwitchState(_Factory.MainMenu());
        }
        if(_Brain._hubAsked){
            SwitchState(_Factory.HubState());
        }
        if(_Brain._DeathAsk){
            SwitchState(_Factory.DeathState());
        }
        if(_Brain._WinAsked){
            SwitchState(_Factory.WinState());
        }
    }

    public override void EnterState()
    {
        // logic to execute when we enter the state
        Debug.Log("we are in the death");
        SceneManager.LoadScene("Level1");
        _Brain.CloseUI();
        _Brain.Timer.SetActive(true);
        _Brain.timer = 0;
    }

    public override void ExitState()
    {
        // logic to execute when leaving this state
        _Brain.Timer.SetActive(false);
    }

    public override void UpdateState()
    {
        // called every frame from the Brain
        CheckSwitchState();
    }

}
