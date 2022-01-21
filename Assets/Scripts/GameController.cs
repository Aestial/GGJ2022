using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    [SerializeField] private float m_TurnTime = 5.0f;
    [SerializeField] private UnityEvent<GameState> m_OnTurnChange;
    [SerializeField] private UnityEvent<float> m_OnTurnTick;
    private GameState m_GameState;
    private float m_TurnTimer;

    void Start()
    {
        SwitchTurn(GameState.Black);
    }
    private void SwitchTurn(GameState state)
    {
        m_OnTurnChange.Invoke(state);
        Debug.Log("Turn changed to " + state);
        m_GameState = state;
        StartCoroutine(CountdownCoroutine());
    }
    private void ToggleTurn()
    {
        if (m_GameState == GameState.Black)
        {
            SwitchTurn(GameState.White);
        } else 
        {
            SwitchTurn(GameState.Black);
        }
    }
    private IEnumerator CountdownCoroutine()
    {
        m_TurnTimer = m_TurnTime;
        while (m_TurnTimer > 0.0f)
        {
            m_TurnTimer -= Time.deltaTime;
            m_OnTurnTick.Invoke(m_TurnTimer);
            yield return null;
        }
        yield return null;
        ToggleTurn();        
    }
}
