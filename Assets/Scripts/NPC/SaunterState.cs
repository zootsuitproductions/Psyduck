using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SaunterState : NPCAbstractState
{
   public override void EnterState(NPCStateManager manager)
   {
           
       manager._navMeshAgent.destination = findDestination(manager.worldCorner1.position, manager.worldCorner2.position);
            
   }
   
   public override void UpdateState(NPCStateManager manager)
   {
      
   }

   private Vector3 findDestination(Vector3 p1, Vector3 p2)
   {
      float x = Random.Range(p1.x, p2.x);
      float z = Random.Range(p1.z, p2.z);

      return new Vector3(x, Terrain.activeTerrain.SampleHeight(new Vector3(x, 0f, z)), z);

   }
}
