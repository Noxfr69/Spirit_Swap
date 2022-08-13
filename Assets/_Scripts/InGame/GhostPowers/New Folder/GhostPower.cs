using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName ="new GhostPower")]
public class GhostPower : ScriptableObject
{
    public Color swordColor;
    public Sprite ghostImage;
    public bool powerActivted;
    public bool isUnlocked = false;
    public int ID;

    public virtual void ActivatedPower(){}
    public virtual void PassivePower(){}

}
