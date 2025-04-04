using UnityEngine;

public class CameraPointer : MonoBehaviour
{
    [SerializeField] GameObject sphereRef;
    [SerializeField] LayerMask avoidMask;
    private GameObject sphereTest;
    private void Start()
    {
        sphereTest = Instantiate(sphereRef);
    }
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 100))
        {
            if (hit.collider.CompareTag("Floor") || hit.collider.CompareTag("Turret"))
            {
                Debug.DrawLine(ray.origin, hit.point, Color.yellow, 1);

                if (Physics.OverlapSphere(hit.point, 0.5f, avoidMask).Length <= 0)
                {
                    sphereTest.transform.position = hit.point;
                }
            }
        }
    }
}
