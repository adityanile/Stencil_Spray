using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveExtraParticles : MonoBehaviour
{
    ParticleSystem ps;
    private List<ParticleSystem.Particle> collidedPar = new List<ParticleSystem.Particle>();

    public Transform newTrigger;
    public Transform oldTrigger;

    private void OnEnable()
    {
        ps = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            //ChangeCollider(newTrigger);
            Trigger();
        }
    }

    // Start is called before the first frame update
    private void Trigger()
    {
        int count = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Inside, collidedPar);

        Debug.Log(count);

        for (int i = 0; i < count; i++)
        {
            ParticleSystem.Particle p = collidedPar[i];
            p.remainingLifetime = 0;
            collidedPar[i] = p;
        }
        ps.SetTriggerParticles(ParticleSystemTriggerEventType.Inside, collidedPar);
    }

    void ChangeCollider(Transform collider)
    {
        ps.trigger.RemoveCollider(0);

        ps.trigger.AddCollider(collider);
    }
}
