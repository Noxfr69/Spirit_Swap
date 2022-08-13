using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Custom_cursor : MonoBehaviour
{
    PlayerInputActions input;



    private void Awake() {
        input = new PlayerInputActions();
        transform.position = input.Player.mouseposition.ReadValue<Vector2>();
        gameObject.SetActive(false);
    }
    private void OnEnable() {
        input.Enable();
    }
    private void OnDisable() {
        input.Disable();
    }
    void Update()
    {
        transform.position = input.Player.mouseposition.ReadValue<Vector2>();
    }
}
