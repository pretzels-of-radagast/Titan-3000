using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Resources
{
    public float Oxygen;
    public float Food;
    public float Human;
    public float Metal;

    public Resources(float oxygen, float food, float human, float metal=0f) {
        Oxygen = oxygen;
        Food = food;
        Human = human;
        Metal = metal;
    }

    public Resources Add(Resources other) {
        return new Resources(Oxygen + other.Oxygen, Food + other.Food, Human + other.Human, Metal + other.Metal);
    }

    public Resources Subtract(Resources other) {
        return new Resources(Mathf.Max(0f, Oxygen - other.Oxygen), Mathf.Max(0f, Food - other.Food), Mathf.Max(0f, Human - other.Human), Mathf.Max(0f, Metal - other.Metal));
    }

    public bool IsLess(Resources other) {
        return Oxygen <= other.Oxygen && Food <= other.Food && Human <= other.Human && Metal <= other.Metal;
    }

    public float Sum() {
        return Oxygen + Food + Human + Metal;
    }

}
