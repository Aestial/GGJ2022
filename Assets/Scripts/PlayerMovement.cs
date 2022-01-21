using Kogane;
using UnityEngine;

// Ensure the component is present on the gameobject the script is attached to
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 1000.0f;

    // Local rigidbody variable to hold a reference to the attached Rigidbody2D component
    new Rigidbody2D rigidbody2D;
    private bool isEnabled;    

    public void Enable()
    {
        isEnabled = true;
    }

    public void Disable()
    {
        rigidbody2D.velocity = Vector2.zero;
        isEnabled = false;
    }

    void Awake()
    {
        // Setup Rigidbody for frictionless top down movement and dynamic collision
        rigidbody2D = GetComponent<Rigidbody2D>();

        rigidbody2D.isKinematic = false;
        rigidbody2D.angularDrag = 0.0f;
        rigidbody2D.gravityScale = 0.0f;
    }

    void Update()
    {
        if(!isEnabled) return;
        // Handle user input
        Vector2 targetVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Move(targetVelocity);
    }

    void Move(Vector2 targetVelocity)
    {        
        // Set rigidbody velocity
        rigidbody2D.velocity = (targetVelocity * movementSpeed) * Time.deltaTime; // Multiply the target by deltaTime to make movement speed consistent across different framerates
    }
}