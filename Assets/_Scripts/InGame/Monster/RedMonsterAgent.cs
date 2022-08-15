using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using MoreMountains.Feedbacks;

public class RedMonsterAgent : MonoBehaviour
{

    NavMeshAgent Agent;
    private GameObject Player;
    private SpriteRenderer SR;
    public Vector3 AgroDistance = new Vector3(10,10,0);
    private bool Agroed;
    private Vector3 curDistance;
    public float AttackRange = 500;
    public MMF_Player AttackLoading;
    public MMF_Player Explosion;
    public MMF_Player AgroSound;
    private bool AttackStarted=false;
    private bool Attacking=false;
    public int Monsterdamage= 20;




    private void Awake() {
        Player = GameObject.Find("Player");
        Agent = GetComponent<NavMeshAgent>();
        SR = GetComponent<SpriteRenderer>();
        Agroed = false;
    }
    private void Start() {
        Agent.updateRotation = false;
        Agent.updateUpAxis = false;

    }

    private void Update() {
        curDistance = Player.transform.position - transform.position;
        if(Mathf.Abs(curDistance.x) < AgroDistance.x && Mathf.Abs(curDistance.y) < AgroDistance.y  || Agroed){
            if(!Agroed){
                AgroSound?.PlayFeedbacks();
            }
            Agroed = true;
            Agent.SetDestination(Player.transform.position);

            if(transform.position.x - Player.transform.position.x < 0 ){
                SR.flipX = true;
            }else{SR.flipX = false;}
        }


        if(Vector3.Distance(Player.transform.position, transform.position)< AttackRange && !AttackStarted){
            AttackStarted = true;
            Agent.isStopped = true;
            AttackLoading?.PlayFeedbacks();
            StartCoroutine(MonsterAttack());
        }

        if(AttackStarted && !Attacking){
            Agent.isStopped = true;
        }
    }



    public IEnumerator MonsterAttack(){
        yield return new WaitForSeconds(0.5f);
        AttackLoading?.PlayFeedbacks();
        Agent.speed = 50;
        Attacking = true;
        Agent.isStopped = false;

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(!Attacking)return;
        if(other.gameObject.layer == 6){
            var dmg = other.GetComponent<TakeDamage>();
            dmg.takeDamage(Monsterdamage);
            Explosion?.PlayFeedbacks();
            Destroy(gameObject, 0.5f);
        }

    }
}
