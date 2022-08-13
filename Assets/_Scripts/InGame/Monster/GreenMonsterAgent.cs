using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GreenMonsterAgent : MonoBehaviour
{

    NavMeshAgent Agent;
    private GameObject Player;
    private SpriteRenderer SR;
    public Vector3 AgroDistance = new Vector3(10,10,0);
    private bool Agroed;
    private Vector3 curDistance;
    public float AttackRange = 500;



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
            Agent.SetDestination(new Vector3(Player.transform.position.x, transform.position.y, 0));

            if(transform.position.x - Player.transform.position.x < 0 ){
                SR.flipX = false;
            }else{SR.flipX = true;}
        }


        if(Vector3.Distance(Player.transform.position, transform.position)< AttackRange){
            Agent.isStopped = true;

        }
    }



    public void MonsterAttack(){

    }
}
