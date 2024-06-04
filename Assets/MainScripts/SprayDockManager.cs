using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SprayDockManager : MonoBehaviour
{
    [SerializeField]
    private List<Transform> sprays = new List<Transform>();

    [SerializeField]
    private Vector3[] position;

    public float offset;
    public Vector3 startPos;

    private float parentOffset;

    private void Start()
    {
        startPos = new Vector3(0, transform.position.y, transform.position.z);

        parentOffset = transform.position.x;
        startPos.x += parentOffset;

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
        position = new Vector3[sprays.Count];
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
        GetChilds();

        for (int i = 0; i < sprays.Count; i++)
        {
            Transform temp = sprays[i];
            temp.position = new Vector3(startPos.x + i * offset, temp.position.y, temp.position.z);
        }
    }

}
