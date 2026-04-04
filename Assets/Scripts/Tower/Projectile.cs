using Assets.Scripts;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Enemy target;
    private int damage;
    private TypeAspect typeDamage;

    public float speed = 10f;

    public void SetTarget(Enemy _target, int _damage, TypeAspect _typeDamage)
    {
        target = _target;
        damage = _damage;
        typeDamage = _typeDamage;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.transform.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target.transform);
    }

    void HitTarget()
    {
        target.TakeDamage(damage, typeDamage);
        Destroy(gameObject);
    }
}