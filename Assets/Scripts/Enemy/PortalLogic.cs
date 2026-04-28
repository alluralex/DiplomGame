using Assets.Scripts;
using Assets.Scripts.Enemy;
using Assets.Scripts.Field;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class PortalLogic : MonoBehaviour
{

    public List<GameObject> PhysicsMobs;
    public List<GameObject> LightingMobs;
    public List<GameObject> MagicMobs;

    private TypeAspect waveAspect;

    private void SpawnWave(int waveNumber)
    {
        waveAspect = GetRandomAspect();
        int baseCount = 3; 
        int additional = waveNumber / 2;
        int mobCount = baseCount + additional;
        for (int i = 0; i < mobCount; i++)
        {
            SpawnSingleMob();
        }
    }

    private void SpawnSingleMob()
    {
        List<GameObject> selectedList = waveAspect switch
        {
            TypeAspect.Physics => PhysicsMobs,
            TypeAspect.Lighting => LightingMobs,
            TypeAspect.Magic => MagicMobs,
            _ => PhysicsMobs
        };

        if (selectedList == null || selectedList.Count == 0)
        {
            Debug.LogWarning($"Нет мобов для аспекта {waveAspect}");
            return;
        }

        GameObject prefab = selectedList[Random.Range(0, selectedList.Count)];
        SpawnMobAtRandomPosition(prefab);
    }

    private void SpawnMobAtRandomPosition(GameObject prefab)
    {
        float sideOffset = Random.Range(1f, 2f);
        float forwardOffset = Random.Range(-1.5f, 1.5f);

        Vector3 spawnPos = transform.position +
                           transform.forward * forwardOffset +
                           transform.right * sideOffset;

        Instantiate(prefab, spawnPos, transform.rotation);
    }

    private TypeAspect GetRandomAspect()
    {
        int randomIndex = Random.Range(0, 3);
        return randomIndex switch
        {
            0 => TypeAspect.Physics,
            1 => TypeAspect.Lighting,
            _ => TypeAspect.Magic
        };
    }

    private void OnEnable()
    {
        GlobalEvents.unityEvent.AddListener(SpawnWave);
    }

    private void OnDisable()
    {
        GlobalEvents.unityEvent.RemoveListener(SpawnWave);
    }
}