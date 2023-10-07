using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PauseSystem : Singleton<PauseSystem>
{

    public PlayerInput PlayerInputComponent;    

    public static UnityEvent OnPause = new UnityEvent();

    public static UnityEvent OnUnpause = new UnityEvent();

    private static bool isPaused = false; // protect Pausing.
    public bool IsPaused { get => isPaused; }

    public int LastPauseFrame;
    
    public void PauseInput(InputAction.CallbackContext callbackContext) {
        if (callbackContext.performed) {
            if (isPaused) { Unpause(); }
            else { Pause(); }
        }
    }

    private void OnEnable() {
        PlayerInputComponent.actions["Pause"].performed += ctx => PauseInput(ctx);
    }

    private void Update() {
        /* if (PlayerInputComponent.actions["pause"].) {
            Debug.Log("e");
        }*/
    }

    public void Pause() {
        if (Time.frameCount == LastPauseFrame) { return; }

        Debug.Log($"paused {$"bruh {Time.frameCount}"}");
        LastPauseFrame = Time.frameCount; // helpful for one purpose - denying first frame pause menu cancels.

        // Debug.Log(PlayerInputComponent.currentActionMap.name);

        OnPause.Invoke();

        isPaused = true;
        Time.timeScale = 0f;
        AudioListener.pause = true;
    }

    
    public void Unpause() {
        if (Time.frameCount == LastPauseFrame) { return; }
        
        Debug.Log($"unpaused! {$"bruh {Time.frameCount}"}");
        LastPauseFrame = Time.frameCount;

        OnUnpause.Invoke();

        isPaused = false;
        Time.timeScale = 1f;
        AudioListener.pause = false;
    } 
    
}
