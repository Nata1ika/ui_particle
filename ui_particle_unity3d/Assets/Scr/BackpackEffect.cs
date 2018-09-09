using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackEffect : MonoBehaviour
{
    [SerializeField] ParticleSystem _particle;

    public void Show()
    {
        _particle.Play(true);
    }

    public void Hide()
    {
        _particle.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
    }
}
