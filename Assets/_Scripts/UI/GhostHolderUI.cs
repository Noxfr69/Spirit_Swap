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
    [SerializeField] private GhostPower soGhost1;
    [SerializeField] private GhostPower soGhost2;
    [SerializeField] private GhostPower soGhost3;
    [SerializeField] private Color Gold;
    [SerializeField] private Color red;
    [SerializeField] private Color green;
    [SerializeField] private Color blue;
    private bool tryingtopowerup;

    [SerializeField] private PlayerController _playerController;
    private GhostPower CurrentSelected;





    void Awake() {
        var Player = GameObject.Find("Player");
        PlayerController playerController = Player.GetComponent<PlayerController>();
        playerController.Fpressed += ChangingGhostSelection;
        Ghost1.color = Gold;
        CurrentSelected = soGhost1;
        _swordSR.color = Color.white;
        soGhost1.powerActivted = false;
        soGhost2.powerActivted = false;
        soGhost3.powerActivted = false;

    }


    public void ChangingGhostSelection(){
        Debug.Log("we are in the ui ghost selection");
        if(CurrentSelected == soGhost1){
            Ghost1.color = red;
            Ghost2.color = Gold;
            CurrentSelected = soGhost2;
            return;
        }
        if(CurrentSelected == soGhost2){
            Ghost2.color = green;
            Ghost3.color = Gold;
            CurrentSelected = soGhost3;
            return;
        }
        if(CurrentSelected == soGhost3){
            Ghost3.color = blue;
            Ghost1.color = Gold;
            CurrentSelected = soGhost1;
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
            if(CurrentSelected == soGhost1){
                var currentFill = Ghost1.GetComponent<Fillholder>();
                currentFill.fill.fillAmount -= 0.5f * Time.deltaTime;
                if(currentFill.fill.fillAmount == 0){
                    _swordSR.color = soGhost1.swordColor;
                    soGhost1.powerActivted = true;
                    soGhost2.powerActivted = false;
                    soGhost3.powerActivted = false;
                }
        }
            if(CurrentSelected == soGhost2){
                var currentFill = Ghost2.GetComponent<Fillholder>();
                currentFill.fill.fillAmount -= 0.5f * Time.deltaTime;
                if(currentFill.fill.fillAmount == 0){
                    _swordSR.color = soGhost2.swordColor;
                    soGhost1.powerActivted = false;
                    soGhost2.powerActivted = true;
                    soGhost3.powerActivted = false;
                }
        }
            if(CurrentSelected == soGhost3){
                var currentFill = Ghost3.GetComponent<Fillholder>();
                currentFill.fill.fillAmount -= 0.5f * Time.deltaTime;
                if(currentFill.fill.fillAmount == 0){
                    _swordSR.color = soGhost3.swordColor;
                    soGhost1.powerActivted = false;
                    soGhost2.powerActivted = false;
                    soGhost3.powerActivted = true;
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
