using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public TextMeshProUGUI TitleCardText;


    [Header("SFX")]
    public AudioClip ResearchSFX;


    [Header("BackgroundSprites")]
    public SpriteRenderer Background0;
    public SpriteRenderer Background1;
    public SpriteRenderer Background2;

    public Sprite[] ZeroPercent;
    public Sprite[] FifteenPercent;
    public Sprite[] SeventyPerent;
    
    // cache
    private int unlockIndex;
    private GameObject PosterCard;
    private float PreviousOxygen;


    public void Step() {
        PreviousOxygen = Sim.instance.Resources.Oxygen;

        bool finishedAllUnlocks = unlockIndex >= elementUnlocks.Length;
        if (finishedAllUnlocks) { return; }

        ElementUnlock currentUnlock = elementUnlocks[unlockIndex];
        
        if (unlockIndex < elementUnlocks.Length && Sim.instance.Resources.Oxygen >= currentUnlock.OxygenThreshold) {
            StartUnlockCoroutine();
            SetPosterCard(currentUnlock.elementType);
            TitleCardText.text = $"The {PosterCard.GetComponent<Card>().element.Name}";
            // SetTitleCardText();

            SFXSystem.instance.PlayVariatedSFX(ResearchSFX);

            Sim.instance.celluarMatrix.AddCard(currentUnlock.elementType);
            unlockIndex += 1;

            if (PreviousOxygen < 15 && Sim.instance.Resources.Oxygen >= 15) {
                MusicSystem.instance.PlayNextClip();
                SetBackground(FifteenPercent);
            } else if (PreviousOxygen < 75 && Sim.instance.Resources.Oxygen >= 75) {
                MusicSystem.instance.PlayNextClip();
                SetBackground(SeventyPerent);
            }
        }

    }
    

    private void SetPosterCard(ElementType elementType) {
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

    private void SetTitleCardText() {
        TitleCardText.text = $"The {PosterCard.GetComponent<Card>().element.Name}";
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



    private void SetBackground(Sprite[] backgroundSprites) {
        Background0.sprite = backgroundSprites[0];
        Background1.sprite = backgroundSprites[1];
        Background2.sprite = backgroundSprites[2];
    }

    

}
