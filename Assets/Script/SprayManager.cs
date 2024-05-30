using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SprayManager : MonoBehaviour
{
    public ParticleSystem[] particles;
    public GameObject[] points;

    [SerializeField]
    private List<GameObject> instPoints = new List<GameObject>();
    private List<GameObject> onStencilPoints = new List<GameObject>();

    public GameObject parent;
    public float offset = -0.02f;

    public bool holdingSpray = false;
    public int currentColorIndex;

    // Set Current Stencil
    public GameObject stencil;

    private void Update()
    {
    //    Vector3 pos = Input.mousePosition;

    //    Ray ray = Camera.main.ScreenPointToRay(pos);

    //    if (Input.GetMouseButton(1))
    //    {
    //        RaycastHit hit;

    //        if (Physics.Raycast(ray, out hit))
    //        {

    //            if (holdingSpray)
    //            {
    //                if (!hit.collider.CompareTag("Stencil"))
    //                {
    //                    Vector3 position = new Vector3(hit.point.x, hit.point.y, hit.point.z + offset);
    //                    GameObject inst = Instantiate(points[currentColorIndex], position, points[currentColorIndex].transform.rotation, parent.transform);
    //                    instPoints.Add(inst);
    //                }
    //                else
    //                {
    //                    Vector3 position = new Vector3(hit.point.x, hit.point.y, hit.point.z + offset);
    //                    GameObject inst = Instantiate(points[currentColorIndex], position, points[currentColorIndex].transform.rotation, stencil.transform);
    //                    onStencilPoints.Add(inst);
    //                }
    //            }
    //            ray = new Ray();
    //        }
    //    }
    }

    public void OnClickClear()
    {
        SceneManager.LoadScene(0);
    }

    
}
