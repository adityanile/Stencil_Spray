using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayButton : MonoBehaviour
{
    public GameObject sprayDock;
    public GameObject brushes;

    // When Clicked on Spray Button
    private void OnMouseDown()
    {
        sprayDock.SetActive(true);
        brushes.SetActive(false);
    }
}
