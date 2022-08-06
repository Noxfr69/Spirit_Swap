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


}
