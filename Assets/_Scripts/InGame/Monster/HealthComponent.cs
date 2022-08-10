using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthComponent : MonoBehaviour
{

    public int Health = 100;
    public float HitCoolDown= 0.15f;
    public bool hit = false;

    private SpriteRenderer SR;

    private void Awake() {
        SR = GetComponent<SpriteRenderer>();
    }
    public void OnHit(int damage){

        if(!hit){
            hit = true;
            SR.color = Color.red;
            //play hit sound
            StartCoroutine(StartHitCooldown());
            Health -= damage;
            if(Health<=0){
                //play death animation
                //play death sound
                Destroy(gameObject,0.05f);
            }
        }

    }

    public IEnumerator StartHitCooldown(){
        yield return new WaitForSeconds(HitCoolDown);
        SR.color = Color.white;
        hit = false;
    }

}
