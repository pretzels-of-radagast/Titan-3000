using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Exit()
    {
        gameObject.SetActive(false);
    }
}
