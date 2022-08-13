using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainFactory
{
BrainManager _Brain;

public BrainFactory(BrainManager brainManager){
    _Brain = brainManager;
}

public BrainState MainMenu(){
    return new MainMenuState(_Brain, this);
}
public BrainState StartGame(){
    return new LevelState(_Brain, this);
}
public BrainState HubState(){
    return new HubState(_Brain, this);
}

public BrainState DeathState(){
    return new DeathState(_Brain, this);
}

public BrainState WinState(){
    return new WinState(_Brain, this);
}
}
