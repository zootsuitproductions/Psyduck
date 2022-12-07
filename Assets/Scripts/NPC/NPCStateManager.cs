using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCStateManager : MonoBehaviour
{

    public Transform player;
    public NavMeshAgent _navMeshAgent;
    public Animator animator;

    public Transform worldCorner1;
    public Transform worldCorner2;

    NPCAbstractState currentState;
    public ChillState chill = new ChillState();
    public SaunterState saunter = new SaunterState();
    
    void Start()
    {
        currentState = chill;
        currentState.EnterState(this);
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchStateAfterTime( NPCAbstractState state, float time)
    {
        StartCoroutine(SwitchState(state, time));
    }

    IEnumerator SwitchState(NPCAbstractState state, float time)
    {
        yield return new WaitForSeconds(time);
        animator.SetBool("Moving", false);
        currentState = state;
        state.EnterState(this);
    }
}
