using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ParralaxSystem : MonoBehaviour {
    public float ParralaxSpeed;
    public Vector3 TotalDistance;

    public GameObject subject;

    private void Update() {
        if (subject == null) {
            TotalDistance = new Vector3(
                TotalDistance.x + ParralaxSpeed * Time.deltaTime,
                TotalDistance.y
            );
        } else {
            TotalDistance = (subject.transform.position) * ParralaxSpeed;
        }
        
    }
}
