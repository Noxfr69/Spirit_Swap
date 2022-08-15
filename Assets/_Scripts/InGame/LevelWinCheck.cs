using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MoreMountains.Feedbacks;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class LevelWinCheck : MonoBehaviour
{
    public int collectedItem = 0;
    public Color32 lockedcollor = new Color32(111,111,111,188);
    public List<Image> images = new List<Image>();
    BrainManager brainManager;
    [SerializeField] private AudioClip WinAudioClip;
    public AudioMixer MusicMaster;
    private AudioSource persitentAudio;
    private float curentmusiclevel;
    private bool winStarted= false;
    string s;


    private void Awake() {
        collectedItem = 0;
        brainManager = GameObject.Find("Brain").GetComponent<BrainManager>();
        foreach (var item in images)
        {
            item.color = lockedcollor;
        }
        brainManager.CurrentLevelID = SceneManager.GetActiveScene().buildIndex;
        s = brainManager.CurrentLevelID.ToString();
        persitentAudio = brainManager.GetComponentInChildren<AudioSource>();
    }


    public void OnCollectItem(){
        collectedItem ++;
    }

    private void Update() {
        if(collectedItem == 5 && !winStarted){
            winStarted=true;
            brainManager.finaltimer = brainManager.timer;
            persitentAudio.PlayOneShot(WinAudioClip);
            MusicMaster.GetFloat("MusicVolume", out float value);
            curentmusiclevel = value;
            MusicMaster.SetFloat("MusicVolume", -90);

            var current = PlayerPrefs.GetFloat("BestTimeLevel"+s, 999999);
            if(brainManager.finaltimer < current){
                PlayerPrefs.SetFloat("BestTimeLevel"+s, brainManager.finaltimer);
            }
            //unlock the blue power
            if(SceneManager.GetActiveScene().buildIndex == 2){
                if(brainManager.finaltimer%60 < 20f){
                    PlayerPrefs.SetInt("Level1FinishInTime",1);
                }
            }
            StartCoroutine(won());
        }
    }

    public IEnumerator won(){
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(4);
        MusicMaster.SetFloat("MusicVolume", curentmusiclevel);
        Time.timeScale = 1;
        brainManager.WinAsked();
    }
}
