using UnityEngine;

public class RayGun : MonoBehaviour
{
    public LayerMask layermask;
    public OVRInput.RawButton shootingButton;
    public LineRenderer linePrefab;
    public Transform shootingPoint;
    public float maxLineDistance = 5;
    public float lineShowerTimer = 0.3f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(shootingButton))
        {
            Shoot();
        }
    }
    
    public void Shoot()
    {
        Ray ray = new Ray(shootingPoint.position, shootingPoint.forward);
        bool hasHit = Physics.Raycast(ray, out RaycastHit hit, maxLineDistance, layermask);

        LineRenderer line = Instantiate(linePrefab);
        line.positionCount = 2;
        line.SetPosition(0, shootingPoint.position);

        Vector3 endPoint = shootingPoint.position + shootingPoint.forward * maxLineDistance;

        line.SetPosition(1, endPoint);

        Destroy(line.gameObject, lineShowerTimer);
    }
}
