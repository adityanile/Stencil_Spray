using UnityEngine;

public class SprayManager : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;

    private Vector3 startPos;

    [SerializeField]
    private float scale = 1f;

    [SerializeField]
    private bool holdingSpray = false;
    public int maxParticles = 2000;

    public ParticleSystem spray;

    public Transform outerParent;
    public Transform innerParent;
    public SprayDockManager dockManager;

    public int sprayIndex;

    private void Start()
    {
        startPos = gameObject.transform.position;
    }

    private void Update()
    {
        if (holdingSpray)
        {
            if (Input.GetMouseButtonDown(1))
            {
                spray.maxParticles = maxParticles;
                spray.Play();
            }
            if (Input.GetMouseButtonUp(1))
            {
                spray.maxParticles = 0;
            }
        }
    }
    void OnMouseDown()
    {
        ScaleObject(scale);
        holdingSpray = true;

        transform.parent = outerParent;
        dockManager.FillGap();

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
        ReduceObject(scale);

        holdingSpray = false;
        transform.position = startPos;
        spray.maxParticles = 0;

        // REadjust the Dock
        transform.parent = innerParent;
        dockManager.FillGap();
    }

    void ScaleObject(float diff)
    {
        transform.localScale = new Vector3(transform.localScale.x + diff,
                                           transform.localScale.y + diff,
                                           transform.localScale.z + diff);
    }

    void ReduceObject(float diff)
    {
        transform.localScale = new Vector3(transform.localScale.x - diff,
                                           transform.localScale.y - diff,
                                           transform.localScale.z - diff);
    }


}
