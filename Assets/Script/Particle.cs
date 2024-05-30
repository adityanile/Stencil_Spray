using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{

    ParticleSystem ps;

    [SerializeField]
    private List<ParticleSystem.Particle> collidedPar = new List<ParticleSystem.Particle>();
    private List<ParticleSystem.Particle> otherPar = new List<ParticleSystem.Particle>();

    public float quadMin;
    public float quadMax;

    public float bgMin;
    public float bgMax;

    private void OnEnable()
    {
        ps = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ClearStensil();
        }
    }

    private void OnParticleTrigger()
    {
        int count = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, otherPar);

        for (int i = 0; i < count; i++)
        {
            ParticleSystem.Particle p = otherPar[i];
            p.velocity = new Vector3(0, 0, 0);
            p.remainingLifetime = Mathf.Infinity;

            if (p.position.z > bgMin && p.position.z < bgMax)
            {
                collidedPar.Add(p);
            }

            if (p.position.z > quadMin && p.position.z < quadMax)
            {
                // If Anything On Stensil is needed then its here
            }

            otherPar[i] = p;

        }
        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, otherPar);
    }
    public void ClearStensil()
    {
        ParticleSystem.Particle[] arr = collidedPar.ToArray();
        
        ps.SetParticles(arr);

        collidedPar.Clear();
    }
}
