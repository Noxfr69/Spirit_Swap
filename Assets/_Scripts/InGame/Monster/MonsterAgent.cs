using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAgent : MonoBehaviour
{

    NavMeshAgent Agent;
    private GameObject Player;
    private SpriteRenderer SR;


    private void Awake() {
        Player = GameObject.Find("Player");
        Agent = GetComponent<NavMeshAgent>();
        SR = GetComponent<SpriteRenderer>();
    }
    private void Start() {
        Agent.updateRotation = false;
        Agent.updateUpAxis = false;
    }

    private void Update() {
        Agent.SetDestination(Player.transform.position);

        if(transform.position.x - Player.transform.position.x < 0 ){
            SR.flipX = true;
        }else{SR.flipX = false;}

    }
}
