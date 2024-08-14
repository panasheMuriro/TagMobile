using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour
{
     public float speed;
    public VariableJoystick variableJoystick;
    public Rigidbody2D rb;

    private void FixedUpdate()
    {
        Vector2 direction = new Vector2(variableJoystick.Horizontal, variableJoystick.Vertical);
        Vector2 newPosition = rb.position + direction * speed * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);
    }
}
