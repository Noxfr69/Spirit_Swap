using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MoreMountains.Feedbacks;
using UnityEngine.Audio;


public class TakeDamage : MonoBehaviour
{

    public Image HPFill;
    public int HP = 100;
    public static int Armor = 0;
    BrainManager brainManager;
    public MMF_Player Deathfeedback;
    public MMF_Player Hitfeedback;
    private bool PlayerIsHit = false;
    public AudioMixer MusicMaster;
    private float curentmusiclevel;
    public bool DeathStarted = false;
    public PlayerPower _playerPower;
    private AudioSource persitentAduio;
    public AudioClip DeathAudioClip;

    private void Awake() {
        brainManager = GameObject.Find("Brain").GetComponent<BrainManager>();
        DeathStarted = false;
        _playerPower = GetComponent<PlayerPower>();
        persitentAduio = brainManager.GetComponentInChildren<AudioSource>();
    }

    private void Start() {
        HPFill.fillAmount = 1;
        HP = 100;
    }

    private void Update() {
        if(_playerPower.BlueFollower.activeSelf){
            Armor = 10;
        }else Armor = 0;
    }

    public void Heal(int healing){
        HP += healing;
        if(HP > 100){HP=100;}
        HPFill.fillAmount = (HP / 100f);
    }

    public void takeDamage(int damage){
        if(damage - Armor <= 0 || PlayerIsHit || DeathStarted)return;
        PlayerIsHit = true;
        HP = HP - (damage - Armor);
        HPFill.fillAmount = (HP / 100f);
        Hitfeedback?.PlayFeedbacks();
        StartCoroutine(PlayerHit());

        if(HP<0 && !DeathStarted){
            StartCoroutine(PlayerDeath());
            MusicMaster.GetFloat("MusicVolume", out float value);
            curentmusiclevel = value;
            MusicMaster.SetFloat("MusicVolume", -90);

        }
    }

    public IEnumerator PlayerDeath(){
        DeathStarted = true;
        Deathfeedback?.PlayFeedbacks();
        persitentAduio.PlayOneShot(DeathAudioClip);
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(4f);
        MusicMaster.SetFloat("MusicVolume", curentmusiclevel);
        Time.timeScale = 1;
        brainManager.DeathAsk();
    }
    public IEnumerator PlayerHit(){
        yield return new WaitForSeconds(0.5f);
        PlayerIsHit = false;
    }




}
