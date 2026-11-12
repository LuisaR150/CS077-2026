using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class StoryBeacon : MonoBehaviour
{
    [SerializeField] private Color activeColor = Color.cyan;
    private Renderer beaconRenderer;
    private MaterialPropertyBlock appearance;

    public bool IsActivated { get; private set; }

    private void Awake()
    {
        beaconRenderer = GetComponent<Renderer>();
        appearance = new MaterialPropertyBlock();
    }

    public void Activate()
    {
        if (IsActivated) return;
        IsActivated = true;

        // Common color properties for URP/Lit and Built-in Standard materials.
        beaconRenderer.GetPropertyBlock(appearance);
        appearance.SetColor("_BaseColor", activeColor);
        appearance.SetColor("_Color", activeColor);
        beaconRenderer.SetPropertyBlock(appearance);
        Debug.Log("Beacon activated: communication restored.", this);
    }
}
