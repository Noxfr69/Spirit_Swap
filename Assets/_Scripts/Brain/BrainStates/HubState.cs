using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HubState : BrainState
{
    public HubState(BrainManager brainManager, BrainFactory brainFactory)
    : base (brainManager, brainFactory){}


    public override void CheckSwitchState()
    {
        // logic to execute to see if we want to change state
        // to change state call SwitchState(_Factory.StateNameinFactory()); 
        if(_Brain._startAsked){
            SwitchState(_Factory.StartGame());
        }
        if(_Brain._menuAsked){
            SwitchState(_Factory.MainMenu());
        }
        if(_Brain._Level2Asked){
            SwitchState(_Factory.Level2State());
        }
        if(_Brain._Level3Asked){
            SwitchState(_Factory.Level3State());
        }
        if(_Brain._Level4Asked){
            SwitchState(_Factory.Level4State());
        }
    }

    public override void EnterState()
    {
        // logic to execute when we enter the state
         Debug.Log("we are in the hub");
        SceneManager.LoadScene("Hub");
    }

    public override void ExitState()
    {
        // logic to execute when leaving this state
    }

    public override void UpdateState()
    {
        // called every frame from the Brain
        CheckSwitchState();
    }
}
