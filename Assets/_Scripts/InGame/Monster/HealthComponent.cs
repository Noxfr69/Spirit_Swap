using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;


public class HealthComponent : MonoBehaviour
{

    public int Health = 100;
    public float HitCoolDown= 0.15f;
    public bool hit = false;
    private MMF_Player feedback;
    private Vector3 originalScale;
    public MMF_Player DeathFeedback;

    private SpriteRenderer SR;

    private void Awake() {
        SR = GetComponent<SpriteRenderer>();
        feedback = GetComponentInChildren<MMF_Player>();
        originalScale = gameObject.transform.localScale;
    }
    public void OnHit(int damage){

        if(!hit){
            hit = true;
            SR.color = Color.red;
            //play hit sound
            feedback?.PlayFeedbacks();
            StartCoroutine(StartHitCooldown());
            Health -= damage;
            if(Health<=0){
                //play death animation
                //play death sound
                DeathFeedback?.PlayFeedbacks();
                Destroy(gameObject,0.05f);
            }
        }

    }

    public IEnumerator StartHitCooldown(){
        yield return new WaitForSeconds(HitCoolDown);
        gameObject.transform.localScale = originalScale;
        SR.color = Color.white;
        hit = false;
    }

}
