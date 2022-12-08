using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class DigState : NPCAbstractState
{
    private float startTime;
    private float waitTimeBeforeSinking = 1f;
    public override void EnterState(NPCStateManager manager)
    {
        startTime = Time.time;
        manager.animator.SetBool("Sprinting", false);
        manager.animator.SetBool("Moving", false);
        manager._navMeshAgent.destination = manager.transform.position;
        manager.animator.SetTrigger("Dig");
        manager.DestroyAfter1Sec();
    }

    public override void UpdateState(NPCStateManager manager)
    {
        
        if (Time.time - startTime >= waitTimeBeforeSinking)
        {
            
            manager._navMeshAgent.enabled = false;
            manager.transform.Translate(Vector3.down * Time.deltaTime);
        }
    }
}
