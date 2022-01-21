using System.Collections;
using System.Collections.Generic;
using Kogane;
using UnityEngine;

[MoveTopComponent]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameState m_MovingState;
    [SerializeField] PlayerMovement m_Movement;
    private GameState m_CurrentState;

    public void ChangeState(GameState state)
    {        
        m_CurrentState = state;
        UpdateState(state);
    }

    private void UpdateState(GameState state)
    {
        if (state == m_MovingState)
        {
            m_Movement.Enable();
        } else
        {
            m_Movement.Disable();
        }
    }
}
