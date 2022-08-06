
public abstract class BrainState 
{
    protected BrainManager _Brain;
    protected BrainFactory _Factory;
    public BrainState(BrainManager brainManager, BrainFactory brainFactory){
        _Brain = brainManager;
        _Factory = brainFactory;
    }
    
public abstract void EnterState();
public abstract void UpdateState();
public abstract void ExitState();
public abstract void CheckSwitchState();

void UpdateStates(){}

protected void SwitchState(BrainState newState){
    //first leave the current state
    ExitState();
    //then enter the new one that has been passed as data
    newState.EnterState();
    //Let the BrainManager Know about the change of state 
    _Brain._currenState = newState;
    
}




}
