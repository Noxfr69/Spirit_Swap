using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuState : BrainState
{
    public MainMenuState(BrainManager brainManager, BrainFactory brainFactory)
    : base (brainManager, brainFactory){}


    public override void CheckSwitchState()
    {
        if(_Brain._startAsked){
            SwitchState(_Factory.StartGame());
        }

        if(_Brain._hubAsked){
            SwitchState(_Factory.HubState());
        }
    }

    public override void EnterState()
    {
        Debug.Log("we are in the MainMenu");
        Scene scene = SceneManager.GetActiveScene();
        if(scene.buildIndex != 0){
            SceneManager.LoadScene("MainMenu");
        }
        
    }

    public override void ExitState()
    {
        Debug.Log("Exiting MainMenu states");
    }

    public override void UpdateState()
    {
        CheckSwitchState();
    }
}
