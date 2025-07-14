
using Unity.VisualScripting;
using UnityEngine;

public class CameraPointer : MonoBehaviour
{
    [SerializeField] GameObject sphereRef;
    [SerializeField] LayerMask avoidMask;
    private GameObject sphereTest;

    public bool placing = false;
    private bool canPlace = false;

    [SerializeField] Material wrongMaterial;
    [SerializeField] Material correctMaterial;
    private void Start()
    {
        sphereTest = Instantiate(sphereRef); 
        Material[] materialsArray = new Material[(sphereTest.GetComponent<Renderer>().materials.Length + 1)];
        sphereTest.GetComponent<Renderer>().materials.CopyTo(materialsArray, 0);
        materialsArray[materialsArray.Length - 1] = wrongMaterial;
        sphereTest.GetComponent<Renderer>().materials = materialsArray;
    }
    void Update()
    {
        if (placing)
        {
            ProcessPlaceCheck();
            ProcessBuildTurret();
        }
    }

    private void ProcessPlaceCheck()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 100))
        {
            if (hit.collider.CompareTag("Turret"))
            {
                canPlace = true;
                var turretBase = hit.collider.GetComponent<Turret>().parent;
                var newPos = turretBase.transform.position;
                newPos.y += turretBase.turretAmount * 1f;
                sphereTest.transform.position = newPos;
            }
            else
            {
                if (hit.collider.CompareTag("Floor"))
                {
                    Debug.DrawLine(ray.origin, hit.point, Color.yellow, 1);

                    if (Physics.OverlapSphere(hit.point, 0.75f, avoidMask).Length <= 0)
                    { canPlace = true; }
                    else
                    {
                        canPlace = false;
                        foreach (Collider coll in Physics.OverlapSphere(hit.point, 0.75f, avoidMask))
                            Debug.Log(coll.name);
                    }
                }
                else
                { canPlace = false; }

                sphereTest.transform.position = hit.point;
            }

            if (canPlace)
            { ChangeMaterial(correctMaterial); }
            else
            { ChangeMaterial(wrongMaterial); }
        }
    }

    private void ProcessBuildTurret()
    {
        if (canPlace && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100))
            {

            }
        }
    }

    private void ChangeMaterial(Material mat)
    {
        Material[] materialsArray = sphereTest.GetComponent<Renderer>().materials;
        materialsArray[materialsArray.Length - 1] = mat;
        sphereTest.GetComponent<Renderer>().materials = materialsArray;
    }
}
