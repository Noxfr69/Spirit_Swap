using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackCollider : MonoBehaviour
{
    private int Damage;
    private TakeDamage _takeDamage;

private void Start() {
    Destroy(gameObject,0.25f);
}

    public void SetDamage(int damage){
        Damage = damage;
    }

    public void SetHealing(TakeDamage takeDamage){
        _takeDamage = takeDamage;
    }


private void OnTriggerEnter2D(Collider2D other) {

    Debug.Log(other);
    other.TryGetComponent<HealthComponent>(out HealthComponent component);
    if(component != null && component.gameObject.layer == 7){
        //if healing secondary
        if(_takeDamage._playerPower.GreenFollower.activeSelf){
            _takeDamage.Heal(5);
        }
        if(PlayerPower.ActivatedPower == 3){
            _takeDamage.Heal(15);
        }
        if(_takeDamage._playerPower.RedFollower.activeSelf){
        component.OnHit(Damage + 20);
        }else{
        component.OnHit(Damage);
        }
        Destroy(gameObject,0.05f);
    }
}


}
