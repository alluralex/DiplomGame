using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float MaxHealth;
    public float Health;
    public float Damage;
    public int ID;
    
    public void Init()
    {
        Health = MaxHealth;
    }

}
