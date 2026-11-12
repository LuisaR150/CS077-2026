using UnityEngine;
using UnityEngine.InputSystem; // Types supplied by the Input System package.

[RequireComponent(typeof(CharacterController))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField, Min(0f)] private float speed = 3f;
    [SerializeField, Min(0f)] private float interactionRange = 2f;
    [SerializeField] private StoryBeacon beacon;
    private CharacterController controller;

    public float Speed
    {
        get => speed;
        set => speed = Mathf.Max(0f, value);
    }

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Keyboard keyboard = Keyboard.current;
        Vector3 direction = Vector3.zero;
        if (keyboard != null)
        {
            if (keyboard.wKey.isPressed || keyboard.upArrowKey.isPressed) direction.z += 1f;
            if (keyboard.sKey.isPressed || keyboard.downArrowKey.isPressed) direction.z -= 1f;
            if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed) direction.x += 1f;
            if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed) direction.x -= 1f;
        }

        // SimpleMove takes speed in metres/second and applies gravity and frame timing.
        // Do not multiply this argument by Time.deltaTime.
        controller.SimpleMove(direction.normalized * Speed);

        if (keyboard != null && keyboard.eKey.wasPressedThisFrame && beacon != null)
        {
            float distance = Vector3.Distance(transform.position, beacon.transform.position);
            if (distance <= interactionRange) beacon.Activate();
        }
    }
}
