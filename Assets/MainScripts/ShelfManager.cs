using UnityEngine;

public class ShelfManager : MonoBehaviour
{
    public bool isopen = false;
    private Animation anim;

    public AnimationClip open;
    public AnimationClip close;

    private void Awake()
    {
        anim = GetComponent<Animation>();
    }

    private void OnMouseDown()
    {
        if (isopen)
        {
            CloseTheShelf();
        }
        else
        {
            OpenTheShelf();
        }
    }

    public void OpenTheShelf()
    {
        if (!isopen)
        {
            isopen = true;
            anim.clip = open;
            anim.Play();
        }

    }

    public void CloseTheShelf()
    {
        isopen = false;
        anim.clip = close;
        anim.Play();
    }
}
