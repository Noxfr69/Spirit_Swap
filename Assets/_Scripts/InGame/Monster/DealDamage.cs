using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TarodevController;

public class DealDamage : MonoBehaviour
{


    [SerializeField] private GameObject RightCollider;
    [SerializeField] private GameObject LeftCollider;
    private IPlayerController _player;
    public int playerDamage;
    private SpriteRenderer SR;




    private void Awake() {
        _player = GetComponent<IPlayerController>();
        SR = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start() {
        _player.Attacked += DealSomeDamage;
    }


    public void DealSomeDamage(){
        if(!SR.flipX){
            var instance = Instantiate(RightCollider,transform.position, Quaternion.identity);
            var atack = instance.GetComponent<PlayerAttackCollider>();
            atack.SetDamage(playerDamage);
        }else{
            var instance = Instantiate(LeftCollider,transform.position, Quaternion.identity);
            var atack = instance.GetComponent<PlayerAttackCollider>();
            atack.SetDamage(playerDamage);

        }
    }
}
