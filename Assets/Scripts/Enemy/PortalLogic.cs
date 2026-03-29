using Assets.Scripts;
using Assets.Scripts.Field;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class PortalLogic : MonoBehaviour
{

    public List<GameObject> prefabs;

    private void OnEnable()
    {
        GlobalEvents.unityEvent.AddListener(SpawnMobs);
    }

    private void SpawnMobs(int wave)
    {
        for (int i = 0; i < wave; i++)
        {
            {
                foreach (GameObject prefab in prefabs)
                {
                    float sideOffset = Random.Range(1f, 2f);
                    float forwardOffset = Random.Range(-1.5f, 1.5f);

                    Vector3 spawnMob =
                        transform.position +
                        transform.forward * forwardOffset +
                        transform.right * sideOffset;

                    Instantiate(prefab, spawnMob, transform.rotation);
                }
            }
        }
    }
}