using Assets.Scripts;
using Assets.Scripts.Enemy;
using Assets.Scripts.UI.GameEnd;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyData enemyData;

    private Hero playerHero;
    private float currentHealth;

   private float attackCooldown = 2f;
   private int attackDamage = 10;

    private Coroutine attackCoroutine;
    private ITakeDamage currentTarget;


    void Start()
    {
        playerHero = FindFirstObjectByType<Hero>();
        if (enemyData != null)
            currentHealth = enemyData.MaxHealth;
    }

    public void Init(EnemyData data)
    {
        enemyData = data;
        currentHealth = enemyData.MaxHealth;
    }

    private float GetDamageMultiplier(TypeAspect damageType, TypeAspect enemyType, float heroMultiplier)
    {
        float typeMultiplier = 1f;
        if (damageType == enemyType)
            typeMultiplier = 1f;
        else if ((damageType == TypeAspect.Lighting && enemyType == TypeAspect.Magic) ||
                 (damageType == TypeAspect.Magic && enemyType == TypeAspect.Physics) ||
                 (damageType == TypeAspect.Physics && enemyType == TypeAspect.Lighting))
            typeMultiplier = 1.5f;
        else
            typeMultiplier = 1f / 1.5f;

        return typeMultiplier * heroMultiplier;
    }

    internal void TakeDamage(float damage, TypeAspect typeDamage)
    {
        if (playerHero == null) return;

        float heroMultiplier = playerHero.GetDamageMultiplayer();
        float multiplier = GetDamageMultiplier(typeDamage, enemyData.TypeEnemy, heroMultiplier);
        float finalDamage = damage * multiplier;

        currentHealth -= finalDamage;
        Debug.Log($"Урон: {finalDamage}, ХП осталось: {currentHealth}");

        if (currentHealth <= 0) Die();
    }

    public void Die()
    {
        if (enemyData.IsBoss == true)
        {
            GlobalEvents.OnBossDefeated?.Invoke();
        }

        int money = enemyData.MoneyDrop + (playerHero.upgradeInfo?.MoneyAdd ?? 0);
        playerHero.GetMoney(money);
        StatisticAfterGame.EnemiesKilled++;
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger) return;
        ITakeDamage target = other.GetComponent<ITakeDamage>();
        if (target == null) return;

        if (attackCoroutine != null) StopCoroutine(attackCoroutine);
        currentTarget = target;
        attackCoroutine = StartCoroutine(AttackRoutine());
    }

    private void OnTriggerExit(Collider other)
    {
        ITakeDamage target = other.GetComponent<ITakeDamage>();
        if (target != null && target == currentTarget)
        {
            if (attackCoroutine != null)
                StopCoroutine(attackCoroutine);
            currentTarget = null;
            attackCoroutine = null;
        }
    }

    private IEnumerator AttackRoutine()
    {
        while (true)
        {
            currentTarget.TakeDamage(attackDamage);
            yield return new WaitForSeconds(attackCooldown);
        }
    }
}