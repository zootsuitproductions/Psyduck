using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCStateManager : MonoBehaviour
{

    public Transform player;
    public NavMeshAgent _navMeshAgent;

    public Transform worldCorner1;
    public Transform worldCorner2;

    NPCAbstractState currentState;
    public SaunterState saunter = new SaunterState();
    
    void Start()
    {
        currentState = saunter;
        currentState.EnterState(this);
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(NPCAbstractState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
