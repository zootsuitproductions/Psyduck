using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChillState : NPCAbstractState
{
    public override void EnterState(NPCStateManager manager)
    {
        manager._navMeshAgent.destination = manager.transform.position;
        manager.SwitchStateAfterTime(manager.saunter, Random.Range(5f, 15f));  
    }

    public override void UpdateState(NPCStateManager manager)
    {
        // throw new System.NotImplementedException();
    }
}
