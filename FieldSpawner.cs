using UnityEngine;

public class FieldSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject fieldPrefab;

    public void SpawnField(Transform tileTransform)
    {
        Instantiate(fieldPrefab, tileTransform.position, Quaternion.identity);
    }
}