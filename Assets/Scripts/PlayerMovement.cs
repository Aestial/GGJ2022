using Kogane;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float m_MovementSpeed = 1000.0f;
    private new Rigidbody2D m_Rigidbody2D;
    private bool m_IsEnabled;

    public void OnMove(InputAction.CallbackContext context)
    {
        if (!m_IsEnabled) return;
        // Handle user input
        Vector2 input = context.ReadValue<Vector2>();
        Vector2 targetVelocity = input.normalized;
        Move(targetVelocity);
    }

    public void Enable()
    {
        m_IsEnabled = true;
    }

    public void Disable()
    {
        m_Rigidbody2D.velocity = Vector2.zero;
        m_IsEnabled = false;
    }

    void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        // Setup Rigidbody for frictionless top down movement and dynamic collision        
        m_Rigidbody2D.isKinematic = false;
        m_Rigidbody2D.angularDrag = 0.0f;
        m_Rigidbody2D.gravityScale = 0.0f;
    }

    private void Move(Vector2 targetVelocity)
    {
        // Set rigidbody velocity. Multiply the target by deltaTime to make movement speed consistent across different framerates
        m_Rigidbody2D.velocity = (targetVelocity * m_MovementSpeed) * Time.deltaTime; 
    }
}