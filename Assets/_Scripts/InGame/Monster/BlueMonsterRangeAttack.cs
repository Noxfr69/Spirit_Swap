using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueMonsterRangeAttack : MonoBehaviour
{

    public int damage = 20;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.layer == 6){
           var dmg = other.GetComponent<TakeDamage>();
           dmg.takeDamage(damage);
           Destroy(gameObject, 0.05f);
        }
    }
    
    private void Awake() {
        Destroy(gameObject, 5f);
    }
}
