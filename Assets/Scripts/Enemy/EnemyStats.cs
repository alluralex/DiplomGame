using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public string EnemyName {  get; set; }

    public int HealthEnemy {  get; set; }

    public int DamageEnemy { get; set; }

    public TypeEnemy Type { get; set; }
    public int DropMoney { get; set; }
}


public class TypeEnemy
{
    public bool Fly { get; set; }

    public bool OnEarth { get; set; }

    public bool UnderEarth { get; set; }
}