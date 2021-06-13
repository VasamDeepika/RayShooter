using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemiescollision : MonoBehaviour
{
    private void Awake()
    {
        
    }
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("particle collision"+ gameObject.name);
    }
}
