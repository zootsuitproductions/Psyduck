using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SaunterState : NPCAbstractState
{
    private Vector3 lastPosition;

    private IEnumerator timedSwitch;
   public override void EnterState(NPCStateManager manager)
   {
       
       manager.animator.SetBool("Sprinting", false);
       manager.animator.SetBool("Moving", true);
       manager._navMeshAgent.speed = manager.walkSpeed;
       manager._navMeshAgent.destination = findDestination(manager.worldCorner1.position, manager.worldCorner2.position);
       manager.SwitchStateAfterTime(manager.chill, Random.Range(5f, 10f));
       
   }
   
   public override void UpdateState(NPCStateManager manager)
   {
       if (manager.inView(manager.player))
       {
           
           manager.SwitchToState(manager.flee);
           return;
       }
       bool reachedDestination = manager.transform.position == manager._navMeshAgent.destination;
       if (reachedDestination)
       {
           manager.SwitchToState(manager.chill);
       }
   }

   private Vector3 findDestination(Vector3 p1, Vector3 p2)
   {
      float x = Random.Range(p1.x, p2.x);
      float z = Random.Range(p1.z, p2.z);

      return new Vector3(x, Terrain.activeTerrain.SampleHeight(new Vector3(x, 0f, z)), z);
   }
}
