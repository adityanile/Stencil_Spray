using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SprayDockManager : MonoBehaviour
{
    [SerializeField]
    private List<Transform> sprays = new List<Transform>();

    public float offset;
    public float startPos = 0;

    private float parentOffset;

    private void Start()
    {
        parentOffset = transform.position.x;

        FillGap();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            SceneManager.LoadScene(0);
        }
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
    }

    public void FillGap()
    {
        Sort();
        GetChilds();

        for (int i=0; i < sprays.Count; i++)
        {
            Transform temp = sprays[i];
            temp.position =  new Vector3(startPos + i*offset + parentOffset, temp.position.y, temp.position.z);
        }
    }

}
