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
        transform.localPosition = position;

        Destroy(gameObject, 5f);
    }

    private void Update() {
        transform.localPosition = new Vector3(
            transform.localPosition.x + velocity.x * Time.deltaTime, 
            transform.localPosition.y + velocity.y * Time.deltaTime, 
            transform.localPosition.z
        );
    }


}
