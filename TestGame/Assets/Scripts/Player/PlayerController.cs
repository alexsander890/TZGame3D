using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] State state;
    [SerializeField] Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Walk());
        }
    }

    IEnumerator Walk()
    {
        yield return new WaitForSeconds(0.2f);

        if (state.GetStatMove())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                agent.SetDestination(hit.point);
                animator.SetBool("isWalk", true);
                StartCoroutine(WaitDestination());
            }
        }
    }

    IEnumerator WaitDestination()
    {
        yield return new WaitForSeconds(0.1f);

        if (agent.remainingDistance<0.5f)
        {
            Debug.Log("Stop Goblin");
            animator.SetBool("isWalk", false);
            StopAllCoroutines();
        }
        else StartCoroutine(WaitDestination());

    }
}
