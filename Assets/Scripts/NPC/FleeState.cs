using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeState : NPCAbstractState
{
    private float timeEnteredAt;
    public override void EnterState(NPCStateManager manager)
    {
        timeEnteredAt = Time.time;
        manager._navMeshAgent.speed = manager.sprintSpeed;
        manager.animator.SetBool("Sprinting", true);
        manager.animator.SetBool("Moving", true);

        Vector3 playerPos = manager.player.position;
        if (Mathf.Abs((manager.worldCorner1.position - playerPos).magnitude) >
            Mathf.Abs((manager.worldCorner2.position - playerPos).magnitude))
        {
            manager.moveToLocation(manager.worldCorner1.position);
        }
        else
        {
            manager.moveToLocation(manager.worldCorner2.position);
        }
        
    }

    public override void UpdateState(NPCStateManager manager)
    {
        bool reachedDestination = manager.transform.position == manager._navMeshAgent.destination;

        float timeSinceEnter = Time.time - timeEnteredAt;
        if (reachedDestination || timeSinceEnter > 10f)
        {
            if ((manager.player.position - manager.transform.position).magnitude > 20f)
            {
                manager.SwitchToState(manager.saunter);
            }
            else
            {
                manager.SwitchToState(manager.dig);
            }
        }
    }
}
