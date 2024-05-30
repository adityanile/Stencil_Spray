using UnityEngine;

public class StensilManager : MonoBehaviour
{
    [SerializeField]
    private static Vector3 startPos;
    private static bool gotPos = false;

    private Vector3 screenPoint;
    private Vector3 offset;

    private GameObject parent;
    public SprayManager sprayManager;

    [SerializeField]
    private float xOffset = -3f;
    public static Particle particle;

    public bool initialmove = false;

    void Start()
    {
        sprayManager = GameObject.Find("SprayManager").GetComponent<SprayManager>();
    }

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }

    private void OnMouseUp()
    {
        if (transform.position.x < xOffset)
        {
            transform.position = startPos;
        }
    }
}
