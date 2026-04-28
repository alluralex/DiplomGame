using UnityEngine;
using System.Collections.Generic;
using JetBrains.Annotations;
using Assets.Scripts.Inventory;
using Assets.Scripts;

public class TowerFire : MonoBehaviour, ITakeDamage
{
    public TowerStats towerStats;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public ItemData towerItem;

    private float fireCooldown;
    private Enemy currentTarget;

    public Transform turretPart = null;
    public float rotationSpeed = 10f;

    private float CurrentHealth; 

    protected List<Enemy> enemiesInRange = new List<Enemy>();

    public bool IsAlive => throw new System.NotImplementedException();

    void Start()
    {
        CurrentHealth = towerStats.health;

        SphereCollider col = GetComponent<SphereCollider>();
        col.radius = towerStats.range;
    }


    void Update()
    {
        CleanupList();
        FindTarget();

        if (currentTarget == null) return;

        RotateToTarget();

        fireCooldown -= Time.deltaTime;

        if (fireCooldown <= 0f)
        {
            Attack(currentTarget);
            fireCooldown = 1f / towerStats.fireRate; //fireRate = выстрелы в секунду, мол если он будет 0.5, то это 2 секунды, если же 2, то выстрел каждые 0.5 секунд
        }
    }

    void FindTarget()
    {
        float shortestDistance = Mathf.Infinity;
        Enemy nearest = null;

        foreach (Enemy enemy in enemiesInRange)
        {
            if (enemy == null) continue;

            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearest = enemy;
            }
        }

        currentTarget = nearest;
    }

    void CleanupList()
    {
        enemiesInRange.RemoveAll(e => e == null);
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemiesInRange.Add(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemiesInRange.Remove(enemy);
        }
    }

    protected virtual void Attack(Enemy target)
    {
        for (int i = 0; i < towerStats.amountOfShots; i++)
        {
            GameObject projectileStartAttack = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            Projectile projectile = projectileStartAttack.GetComponent<Projectile>();
            if (projectile != null)
            {
                projectile.SetTarget(target, towerStats.damage, towerStats.typeTower);
            }
        }
    }

    void RotateToTarget()
    {
        if (currentTarget == null || turretPart == null)
            return;

        Vector3 direction = currentTarget.transform.position - turretPart.position;
        direction.y = 0f;

        Quaternion lookRotation = Quaternion.LookRotation(direction);

        turretPart.rotation = Quaternion.Lerp(
            turretPart.rotation,
            lookRotation,
            Time.deltaTime * rotationSpeed
        );
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0) Destroy(gameObject);
    }
}