using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenMonsterDamage : MonoBehaviour
{

    public int Monsterdamage = 10;

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.layer == 6){
            var dealdmg = other.collider.GetComponent<TakeDamage>();
            dealdmg.takeDamage(Monsterdamage);
        }
    }
}
