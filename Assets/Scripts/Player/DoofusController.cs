using UnityEngine;
using UnityEngine.InputSystem;

public class DoofusController : MonoBehaviour
{
    Rigidbody rb;
    ConfigLoader config;
    float speed;
    Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        config = FindFirstObjectByType<ConfigLoader>();
        speed = config.Config.player_data.speed;
    }

    void Update()
    {
        if (Keyboard.current == null)
            return;

        float h = 0;
        float v = 0;

        if (Keyboard.current.wKey.isPressed) v = 1;
        if (Keyboard.current.sKey.isPressed) v = -1;
        if (Keyboard.current.dKey.isPressed) h = 1;
        if (Keyboard.current.aKey.isPressed) h = -1;

        moveInput = new Vector2(h, v).normalized;
    }

    void FixedUpdate()
    {
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y) * speed;
        rb.MovePosition(rb.position + move * Time.fixedDeltaTime);
    }
}
