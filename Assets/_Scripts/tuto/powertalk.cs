using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powertalk : MonoBehaviour
{
    public GameObject PowerTalkText;
    public GameObject Slide1;
    public GameObject Slide2;
    public GameObject Slide3;
    public GameObject Slide4;
    public GameObject Slide5;
    public List<GameObject> slides = new List<GameObject>();
    public GameObject UnderstandButton;
    private int currentSlide = 0;
    private AudioSource audioSource;
    public AudioClip click;
    private bool powertuto = false;



    private void Awake() {
        audioSource = GetComponent<AudioSource>();
        currentSlide = 0;
        foreach (var item in slides)
        {
            item.SetActive(false);
        }
        PowerTalkText.SetActive(false);
        UnderstandButton.SetActive(false);
        powertuto = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.layer == 6 && tutochest.ShrineChecked && !powertuto){
            powertuto = true;
            PowerTalkText.SetActive(true);
            Slide1.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void OnArrowRight(){
        audioSource.PlayOneShot(click);
        slides[currentSlide].SetActive(false);
        currentSlide++;
        if(currentSlide > 4){currentSlide = 4;}
        slides[currentSlide].SetActive(true);
        if(currentSlide == 4){
            UnderstandButton.SetActive(true);
        }
        
    }

    public void OnArrowLeft(){
        audioSource.PlayOneShot(click);
        slides[currentSlide].SetActive(false);
        currentSlide--;
        if(currentSlide < 0){currentSlide = 0;}
        slides[currentSlide].SetActive(true);
        UnderstandButton.SetActive(false);
    }

    public void OnClickUnderstood(){
        audioSource.PlayOneShot(click);
        PowerTalkText.SetActive(false);
        Time.timeScale = 1;
    }


}
