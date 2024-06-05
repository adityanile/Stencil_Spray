using UnityEngine;

public class SprayManager : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;

    [SerializeField]
    private Vector3 startPos;

    [SerializeField]
    private float scale = 1f;

    [SerializeField]
    private bool holdingSpray = false;
    
    public int maxParticles = 2000;
    public int emissionRate = 50000;

    public ParticleSystem spray;

    public Transform outerParent;
    public Transform innerParent;
    public SprayDockManager dockManager;

    public int sprayIndex;

    private ParticlePaint paint;
    public Color sprayColor;

    public float speed = 2;
    public float dockOffset = 0.01f;

    public bool stackSpray = false;

    private void Update()
    {
        if (holdingSpray)
        {
            if (Input.GetMouseButtonDown(1))
            {
                spray.maxParticles = maxParticles;
                spray.emissionRate = emissionRate;
                spray.loop = true;

                spray.Play();
            }
            if (Input.GetMouseButtonUp(1))
            {
                spray.maxParticles = 0;
                spray.loop = false;
            }
        }

        if (stackSpray || !holdingSpray)
        {
            // Now always move spray to this position
            float distance = Vector3.Distance(startPos, transform.position);

            if (distance > dockOffset)
            {
                Vector3 direction = (startPos - transform.position).normalized;
                transform.Translate(direction * Time.deltaTime * speed);
            }

        }
    }


    void OnMouseDown()
    {
        ScaleObject(scale);
        holdingSpray = true;

        speed = 12.4f;

        transform.parent = outerParent;

        dockManager.AllocateStartPos();

        if (!paint)
        {
            paint = GameObject.Find("Background").GetComponent<ParticlePaint>();
        }
        paint.ChangeColor(sprayColor);

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
        spray.maxParticles = 0;
        ReduceObject(scale);
        // REadjust the Dock
        transform.parent = innerParent;
        dockManager.AllocateStartPos();

        stackSpray = true;
    }


    // After removing when collide with the dock again is handeled here
    private void OnTriggerEnter(Collider other)
    {
        if (holdingSpray)
        {
            if (other.gameObject.CompareTag("SprayDock"))
            {
                speed = 3;
                holdingSpray = false;
                stackSpray = false;
            }
        }
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

    public void SetStartPos(Vector3 pos)
    {
        startPos = pos;
    }

}
