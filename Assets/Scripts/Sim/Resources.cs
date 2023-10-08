using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Resources
{
    public float Oxygen;
    public float Food;
    public float Human;

    public Resources(float oxygen, float food, float human) {
        Oxygen = oxygen;
        Food = food;
        Human = human;
    }

    public Resources Add(Resources other) {
        return new Resources(Oxygen + other.Oxygen, Food + other.Food, Human + other.Human);
    }

    public Resources Subtract(Resources other) {
        return new Resources(Mathf.Max(0f, Oxygen - other.Oxygen), Mathf.Max(0f, Food - other.Food), Mathf.Max(0f, Human - other.Human));
    }

    public bool IsLess(Resources other) {
        return Oxygen <= other.Oxygen && Food <= other.Food && Human <= other.Human;
    }

}
