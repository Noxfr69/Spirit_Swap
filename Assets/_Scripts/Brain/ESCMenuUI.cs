using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ESCMenuUI : MonoBehaviour
{
    private PlayerInputActions inputs;
    [SerializeField] private GameObject EscMenu;
    [SerializeField] private BrainManager _brain;



    private void OnEnable() {inputs.Enable();}
    private void OnDisable() {inputs.Disable();}


    private void Awake() {
        inputs = new PlayerInputActions();
        inputs.Player.ESC.performed += x => EscPressed();
        EscMenu.SetActive(false);
    }

    public void EscPressed(){
        if(!EscMenu.activeInHierarchy){
            EscMenu.SetActive(true);
        }else EscMenu.SetActive(false);
    }

    public void OnQuitClick(){
        EscMenu.SetActive(false);
        Application.Quit();
    }

    public void OnMenuClick(){
        Scene scene = SceneManager.GetActiveScene();
        if(scene.buildIndex == 0){
            EscMenu.SetActive(false);
            return;
        } 

        EscMenu.SetActive(false);
        _brain.MenuAsked();
    }

    


}
