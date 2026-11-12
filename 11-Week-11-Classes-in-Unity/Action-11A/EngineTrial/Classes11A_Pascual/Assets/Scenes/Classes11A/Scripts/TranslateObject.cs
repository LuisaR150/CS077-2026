using UnityEngine;

public class TranslateObject : MonoBehaviour
{
    [SerializeField] private float speed = 0.5f;

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    private void Update()
    {
        transform.Translate(Vector3.right * Speed * Time.deltaTime, Space.World);
    }
}