using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    ParticleSystem ps;

    private List<ParticleSystem.Particle> otherPar = new List<ParticleSystem.Particle>();
    private List<ParticleSystem.Particle> collidedPar = new List<ParticleSystem.Particle>();

    public float bgMin;
    public float bgMax;

    public Transform newTrigger;
    public Transform oldTrigger;

    private void OnEnable()
    {
        ps = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        //if(Input.GetMouseButtonDown(0))
        //{
        //    ps.Play();
        //}
        //if(Input.GetMouseButtonUp(0))
        //{
        //    ps.maxParticles = 0;
        //}

        //if (Input.GetMouseButtonDown(1))
        //{
        //    ps.maxParticles = 2000;
        //}

        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //    ChangeCollider(newTrigger);
        //    RemoveExtraParticles();
        //}
    }

    private void OnParticleTrigger()
    {
        //int count = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, otherPar);

        //for (int i = 0; i < count; i++)
        //{
        //    ParticleSystem.Particle p = otherPar[i];
        //    p.velocity = new Vector3(0, 0, 0);
        //    p.remainingLifetime = Mathf.Infinity;
        //    otherPar[i] = p;
        //}
        //ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, otherPar);

        int count = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, collidedPar);

        
        //for (int i = 0; i < count2; i++)
        //{
        //    ParticleSystem.Particle p = otherPar[i];
        //    p.remainingLifetime = 0;
        //    otherPar[i] = p;
        //}

        for (int i = 0; i < count; i++)
        {
            ParticleSystem.Particle p = collidedPar[i];
            p.velocity = new Vector3(0, 0, 0);
            p.remainingLifetime = Mathf.Infinity;
            collidedPar[i] = p;
        }

        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, collidedPar);
    }

}
