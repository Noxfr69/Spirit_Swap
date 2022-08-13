using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPower : MonoBehaviour
{
    public static int ActivatedPower;
    public static int SecondaryPower;
    public GhostPower Power1;
    public GhostPower Power2;
    public GhostPower Power3;
    public bool isPower1Unlocked;
    public bool isPower2Unlocked;
    public bool isPower3Unlocked;
    public GameObject RedFollower;
    public GameObject BlueFollower;
    public GameObject GreenFollower;
    public List<GhostPower>GhostPowers = new List<GhostPower>();
    private GhostHolderUI ghostpowerUI;



    private void Awake() {
        RedFollower.SetActive(false);
        GreenFollower.SetActive(false);
        BlueFollower.SetActive(false);
        ghostpowerUI = GameObject.Find("GhostHolderUI").GetComponent<GhostHolderUI>();
        SetPowers(1,2,3);
    }

    private void Start() {
        UpdatePowers();
    }


    public void UpdatePowers(){
        Power1 = GhostPowers[PlayerPrefs.GetInt("Power1", 1)];
        Power2 = GhostPowers[PlayerPrefs.GetInt("Power2", 2)];
        Power3 = GhostPowers[PlayerPrefs.GetInt("Power3", 3)];
        if(PlayerPrefs.GetInt("isPower1Unlocked", 0) == 1){
        isPower1Unlocked = true;
        }
        if(PlayerPrefs.GetInt("isPower2Unlocked", 0) == 1){
        isPower2Unlocked = true;
        }
        if(PlayerPrefs.GetInt("isPower3Unlocked", 0) == 1){
        isPower3Unlocked = true;
        }
        
        ghostpowerUI.UpdatePowersUI(this);
    }

    public void SetPowers(int power1, int power2, int power3){
        PlayerPrefs.SetInt("Power1", power1);
        PlayerPrefs.SetInt("Power2", power2);
        PlayerPrefs.SetInt("Power3", power3);
    }

    public void UnlockSpell(int spell1, int spell2, int spell3){
        PlayerPrefs.SetInt("isPower1Unlocked", spell1);
        PlayerPrefs.SetInt("isPower2Unlocked", spell2);
        PlayerPrefs.SetInt("isPower3Unlocked", spell3);
    }

}
