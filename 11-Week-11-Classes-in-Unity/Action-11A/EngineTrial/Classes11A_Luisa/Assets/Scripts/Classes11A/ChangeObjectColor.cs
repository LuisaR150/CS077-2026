using UnityEngine;

public class ChangeObjectColor : MonoBehaviour
{
    [SerializeField] private Color tint = Color.cyan;
    private Material runtimeMaterial;

    public Color Tint
    {
        get { return tint; }
        set { tint = value; }
    }

    private void Start()
    {
        runtimeMaterial = GetComponent<Renderer>().material;
        runtimeMaterial.color = Tint;
    }

    private void OnDestroy()
    {
        if (runtimeMaterial != null)
        {
            Destroy(runtimeMaterial);
        }
    }
}
