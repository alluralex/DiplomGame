using System.Collections.Generic;
using UnityEngine;

public class ListPrefabs : MonoBehaviour
{
    [SerializeField] private GameObject prefTree;
    [SerializeField] private GameObject prefStone;
    [SerializeField] private GameObject prefIron;
    [SerializeField] private GameObject prefCrystal;

    public List<GameObject> prefabsObject = new List<GameObject>();

    public static ListPrefabs Instance;

    private void Awake()
    {
        Instance = this;
        
        prefabsObject.Clear();

        prefabsObject.Add(prefTree);
        prefabsObject.Add(prefStone);
        prefabsObject.Add(prefIron);
        prefabsObject.Add(prefCrystal);
    }
}
