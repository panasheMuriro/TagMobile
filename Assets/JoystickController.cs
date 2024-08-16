using UnityEngine;
using UnityEngine.EventSystems;
using FishNet.Object;
using FishNet.Connection;
using FishNet.Object.Synchronizing;

public class JoystickController : NetworkBehaviour
{
    public float speed;
    public VariableJoystick variableJoystick;
    public Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        variableJoystick = GameObject.Find("Variable Joystick").GetComponent<VariableJoystick>();
    }


    public override void OnStartClient()
    {
        base.OnStartClient();
        if (IsOwner)
        {
            ChangeColor();
        }
        else
        {
            // Apply the initial synced position when a client joins
            rb.position = _syncedPosition.Value;
        }
    }


    private void FixedUpdate()
    {
        // if (!IsOwner) return;
        if (IsOwner)
        {
            Vector2 direction = new Vector2(variableJoystick.Horizontal, variableJoystick.Vertical);
            Vector2 newPosition = rb.position + direction * speed * Time.fixedDeltaTime;
            rb.MovePosition(newPosition);
        }
    }




    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other);

        if (other.gameObject.CompareTag("Player"))
        {
            TaggedManager.instance.ShowTagged();
        }
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider);

        if (collider.gameObject.CompareTag("Player"))
        {
            TaggedManager.instance.ShowTagged();
        }

    }


    //  handle colors:
    private void ChangeColor()
    {
        Color randomColor = GetRandomColor();
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.color = randomColor;
        }
    }


    private Color GetRandomColor()
    {
        Color color;
        do
        {
            color = new Color(Random.value, Random.value, Random.value);
        } while (color == Color.black);
        return color;
    }




}
