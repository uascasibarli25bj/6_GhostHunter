using UnityEngine;
using UnityEngine.AI;
using Unity.AI.Navigation;
using Meta.XR.MRUtilityKit;
using System.Collections;

public class RuntimeNavmeshBuilder : MonoBehaviour
{
    private NavMeshSurface navmeshSurface;

    void Start()
    {
        navmeshSurface = GetComponent<NavMeshSurface>();
        StartCoroutine(DelayedBake());
    }

    IEnumerator DelayedBake()
    {
        yield return new WaitForSeconds(1f);
        navmeshSurface.BuildNavMesh();
    }

     void BuildNavmesh()
    {
        StartCoroutine(BuildNavmeshRutine());
    }

    public IEnumerator BuildNavmeshRutine()
    {
        yield return new WaitForEndOfFrame();
        navmeshSurface.BuildNavMesh();
    }
}
