using UnityEngine;

public class ObjectDetector : MonoBehaviour
{
    [SerializeField]
    private FieldSpawner fieldSpawner;

    private Camera mainCamera;
    private Ray ray;
    private RaycastHit hit;

    private void Awake()
    {
        mainCamera = Camera.main;

    }
    
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if(hit.transform.CompareTag("Tile"))
                {
                    fieldSpawner.SpawnField(hit.transform);
                }
            }
        }
    }
}
