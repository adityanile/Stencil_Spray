using UnityEngine;

public class StensilManager : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;

    public float shelfEdge;
    private bool removedOut = false;

    public Transform outerParent;
    public Transform innerParent;

    ShelfManager shelfManager;

    private void Start()
    {
        if (!shelfManager)
        {
            shelfManager = GameObject.Find("Shelf").GetComponent<ShelfManager>();
        }
    }


    void OnMouseDown()
    {
        // Remove Stencil Out
        if (!removedOut && shelfManager.isopen)
        {
            transform.parent = outerParent;
            removedOut = true;
            shelfManager.CloseTheShelf();
        }

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
        if (shelfManager.isopen)
        {
            if (gameObject.transform.position.x < shelfEdge)
            {
                removedOut = false;
                transform.parent = innerParent;
                shelfManager.CloseTheShelf();
            }
        }
    }

}
