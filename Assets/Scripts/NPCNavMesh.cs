using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCNavMesh : MonoBehaviour
{
    public Transform player;

    private NavMeshAgent _navMeshAgent;
    
    // Start is called before the first frame update
    void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }
    
    void Start()
    {
        _navMeshAgent.destination = player.position;
        transform.rotation = Quaternion.LookRotation(transform.position - player.position);
        _navMeshAgent.destination = transform.position + transform.forward * 10;
    }

    // Update is called once per frame
    void Update()
    {
        // _navMeshAgent.destination = player.position;
    }
}
