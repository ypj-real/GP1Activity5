using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 6f;
    Rigidbody rb;
    Vector3 input;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.interpolation = RigidbodyInterpolation.Interpolate;
    }

    void Update() { input = ReadInput(); }

    Vector3 ReadInput()
    {
        float x = 0f, z = 0f;
#if ENABLE_INPUT_SYSTEM
        var k = Keyboard.current;
        if (k == null) return Vector3.zero;
        if (k.aKey.isPressed || k.leftArrowKey.isPressed) x -= 1f;
        if (k.dKey.isPressed || k.rightArrowKey.isPressed) x += 1f;
        if (k.sKey.isPressed || k.downArrowKey.isPressed) z -= 1f;
        if (k.wKey.isPressed || k.upArrowKey.isPressed) z += 1f;
#else
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");
#endif
        return new Vector3(x, 0f, z).normalized;
    }

    void FixedUpdate()
    {
#if UNITY_6000_0_OR_NEWER
        float y = rb.linearVelocity.y;
        rb.linearVelocity = new Vector3(input.x * moveSpeed, y, input.z * moveSpeed);
#else
        float y = rb.velocity.y;
        rb.velocity = new Vector3(input.x * moveSpeed, y, input.z * moveSpeed);
#endif
    }
}
