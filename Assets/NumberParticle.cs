using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumberParticle : MonoBehaviour {

    public RectTransform rectTransform;    
    public TextMeshProUGUI textMesh;

    // cached values
    private Vector3 velocity = new Vector3(0, 1);

    public void Initalize(Color color, Vector3 position, int number) {
        textMesh.text = $"+{number}";
        textMesh.color = color;
        transform.position = position;

        Destroy(gameObject, 1f);
    }

    private void Update() {
        transform.position = new Vector3(
            transform.position.x + velocity.x * Time.deltaTime, 
            transform.position.y + velocity.y * Time.deltaTime, 
            transform.position.z
        );
    }


}
