using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonLockedOrNot : MonoBehaviour
{
    private MoonCollectScript moonCollectScript;
    public bool isThereMonster;
    private bool letmework;

    private void Awake() {
        moonCollectScript = GetComponentInParent<MoonCollectScript>();
    }



    private void Update() {
        if(letmework)return;
        letmework = true;
        Collider2D[] hit2D = Physics2D.OverlapCircleAll(transform.position,10f);
        foreach (var item in hit2D)
        {
            if(item.gameObject.layer == 7){
                isThereMonster = true;
                moonCollectScript.OnBoolChange(isThereMonster);
                letmework = false;
                return;
            }else{
                isThereMonster = false;
                moonCollectScript.OnBoolChange(isThereMonster);
                letmework = false;
            }
        }
    }


}
