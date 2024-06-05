using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayButton : MonoBehaviour
{
    public GameObject sprayDock;
    public GameObject brushes;

    public AnimationClip dockOpen;
    public AnimationClip brushClose;
    
    // When Clicked on Spray Button
    private void OnMouseDown()
    {
        // Close brush animation to the parent of this spray Button
        Animation anim = transform.parent.GetComponent<Animation>();
        anim.clip = brushClose;
        anim.Play();

        // Play dock Animation
        anim = sprayDock.GetComponent<Animation>();
        anim.clip = dockOpen;
        anim.Play();

        sprayDock.GetComponent<SprayDockManager>().ClickedOnSpray();
    }

    
}
