using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolEffect : MonoBehaviour
{
    [SerializeField] ParticleSystem _particle;

    public void Click()
    {
        _particle.Play();
    }
}
