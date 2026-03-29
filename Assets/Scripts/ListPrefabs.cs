using System.Collections.Generic;
using UnityEngine;

public class ListPrefabs : MonoBehaviour
{
    [SerializeField] static public GameObject prefTree ;
    [SerializeField] static public GameObject prefStone;
    [SerializeField] static public GameObject prefIron ;
    [SerializeField] static public GameObject prefCrystal;

    static public List<GameObject> prefabsObject = new List<GameObject>();

    public void Awake()
    {
        prefTree = GameObject.FindGameObjectWithTag("TreeTag");
        prefStone = GameObject.FindGameObjectWithTag("StoneTag");
        prefIron = GameObject.FindGameObjectWithTag("IronTag");
        prefCrystal = GameObject.FindGameObjectWithTag("CrystalTag");
        

        prefabsObject.Add(prefTree);
        prefabsObject.Add(prefStone);
        prefabsObject.Add(prefIron);
        prefabsObject.Add(prefCrystal);
    }
}
