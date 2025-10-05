using UnityEngine;

public class LightDarknessController : MonoBehaviour
{
    [Header("Target")]
    public Transform target; 

    [Header("Light Settings")]
    public float radius = 5f;
    public Color color = Color.white;
    [Range(0f, 1f)]
    public float darknessIntensity = 0.9f;

    private Material material;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        material = spriteRenderer.material;
        UpdateMaterial();
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 pos = target.position;
            material.SetVector("_LightPos", new Vector4(pos.x, pos.y, 0, 0));
        }

        material.SetFloat("_LightRadius", radius);
        material.SetColor("_LightColor", color);
        material.SetFloat("_DarknessIntensity", darknessIntensity);
    }

    void UpdateMaterial()
    {
        material.SetFloat("_LightRadius", radius);
        material.SetColor("_LightColor", color);
        material.SetFloat("_DarknessIntensity", darknessIntensity);
    }
}