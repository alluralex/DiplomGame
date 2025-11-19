using UnityEngine;

[CreateAssetMenu(fileName = "New EnemySummonData", menuName = "Create EnemySummonData")]

public class EnemySummon : ScriptableObject
{
    public GameObject EnemyPrefab;
    public int EnemyID;
}
