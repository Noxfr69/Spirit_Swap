using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TarodevController;

public class DealDamage : MonoBehaviour
{


    [SerializeField] private GameObject RightCollider;
    [SerializeField] private GameObject LeftCollider;
    [SerializeField] private GameObject RangeAttack;
    private IPlayerController _player;
    public int playerDamage;
    public SpriteRenderer SR;
    private TakeDamage takeDamage;
    private PlayerPower playerPower;
    private Animator anim;
    public RuntimeAnimatorController normalSword;
    public RuntimeAnimatorController bigSword;
    private bool AttackCooldown = false;
    



    private void Awake() {
        _player = GetComponent<IPlayerController>();
        takeDamage = GetComponent<TakeDamage>();
        playerPower = GetComponent<PlayerPower>();
        anim = SR.gameObject.GetComponent<Animator>();
        AttackCooldown = false;
    }

    private void Start() {
        _player.Attacked += DealSomeDamage;
    }


    public void DealSomeDamage(){
        if(AttackCooldown)return;
        AttackCooldown = true;
        StartCoroutine(CoolDown());
        if(PlayerPower.ActivatedPower == 1){
            if(!SR.flipX)
            {
                var instance = Instantiate(RightCollider,transform.position, Quaternion.identity);
                instance.transform.localScale = new Vector3(2,2,2);
                anim.runtimeAnimatorController = bigSword;
                StartCoroutine(ChangeAnimator());
                var atack = instance.GetComponent<PlayerAttackCollider>();
                atack.SetDamage(playerDamage);
                atack.SetHealing(takeDamage);

            }else
            {
                var instance = Instantiate(LeftCollider,transform.position, Quaternion.identity);
                instance.transform.localScale = new Vector3(2,2,2);
                anim.runtimeAnimatorController = bigSword;
                StartCoroutine(ChangeAnimator());
                var atack = instance.GetComponent<PlayerAttackCollider>();
                atack.SetDamage(playerDamage);
                atack.SetHealing(takeDamage);
            }
            return;
        }


        if(PlayerPower.ActivatedPower == 2){
            var rangeAttack = Instantiate(RangeAttack, transform.position, Quaternion.identity);
            var rb = rangeAttack.GetComponent<Rigidbody2D>();
            if(SR.flipX){
                rb.AddForce(new Vector2(-1,0)*10, ForceMode2D.Impulse);
                rangeAttack.transform.eulerAngles = new Vector3(0,-180,0);
            }else{
                rb.AddForce(new Vector2(1,0)*10, ForceMode2D.Impulse);
            }
        }


        if(!SR.flipX){
            var instance = Instantiate(RightCollider,transform.position, Quaternion.identity);
            var atack = instance.GetComponent<PlayerAttackCollider>();
            atack.SetDamage(playerDamage);
            atack.SetHealing(takeDamage);

        }else{
            var instance = Instantiate(LeftCollider,transform.position, Quaternion.identity);
            var atack = instance.GetComponent<PlayerAttackCollider>();
            atack.SetDamage(playerDamage);
            atack.SetHealing(takeDamage);
        }

        // use the playerpower activated ID to add the special attack
    }


    public IEnumerator ChangeAnimator(){
        yield return new WaitForSeconds(0.2f);
        anim.runtimeAnimatorController = normalSword;
    }

    public IEnumerator CoolDown(){
        yield return new WaitForSecondsRealtime(0.20f);
        AttackCooldown = false;
    }
}
