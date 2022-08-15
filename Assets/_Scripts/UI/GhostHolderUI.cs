using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TarodevController;

public class GhostHolderUI : MonoBehaviour
{

    [SerializeField] private SpriteRenderer _swordSR;
    [SerializeField] private Image Ghost1;
    [SerializeField] private Image Ghost2;
    [SerializeField] private Image Ghost3;
    [SerializeField] private Image GhostSprite1;
    [SerializeField] private Image GhostSprite2;
    [SerializeField] private Image GhostSprite3;
    [SerializeField] private GhostPower soGhost1;
    [SerializeField] private GhostPower soGhost2;
    [SerializeField] private GhostPower soGhost3;
    [SerializeField] private Color Selected;
    [SerializeField] private Color unSelected;
    PlayerPower _playerPower;

    private bool tryingtopowerup;

    [SerializeField] private PlayerController _playerController;
    private GhostPower CurrentSelected;





    void Awake() {
        var Player = GameObject.Find("Player");
        PlayerController playerController = Player.GetComponent<PlayerController>();
        playerController.Fpressed += ChangingGhostSelection;
        Ghost1.color = Selected;
        _swordSR.color = Color.white;
    }


    public void UpdatePowersUI(PlayerPower playerPower){
        _playerPower = playerPower;
        soGhost1 = playerPower.Power1;
        soGhost2 = playerPower.Power2;
        soGhost3 = playerPower.Power3;

        soGhost1.powerActivted = false;
        soGhost2.powerActivted = false;
        soGhost3.powerActivted = false;
        PlayerPower.ActivatedPower = 0;



        if(PlayerPrefs.GetInt("isPower1Unlocked", 0) == 1){
        PlayerPower.SecondaryPower = soGhost1.ID;
        GhostSprite1.sprite = soGhost1.ghostImage;
        playerPower.RedFollower.SetActive(true);
        }
        if(playerPower.isPower2Unlocked){GhostSprite2.sprite = soGhost2.ghostImage;}
        if(playerPower.isPower3Unlocked){GhostSprite3.sprite = soGhost3.ghostImage;}
        

        CurrentSelected = soGhost1;     
    }





    public void ChangingGhostSelection(){
        Debug.Log("we are in the ui ghost selection");
        if(CurrentSelected == soGhost1){
            Ghost1.color = unSelected;
            Ghost2.color = Selected;
            CurrentSelected = soGhost2;
            if(_playerPower.isPower2Unlocked){
                _playerPower.BlueFollower.SetActive(true);
                _playerPower.RedFollower.SetActive(false);
                _playerPower.GreenFollower.SetActive(false);
                PlayerPower.SecondaryPower = soGhost2.ID;
            }
            return;
        }
        if(CurrentSelected == soGhost2){
            Ghost2.color = unSelected;
            Ghost3.color = Selected;
            CurrentSelected = soGhost3;
            if(_playerPower.isPower3Unlocked){
                _playerPower.BlueFollower.SetActive(false);
                _playerPower.RedFollower.SetActive(false);
                _playerPower.GreenFollower.SetActive(true);
                PlayerPower.SecondaryPower = soGhost3.ID;
            }
            return;
        }
        if(CurrentSelected == soGhost3){
            Ghost3.color = unSelected;
            Ghost1.color = Selected;
            CurrentSelected = soGhost1;
            if(_playerPower.isPower1Unlocked){
                _playerPower.BlueFollower.SetActive(false);
                _playerPower.RedFollower.SetActive(true);
                _playerPower.GreenFollower.SetActive(false);
                PlayerPower.SecondaryPower = soGhost1.ID;
            }
            return;
        }
    }

    private void Update() {

        if(!_playerController._ghostHoldPowerup){
            tryingtopowerup = false;
        }
        if(!tryingtopowerup){
            reachPowerCheck();
        }

            
        if(_playerController._ghostHoldPowerup){
            tryingtopowerup = true;
            if(CurrentSelected == soGhost1 && soGhost1.ID != 0 && _playerPower.isPower1Unlocked){
                var currentFill = Ghost1.GetComponent<Fillholder>();
                currentFill.fill.fillAmount -= 0.5f * Time.deltaTime;
                if(currentFill.fill.fillAmount == 0){
                    _swordSR.color = soGhost1.swordColor;
                    soGhost1.powerActivted = true;
                    PlayerPower.ActivatedPower = soGhost1.ID;
                    soGhost2.powerActivted = false;
                    soGhost3.powerActivted = false;
                }
        }
            if(CurrentSelected == soGhost2 && soGhost2.ID != 0 && _playerPower.isPower2Unlocked){
                var currentFill = Ghost2.GetComponent<Fillholder>();
                currentFill.fill.fillAmount -= 0.5f * Time.deltaTime;
                if(currentFill.fill.fillAmount == 0){
                    _swordSR.color = soGhost2.swordColor;
                    soGhost1.powerActivted = false;
                    soGhost2.powerActivted = true;
                    PlayerPower.ActivatedPower = soGhost2.ID;
                    soGhost3.powerActivted = false;
                }
        }
            if(CurrentSelected == soGhost3 && soGhost3.ID != 0 && _playerPower.isPower3Unlocked){
                var currentFill = Ghost3.GetComponent<Fillholder>();
                currentFill.fill.fillAmount -= 0.5f * Time.deltaTime;
                if(currentFill.fill.fillAmount == 0){
                    _swordSR.color = soGhost3.swordColor;
                    soGhost1.powerActivted = false;
                    soGhost2.powerActivted = false;
                    soGhost3.powerActivted = true;
                    PlayerPower.ActivatedPower = soGhost3.ID;
                }
        }


        
        }
            
    }


    public void reachPowerCheck(){
            if(!soGhost1.powerActivted){
                var currentFill = Ghost1.GetComponent<Fillholder>();
                currentFill.fill.fillAmount = 1;
            }
            if(!soGhost2.powerActivted){
                var currentFill = Ghost2.GetComponent<Fillholder>();
                currentFill.fill.fillAmount = 1;
            }
            if(!soGhost3.powerActivted){
                var currentFill = Ghost3.GetComponent<Fillholder>();
                currentFill.fill.fillAmount = 1;
            }
    }

}
