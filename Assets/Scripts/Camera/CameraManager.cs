using Unity.VisualScripting;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] Transform[] cameraPositions;
    [SerializeField] Camera camera;
    private int currentCameraIndex = 0;

    private void Start()
    {
        camera.transform.position = cameraPositions[0].position;
        camera.transform.rotation = cameraPositions[0].rotation;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        { 
            currentCameraIndex--; 
            if (currentCameraIndex < 0)
            { currentCameraIndex = cameraPositions.Length - 1; }
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            currentCameraIndex++;
            if (currentCameraIndex > cameraPositions.Length - 1)
            { currentCameraIndex = 0; }
        }

        camera.transform.position = Vector3.Lerp(camera.transform.position, cameraPositions[currentCameraIndex].position, 0.1f);
        camera.transform.rotation = Quaternion.Lerp(camera.transform.rotation, cameraPositions[currentCameraIndex].rotation, 0.1f);
    }
}
