using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
       Destroy(other);
    }
}
