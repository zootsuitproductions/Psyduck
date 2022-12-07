using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SaunterState : NPCAbstractState
{
    private Vector3 lastPosition;
   public override void EnterState(NPCStateManager manager)
   {
       
       manager._navMeshAgent.destination = findDestination(manager.worldCorner1.position, manager.worldCorner2.position);
       manager.SwitchStateAfterTime(manager.chill, Random.Range(5f, 10f));
       manager.animator.SetBool("Moving", true);
   }
   
   public override void UpdateState(NPCStateManager manager)
   {
       bool reachedDestination = manager.transform.position == manager._navMeshAgent.destination;
       if (reachedDestination)
       {
           manager.animator.SetBool("Moving", false);
       }
   }

   private Vector3 findDestination(Vector3 p1, Vector3 p2)
   {
      float x = Random.Range(p1.x, p2.x);
      float z = Random.Range(p1.z, p2.z);

      return new Vector3(x, Terrain.activeTerrain.SampleHeight(new Vector3(x, 0f, z)), z);
        
   }
}
