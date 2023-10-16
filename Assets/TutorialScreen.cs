using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TutorialScreen : MonoBehaviour
{
    private void Update() {
        if (Mouse.current.leftButton.isPressed) {
            Destroy(gameObject);
        }
    }
}
