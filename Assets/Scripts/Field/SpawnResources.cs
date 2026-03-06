using UnityEditor;
using UnityEngine;

public class SpawnResources : MonoBehaviour
{
    private int amountSpawn;

    Renderer renderer;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        Vector3 floorbebra = renderer.bounds.size;
        Vector3 floorbebraCenter = renderer.bounds.center;
        foreach (var item in ListPrefabs.prefabsObject)
        {
            amountSpawn = Random.Range(1, 3);

            for (int i = 0; i < amountSpawn; i++)
            {


                float VectorX = Random.Range(-floorbebra.x/2f+1, floorbebra.x/2f-1);
                var VectorZ = Random.Range(-floorbebra.z / 2f+1, floorbebra.z / 2f-1);
                Vector3 spawnPosition = new Vector3(floorbebraCenter.x+VectorX, 0.5f, floorbebraCenter.z+VectorZ);

                Instantiate(item, spawnPosition, Quaternion.Euler(270, 0, 0), gameObject.transform.parent);

            }
        }
    }

}
