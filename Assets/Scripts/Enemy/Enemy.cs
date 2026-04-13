using Assets.Scripts;
using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int ID;
    public float MaxHealth;
    public float Health;
    public float Damage;

    public int MoneyDrop;

    public TypeAspect TypeEnemy;

    private Hero playerHero;

    void Start()
    {
        playerHero = FindAnyObjectByType<Hero>();
    }

    public void Init()
    {
        Health = MaxHealth;
    }

    float GetDamageMultiplier(TypeAspect damageType, TypeAspect enemyType)
    {
        if (damageType == enemyType)
            return 1f;

        if (damageType == TypeAspect.Lighting && enemyType == TypeAspect.Magic)
            return 1.5f;

        if (damageType == TypeAspect.Magic && enemyType == TypeAspect.Physics)
            return 1.5f;

        if (damageType == TypeAspect.Physics && enemyType == TypeAspect.Lighting)
            return 1.5f;

        return 1f / 1.5f;
    }

    internal void TakeDamage(float damage, TypeAspect typeDamage)
    {
        float multiplier = GetDamageMultiplier(typeDamage, TypeEnemy);

        float finalDamage = damage * multiplier;

        Health -= finalDamage;

        Debug.Log($"Урон: {finalDamage}, ХП осталось: {Health}");

        if (Health <= 0) Die();
    }

    private void Die()
    {
        playerHero.GetMoney(MoneyDrop);
        //playerHero.Statistic.KilledEnemies += 1;
        Destroy(gameObject);
    }
}
