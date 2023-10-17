using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class CycleSummaryDisplay : MonoBehaviour
{

    [Header("State")]
    [SerializeField] private TextMeshProUGUI StateText;

    public static string[][] HumanStates = new string[][] {
        new string[]{ 
            "It's just you for now. But you can practically see a potential settlement.",
            "Another lonely day staring beyond the wasteland.",
            "Your grandma calls you about your job, supportive as always."
        },
        new string[]{ 
            "Your small community played THE LEXER on some ancient hardware today.",
            "The community is pretty bored.",
            "At least there's people to talk to now.",
        },
        new string[]{ 
            "The city caught an illegal immigrant named Calvin today. You let him go.",
            "There's barely enough people in queue to be Titan settlers.",
            "Your tight knit community tightly knitted some new clothes today.",
            "Your colony is really taking shape!",
            "People are starting to become very hopeful of the future!"
        },
        new string[]{ 
            "Calvin was caught slacking on the farms today.",
            "Your board members and you draft infrastructure plans.",
            "A researcher discovers that there's lots of iron at the planet's core.",
        },
        new string[]{ 
            "A young boy sent you a letter for a titan flag. It's a turquoise sphere backdropped by copper colour.",
            "You recieve complaints of Calvin cutting in ration lines.",
            "You barely recognize most faces you see these days",
            "People love talking to you about how the planet used to look like.",
            "Your large population wants burgers",
        },
        new string[]{ 
            "Calvin was caught setting fire to a house.",
            "The settlement is growing!",
            "Your settlement is recognized as a major settlement!"
        },
        new string[]{ 
            "You put Calvin on trial for 12 counts of murder.",
            "You get friend requests from the popular colony-starters.",
            "People are really happy.",
            "You and your board are constantly seeking to improve the settlement.",
            "The settlement is thriving!"
        },
        new string[]{ 
            "Calvin's body has been sent into the waves of saturn.",
            "Your settlement is recognized as an official colony.",
            "Your colony is thriving!",
            "Its hard to imagine what the moon used to be a wasteland.",
            "You would never want to live anywhere else."
        }
    };

    public static string[] OxygenStates = {
        "It's pretty claustrophobic in a respirator suit all the time.",
        "Even taking a gasp of this atmosphere is deadly cold.",
        "The sky is a sickly shade of yellow.",
        "The atmosphere is still unbreathably dense.",
        "The moon is starting to warm up.",
        "You can take your helmet off now for a little bit.",
        "The atmosphere is beginning to turn a hue of blue.",
        "The air almost feels like Terra, now.",
        "The sky is bright blue with fluffy clouds.",
        "The moon barely looks like it did at the beginning.",
        "The air here's honestly better than earth."
    };
    
    // starving 
    public static string[] StarvingFoodStates = {
        "Your people are starving.",
        "People are leaving the country.",
        "Your people are rallying against you.",
        "The senate is considering the abolishment of your settlement.",
    };

    // current food < population && gain < population * .75
    public static string[] UnstableFoodStates = {
        "You wish people could eat dirt.",
        "The board is getting food complaints.",
        "People are questioning your authority.",
        "People are fighting over rations."
    };

    [Header("Colours")]
    [SerializeField] private Color Positive;
    [SerializeField] private Color Neutral;
    [SerializeField] private Color Negative;
    
    [Header("Labels")]
    [SerializeField] private TextMeshProUGUI OldOxygen;
    [SerializeField] private TextMeshProUGUI OldFood;
    [SerializeField] private TextMeshProUGUI OldHuman;
    [SerializeField] private TextMeshProUGUI OldMetal;

    [SerializeField] private TextMeshProUGUI NewOxygen;
    [SerializeField] private TextMeshProUGUI NewFood;
    [SerializeField] private TextMeshProUGUI NewHuman;
    [SerializeField] private TextMeshProUGUI NewMetal;

    [Header("Curves")]
    public AnimationCurve EaseInCurve;
    public AnimationCurve EaseOutCurve;


    public delegate void OnFinishedHandler(); public event OnFinishedHandler OnFinished = delegate {}; 


    public void Step() {
        OldOxygen.text = "" + Sim.instance.PreviousResources.Oxygen;
        OldFood.text = "" + Sim.instance.PreviousResources.Food;
        OldHuman.text = "" + Sim.instance.PreviousResources.Human;
        OldMetal.text = "" + Sim.instance.PreviousResources.Metal;

        NewOxygen.text = "" + Sim.instance.Resources.Oxygen;
        NewFood.text = "" + Sim.instance.Resources.Food;
        NewHuman.text = "" + Sim.instance.Resources.Human;
        NewMetal.text = "" + Sim.instance.Resources.Metal;

        SetTextColours(Sim.instance.PreviousResources.Oxygen, Sim.instance.Resources.Oxygen, OldOxygen, NewOxygen);
        SetTextColours(Sim.instance.PreviousResources.Food, Sim.instance.Resources.Food, OldFood, NewFood);
        SetTextColours(Sim.instance.PreviousResources.Human, Sim.instance.Resources.Human, OldHuman, NewHuman);
        SetTextColours(Sim.instance.PreviousResources.Metal, Sim.instance.Resources.Metal, OldMetal, NewMetal);

        StateText.text = GetStateText();

        StartCoroutine(EaseInCoroutine());

    }

    private void SetTextColours(float old, float current, TextMeshProUGUI text, TextMeshProUGUI secondText) {
        if (current < old) {
            text.color = Negative;
            secondText.color = Negative;
        } else if (current == old) {
            text.color = Neutral;
            secondText.color = Neutral;
        } else if (current > old) {
            text.color = Positive;
            secondText.color = Positive;
        }

    }

    private string GetStateText() {
        bool IsStarving = Sim.instance.PreviousResources.Human > Sim.instance.PreviousResources.Food;
        bool UnStableFood = Sim.instance.Resources.Food < Sim.instance.Resources.Human && (Sim.instance.Resources.Food - Sim.instance.PreviousResources.Food) < Sim.instance.Resources.Human * 0.75f;

        if (IsStarving) {
            return StarvingFoodStates[Random.Range(0, StarvingFoodStates.Length)];
        }
        else if (UnStableFood) {
            return UnstableFoodStates[Random.Range(0, UnstableFoodStates.Length)];
        }
        else if (Random.Range(0, 5) == 0) {
            return OxygenStates[Mathf.Min((int) (Sim.instance.Resources.Oxygen / 10), OxygenStates.Length - 1)];
        }
        else {
            string[] statePool;
            if (Sim.instance.Resources.Human <= 1) {
                statePool = HumanStates[0];
            } else if (Sim.instance.Resources.Human < 10) {
                statePool = HumanStates[1];
            } else if (Sim.instance.Resources.Human < 100) {
                statePool = HumanStates[2];
            } else if (Sim.instance.Resources.Human < 1000) {
                statePool = HumanStates[3];
            } else if (Sim.instance.Resources.Human < 10000) {
                statePool = HumanStates[4];
            } else if (Sim.instance.Resources.Human < 100000) {
                statePool = HumanStates[5];
            } else if (Sim.instance.Resources.Human < 500000) {
                statePool = HumanStates[6];
            } else {
                statePool = HumanStates[7];
            }
            return statePool[Random.Range(0, statePool.Length)];
        }
    }

    private IEnumerator EaseInCoroutine() {
        float StartX = -320;
        float EndX = 0;

        float Elapsed = 0f;
        float Delay = 1f;

        while (Elapsed / Delay < 1) {
            Elapsed += Time.deltaTime;
            transform.localPosition = new Vector3(EaseInCurve.Evaluate(Elapsed / Delay) * (EndX - StartX) + StartX, transform.position.y);
            yield return null;
        }

        yield return new WaitUntil(() => Mouse.current.leftButton.isPressed);

        OnFinished();
        StartCoroutine(EaseOutCoroutine());
    }

    private IEnumerator EaseOutCoroutine() {
        float StartX = 0;
        float EndX = 320;

        float Elapsed = 0f;
        float Delay = 1.6f;

        while (Elapsed / Delay < 1) {
            Elapsed += Time.deltaTime;
            transform.localPosition = new Vector3(EaseOutCurve.Evaluate(Elapsed / Delay) * (EndX - StartX) + StartX, transform.position.y);
            yield return null;
        }
    }

}
