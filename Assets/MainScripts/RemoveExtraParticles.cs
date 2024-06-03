using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveExtraParticles : MonoBehaviour
{
    ParticleSystem ps;
    private List<ParticleSystem.Particle> collidedPar = new List<ParticleSystem.Particle>();

    private void OnEnable()
    {
        ps = GetComponent<ParticleSystem>();
    }

    private void OnParticleTrigger()
    {
        Debug.Log("SubEmitter Working");
        int count = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, collidedPar);

        for (int i = 0; i < count; i++)
        {
            ParticleSystem.Particle p = collidedPar[i];
            p.remainingLifetime = Mathf.Infinity;
            collidedPar[i] = p;
        }
        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, collidedPar);
    }
}
