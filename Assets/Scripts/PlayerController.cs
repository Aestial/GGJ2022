using System.Collections;
using System.Collections.Generic;
using Kogane;
using UnityEngine;

[MoveTopComponent]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameController m_GameController;
    [SerializeField] private GameState m_PlayerType;
    [SerializeField] PlayerMovement m_Movement;
    [SerializeField] PlayerShooting m_Shooting;
    private GameState m_CurrentState;
    public GameState PlayerType
    {
        get { return m_PlayerType; }
    }

    public void Damage()
    {
        m_GameController.Damage(m_PlayerType);
    }

    public void ChangeState(GameState state)
    {        
        m_CurrentState = state;
        UpdateState(state);
    }

    private void UpdateState(GameState state)
    {
        if (state == m_PlayerType)
        {
            m_Movement.Enable();
            m_Shooting.Disable();

        } else
        {
            m_Movement.Disable();
            m_Shooting.Enable();
        }
    }
    
}
