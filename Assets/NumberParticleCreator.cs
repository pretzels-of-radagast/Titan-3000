using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberParticleCreator : MonoBehaviour {
    
    public static Transform transformInstance;
    public static NumberParticle particleInstance;
    public static Color oxygen = new Color(107, 148, 172);
    public static Color food = new Color(142, 112, 73);
    public static Color human = new Color(145, 94, 76);

    public NumberParticle numberParticle;

    private void Awake() {
        if (particleInstance == null) {
            particleInstance = numberParticle;
            transformInstance = transform;
        }
    }

    public static void CreateParticle(Resources resources, Vector3 position) {
        if (resources.Oxygen > 0) { NewParticleInstance().Initalize(oxygen, position, (int) resources.Oxygen); Debug.Log("particle instantiated"); }
        if (resources.Food > 0) { NewParticleInstance().Initalize(food, position, (int) resources.Food); }
        if (resources.Human > 0) { NewParticleInstance().Initalize(human, position, (int) resources.Human); }
        
    }

    public static NumberParticle NewParticleInstance() {
        return Instantiate(particleInstance.gameObject, transformInstance).GetComponent<NumberParticle>();
    }

}
