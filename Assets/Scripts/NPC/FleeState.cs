using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeState : NPCAbstractState
{
    public override void EnterState(NPCStateManager manager)
    {
        manager._navMeshAgent.speed = manager._navMeshAgent.speed = manager.sprintSpeed;

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
        if (reachedDestination)
        {
            manager.SwitchToState(manager.saunter);
        }
    }
}
