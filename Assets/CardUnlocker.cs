using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardUnlocker : MonoBehaviour
{
    
    [System.Serializable]
    public struct ElementUnlock {
        public float OxygenThreshold;
        public ElementType elementType;

    }

    public ElementUnlock[] elementUnlocks;
    public AnimationCurve MoveCurve;

    public Vector3 CardPosition;

    [Header("SFX")]
    public AudioClip ResearchSFX;
    
    // cache
    private int unlockIndex;
    private GameObject PosterCard;


    public void Step() {
        ElementUnlock currentUnlock = elementUnlocks[unlockIndex];

        if (Sim.instance.Resources.Oxygen >= currentUnlock.OxygenThreshold) {
            StartUnlockCoroutine();

            AddPosterCard(currentUnlock.elementType);

            Sim.instance.celluarMatrix.AddCard(currentUnlock.elementType);
            unlockIndex += 1;
        }
    }

    private void AddPosterCard(ElementType elementType) {
        // destroy the previous card
        if (PosterCard != null) { Destroy(PosterCard); }

        // create the card
        Card card = ElementLibrary.instance.NewCardInstance(elementType, false);
        PosterCard = card.gameObject;

        // parent it to this transform
        PosterCard.transform.SetParent(transform);

        // disable the card script
        PosterCard.GetComponent<Card>().enabled = false;

        // set it's appropriate location relative to this transform
        PosterCard.transform.localPosition = CardPosition;
    }

    [ContextMenu("test unlock menu")]
    private void StartUnlockCoroutine() {
        StartCoroutine(EaseInCoroutine());
    }

    private IEnumerator EaseInCoroutine() {
        float StartX = -320;
        float EndX = 320;

        float Elapsed = 0f;
        float Delay = 5f;

        while (Elapsed / Delay < 1) {
            Elapsed += Time.deltaTime;
            transform.localPosition = new Vector3(MoveCurve.Evaluate(Elapsed / Delay) * (EndX - StartX) + StartX, transform.position.y);
            yield return null;
        }
        
    }

    

}
