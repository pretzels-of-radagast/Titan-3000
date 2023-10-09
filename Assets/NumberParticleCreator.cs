using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberParticleCreator : Singleton<NumberParticleCreator> {
    
    public Color oxygen;
    public Color food;
    public Color human;

    public NumberParticle numberParticle;


    public void CreateParticle(Resources resources, Vector3 position) {
        if (resources.Oxygen > 0) { NewParticleInstance().Initalize(oxygen, position, (int) resources.Oxygen); Debug.Log("particle instantiated"); }
        if (resources.Food > 0) { NewParticleInstance().Initalize(food, position, (int) resources.Food); }
        if (resources.Human > 0) { NewParticleInstance().Initalize(human, position, (int) resources.Human); }
        
    }

    public NumberParticle NewParticleInstance() {
        return Instantiate(numberParticle.gameObject, transform).GetComponent<NumberParticle>();
    }

}
