using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MoreMountains.Feedbacks;

public class MoonCollectScript : MonoBehaviour
{


    public Image moon;
    public Color32 unlockedColor = new Color32(255,248,0,255);
    public Color32 lockedcollor = new Color32(111,111,111,188);
    private LevelWinCheck win;
    [SerializeField] private MMF_Player collectfeedback;
    public bool CanGetPickedUp = true;
    private SpriteRenderer SR;

    private void Awake() {
       win = moon.GetComponentInParent<LevelWinCheck>();
       SR = GetComponent<SpriteRenderer>();
       CanGetPickedUp = true;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.layer == 6 && CanGetPickedUp){
            moon.color = unlockedColor;
            collectfeedback?.PlayFeedbacks();
            win.OnCollectItem();
            Destroy(gameObject,0.05f);
        }
    }


    public void OnBoolChange(bool Bool){
        CanGetPickedUp = !Bool;
        if(CanGetPickedUp){
            SR.color = unlockedColor;
        }else{SR.color = lockedcollor;}
    }

}
