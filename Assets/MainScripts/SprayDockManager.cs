using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SprayDockManager : MonoBehaviour
{
    [SerializeField]
    private List<Transform> sprays = new List<Transform>();

    public float offset;
    public float dockOpenAnim = 1;

    public float startPos;
    public float endPos;

    private float sprayY;
    private float sprayZ;

    public float[] pos;

    public bool initial = true;

    private void Start()
    {
        SetEgde();

        GetChilds();
        AllocateStartPos();
    }
    public void AllocateStartPos()
    {
        Sort();
        float offset = GetOffset();

        if (initial)
        {
            initial = false;

            sprayY = sprays[0].position.y;
            sprayZ = sprays[0].position.z;
        }
        else
        {
            sprayY = pos[0];
            sprayZ = pos[1];
        }

        for(int i = 0; i < sprays.Count; i++)
        {
            Vector3 pos = new Vector3(startPos + i * offset, sprayY, sprayZ);
            sprays[i].GetComponent<SprayManager>().SetStartPos(pos);
        }
    }

    void SetEgde()
    {
        GetChilds();
        startPos = sprays[0].position.x;
        endPos = sprays[sprays.Count - 1].position.x;
    }

    public float GetOffset()
    {
        return (endPos - startPos)/(sprays.Count);
    }

    private void GetChilds()
    {
        sprays.Clear();
        int count = transform.childCount;

        for (int i = 0; i < count; i++)
        {
            sprays.Add(transform.GetChild(i));

            if (sprays[i].GetComponent<SprayManager>().sprayIndex == -1)
            {
                sprays[i].GetComponent<SprayManager>().sprayIndex = i;
            }
        }
    }

    void Sort()
    {
        GetChilds();
        for (int i = 0; i < sprays.Count; i++)
        {
            Transform temp = sprays[i];
            temp.SetSiblingIndex(temp.GetComponent<SprayManager>().sprayIndex);
        }
        GetChilds();
    }

    public void ClickedOnSpray()
    {
        StartCoroutine(AfterDockOpenAnim());
    }

    // TO set starting position of the sprays when after the animation is ended
    IEnumerator AfterDockOpenAnim()
    {
        yield return new WaitForSeconds(dockOpenAnim);
        SetStartPos();
    }
    void SetStartPos()
    {
        GetChilds();

        foreach (var i in sprays)
        {
            i.GetComponent<SprayManager>().SetStartPos(i.transform.position);
        }
    }

}
