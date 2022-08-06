using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuState : BrainState
{
    public MainMenuState(BrainManager brainManager, BrainFactory brainFactory)
    : base (brainManager, brainFactory){}


    public override void CheckSwitchState()
    {

    }

    public override void EnterState()
    {
        Debug.Log("we are in the MainMenu");
    }

    public override void ExitState()
    {

    }

    public override void UpdateState()
    {
        CheckSwitchState();
    }
}
