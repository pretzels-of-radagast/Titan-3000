using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParralaxSystem : MonoBehaviour
{
    public float ParralaxSpeed;
    [HideInInspector] public Vector3 TotalDistance;

    private void Update() {
        TotalDistance = new Vector3(
            TotalDistance.x + ParralaxSpeed * Time.deltaTime,
            TotalDistance.y
        );
    }
}
