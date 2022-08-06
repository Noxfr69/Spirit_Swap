using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleState : BrainState
{
    public ExampleState(BrainManager brainManager, BrainFactory brainFactory)
    : base (brainManager, brainFactory){}


    public override void CheckSwitchState()
    {
        // logic to execute to see if we want to change state
        // to change state call SwitchState(_Factory.StateNameinFactory()); 
    }

    public override void EnterState()
    {
        // logic to execute when we enter the state
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
