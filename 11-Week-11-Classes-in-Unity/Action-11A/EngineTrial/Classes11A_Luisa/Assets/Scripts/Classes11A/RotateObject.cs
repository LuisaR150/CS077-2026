using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private float degreesPerSecond = 90f;

    public float DegreesPerSecond
    {
        get { return degreesPerSecond; }
        set { degreesPerSecond = value; }
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * DegreesPerSecond * Time.deltaTime, Space.Self);
    }
}
