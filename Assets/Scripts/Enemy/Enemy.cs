using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int ID;
    public float MaxHealth;
    public float Health;
    public float Damage;
    
    public void Init()
    {
        Health = MaxHealth;
    }

}
