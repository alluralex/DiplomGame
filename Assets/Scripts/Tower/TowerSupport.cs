using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "TowerSupport")]
public class TowerSupport : ScriptableObject
{
    public int id;
    public int health;

    public float range;

    public string Title;

    public Effect effect;
}
