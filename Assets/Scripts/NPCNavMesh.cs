using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCNavMesh : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent _navMeshAgent;

    private enum State
    {
        Chill, Saunter, Flee, Dig
    }

    [SerializeField]
    private State currentState;
    private bool switchingState;
    
    // Start is called before the first frame update
    void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }
    
    // void Start()
    // {
    //     _navMeshAgent.destination = player.position;
    //     transform.rotation = Quaternion.LookRotation(transform.position - player.position);
    //     _navMeshAgent.destination = transform.position + transform.forward * 10;
    // }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
          case  State.Chill:
              break;
          case State.Saunter:
              break;
          case State.Flee:
              break;
          case  State.Dig:
              break;
        }
    }
}
