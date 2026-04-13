using Assets.Scripts;
using UnityEngine;

[CreateAssetMenu(menuName = "Tower Stats")]
public class TowerStats : ScriptableObject
{
    public int id;
    public int health;
    public int damage;

    public float range;
    public float fireRate;

    public string Title;

    public int amountOfShots;

    public TypeAspect typeTower;
}
