using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangeAttack : MonoBehaviour
{

    public int damage = 30;
    int enemyhit;
    private TakeDamage takeDamage;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.layer == 7){
           var dmg = other.GetComponent<HealthComponent>();
           if(PlayerPower.SecondaryPower == 1){
            dmg.OnHit(damage + 20);
           }else{
            dmg.OnHit(damage);
           }
           if(takeDamage._playerPower.GreenFollower.activeSelf){
            takeDamage.Heal(5);
           }
           enemyhit ++;
           if(enemyhit == 5){
           Destroy(gameObject, 0.05f);
           }
        }
    }
    
    private void Awake() {
        takeDamage = GameObject.Find("Player").GetComponent<TakeDamage>();
        Destroy(gameObject, 5f);
        enemyhit = 0;
    }
}
