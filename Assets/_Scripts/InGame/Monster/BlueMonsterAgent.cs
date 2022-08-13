using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using MoreMountains.Feedbacks;

public class BlueMonsterAgent : MonoBehaviour
{

    NavMeshAgent Agent;
    private GameObject Player;
    private SpriteRenderer SR;
    public Vector3 AgroDistance = new Vector3(10,10,0);
    private bool Agroed;
    private Vector3 curDistance;
    public float AttackRange = 500;
    public MMF_Player AttackLoading;
    private bool AttackStarted=false;
    public int Monsterdamage= 10;
    public GameObject RangeAttack;




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

    }



    public IEnumerator MonsterAttack(){
        yield return new WaitForSeconds(1f);
        AttackLoading?.PlayFeedbacks();
        var range = Instantiate(RangeAttack, transform.position, Quaternion.identity);
        var Dir = (Player.transform.position - transform.position);
        float n = Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg;
        if(n<0) n += 360;
        range.transform.eulerAngles = new Vector3(0,0,n);
        var rb = range.GetComponent<Rigidbody2D>();
        rb.AddForce(Dir, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1f);
        AttackStarted = false;
        Agent.isStopped = false;

    }

    
}
