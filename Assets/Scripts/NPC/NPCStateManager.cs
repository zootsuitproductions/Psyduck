using System;
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

    public float viewingAngle;
    public float viewingDistance;
    public float walkSpeed = 1f;
    public float sprintSpeed = 5f;

    NPCAbstractState currentState;
    
    public ChillState chill = new ChillState();
    public SaunterState saunter = new SaunterState();
    public FleeState flee = new FleeState();
    public DigState dig = new DigState();

    private IEnumerator queuedStateCoroutine;
    
    void Start()
    {
        currentState = chill;
        currentState.EnterState(this);
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchStateAfterTime( NPCAbstractState newState, float time)
    {
        queuedStateCoroutine = SwitchStateCoroutine(newState, time);
        StartCoroutine(queuedStateCoroutine);
    }

    public void DestroyAfter1Sec()
    {
        Invoke("destroyObject",1f);
    }

    public void OnDisable()
    {
        if (queuedStateCoroutine != null)
        {
            StopCoroutine(queuedStateCoroutine);
        }
        SwitchToState(flee);
    }

    private void destroyObject()
    {
        Destroy(gameObject);
    }
    public void SwitchToState(NPCAbstractState state)
    {
        if (queuedStateCoroutine != null)
        {
            StopCoroutine(queuedStateCoroutine);
        }
        currentState = state;
        state.EnterState(this);
    }

    private IEnumerator SwitchStateCoroutine(NPCAbstractState state, float time)
    {
        yield return new WaitForSeconds(time);
        SwitchToState(state);
    }

    public bool inView(Transform target)
    {
        float dotproduct = Vector3.Dot(transform.forward,
            Vector3.Normalize(target.position - transform.position));
        float view = 1.0f - viewingAngle;
        float distance = (transform.position - target.position).magnitude;
        return (dotproduct >= view && distance <= viewingDistance);
    }

    public void moveToLocation(Vector3 location)
    {
        _navMeshAgent.destination = location;
        animator.SetBool("Moving", true);
    }
}
