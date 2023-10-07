using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Parralax : MonoBehaviour {
    public Camera cam;
    public Transform subject;
    public bool ScrollX;
    public bool ScrollY;
    public bool staticScroll;

    public ParralaxSystem parralaxSystem;

    private float _subjectDepthDistance => transform.position.z - subject.position.z;
    private float _clippingPlane => (cam.transform.position.z + (_subjectDepthDistance > 0 ? cam.farClipPlane : cam.nearClipPlane));
    private float _parallaxFactor => Mathf.Abs(_subjectDepthDistance) / _clippingPlane;
    
    private Vector2 _imageDimensions;
    private Vector3 _startPosition;

    public void Start() {
        parralaxSystem = FindObjectOfType<ParralaxSystem>();

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        _imageDimensions = spriteRenderer.size;

        spriteRenderer.drawMode = SpriteDrawMode.Tiled;
        spriteRenderer.size = new Vector2(_imageDimensions.x * (ScrollX ? 2 : 1), spriteRenderer.size.y * (ScrollY ? 2 : 1));

        _startPosition = new Vector3(
            transform.position.x, //  + spriteRenderer.size.x/2
            transform.position.y,
            transform.position.z);
    }

    private Vector3 camDisp => cam.transform.position - _startPosition; // the displacement of the camera // cam.transform.position
    private Vector3 parralaxDisp => camDisp * _parallaxFactor; // the total displacement of the parralax.
    private Vector3 parralaxTravel => _startPosition + parralaxDisp; // the position of the parralax. all that's needed to parralax.
    private Vector3 camTargetDistance => camDisp - parralaxTravel;

    public void Update() {
        float targetX, targetY;

        if (staticScroll) {
            targetX = ScrollX ? ssparralaxTravel.x - Mathf.Floor((ssparralaxDisp.x + _imageDimensions.x/2) / _imageDimensions.x) * _imageDimensions.x : _startPosition.x;
            targetY = ScrollY ? ssparralaxTravel.y - Mathf.Floor((ssparralaxDisp.y + _imageDimensions.y/2) / _imageDimensions.y) * _imageDimensions.y : _startPosition.y;
        } else {
            targetX = ScrollX ? parralaxTravel.x + Mathf.Floor((camTargetDistance.x) / _imageDimensions.x) * _imageDimensions.x + _imageDimensions.x/2 : cam.transform.position.x;
            targetY = ScrollY ? parralaxTravel.y + Mathf.Floor((camTargetDistance.y) / _imageDimensions.y) * _imageDimensions.y + _imageDimensions.y/2 : cam.transform.position.y;
        }
        

        transform.position = new Vector3(
            targetX,
            targetY,
            _startPosition.z
        );
    }

    private Vector3 sscamDisp => parralaxSystem.TotalDistance - _startPosition; // the displacement of the camera // cam.transform.position
    private Vector3 ssparralaxDisp => sscamDisp * _parallaxFactor - parralaxSystem.TotalDistance; // the total displacement of the parralax.
    private Vector3 ssparralaxTravel => _startPosition + ssparralaxDisp; // the position of the parralax. all that's needed to parralax.

}
