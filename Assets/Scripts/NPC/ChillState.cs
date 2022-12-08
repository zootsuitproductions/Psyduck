using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChillState : NPCAbstractState
{
    public override void EnterState(NPCStateManager manager)
    {
        
        manager.animator.SetBool("Sprinting", false);
        manager.animator.SetBool("Moving", false);
        manager._navMeshAgent.destination = manager.transform.position;
        manager.SwitchStateAfterTime(manager.saunter, Random.Range(5f, 7f));
    }

    public override void UpdateState(NPCStateManager manager)
    {
        if (manager.inView(manager.player))
        {
            manager.SwitchToState(manager.dig);
        }
    }
}
