using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackCollider : MonoBehaviour
{
    private int Damage;

private void Start() {
    Destroy(gameObject,0.25f);
}

    public void SetDamage(int damage){
        Damage = damage;
    }

private void OnTriggerStay2D(Collider2D other) {

    Debug.Log(other);
    other.TryGetComponent<HealthComponent>(out HealthComponent component);
    if(component != null && component.gameObject.layer == 7){
        component.OnHit(Damage);
        Destroy(gameObject,0.1f);
    }
}


}
