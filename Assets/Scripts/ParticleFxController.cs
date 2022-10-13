using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleFxController : MonoBehaviour
{
    [SerializeField] private ParticleSystem _deathFx;
    [SerializeField] private ParticleSystem _walkFx;
    [SerializeField] private ParticleSystem _fallFx;
    
    public void DeathFx()
    {
        _deathFx.Play();
    }
     public void WalkFxOn()
    {
        _walkFx.Play();
        var emission = _walkFx.emission;
        emission.enabled = true;
    }
    public void WalkFxOff()
    {
        var emission = _walkFx.emission;
        emission.enabled = false;
    }
    public void FallFx()
    {
        _fallFx.Play();
    }

}
