using UnityEngine;

public class ParticlePaint : MonoBehaviour
{
    private Texture2D originalTexture;
    private Texture2D workingTexture; //the texture we modify
    private Renderer mioRenderer; //renderer component
    Texture2D texture;
    Color32 baseColor;

    Color32[] sourcePixels;

    void Start()
    {
        mioRenderer = GetComponent<Renderer>();
        texture = mioRenderer.material.mainTexture as Texture2D;
        workingTexture = new Texture2D(texture.width, texture.height);
        originalTexture = new Texture2D(texture.width, texture.height);

        sourcePixels = texture.GetPixels32();

        originalTexture.SetPixels32(sourcePixels);
        workingTexture.SetPixels32(sourcePixels);
        mioRenderer.material.mainTexture = workingTexture;
        
        workingTexture.Apply();
        originalTexture.Apply();
    }

    void OnParticleCollision(GameObject other)
    {
        int num = other.GetComponent<ParticleSystem>().GetSafeCollisionEventSize();
        ParticleCollisionEvent[] collisionEvents = new ParticleCollisionEvent[num];
        int result = other.GetComponent<ParticleSystem>().GetCollisionEvents(gameObject, collisionEvents);

        RaycastHit hit;
        Vector3 pos = Vector3.zero;
        Vector2 pixelUV;
        Vector2 pixelPoint;

        if (!other.CompareTag("Eraser"))
        {
            for (int i = 0; i < num; i++)
            {
                if (Physics.Raycast(collisionEvents[i].intersection, Vector3.forward, out hit))
                {
                    pos = hit.point;
                    pixelUV = hit.textureCoord;
                    pixelPoint = new Vector2(pixelUV.x * texture.width, pixelUV.y * texture.height);
                    workingTexture.SetPixel((int)pixelPoint.x, (int)pixelPoint.y, baseColor);
                }
            }
        }
        else
        {
            for (int i = 0; i < num; i++)
            {
                if (Physics.Raycast(collisionEvents[i].intersection, Vector3.forward, out hit))
                {
                    pos = hit.point;
                    pixelUV = hit.textureCoord;
                    pixelPoint = new Vector2(pixelUV.x * texture.width, pixelUV.y * texture.height);

                    Color32 orgColor = originalTexture.GetPixel((int)pixelPoint.x, (int)pixelPoint.y);
                    workingTexture.SetPixel((int)pixelPoint.x, (int)pixelPoint.y, orgColor);
                }
            }
        }
        workingTexture.Apply();
    }

    public void ChangeColor(Color color)
    {
        baseColor = color;
    }

}


