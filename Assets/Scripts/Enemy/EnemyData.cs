using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    [CreateAssetMenu(menuName ="EnemyData")]
    public class EnemyData : ScriptableObject
    {
        public int ID;
        public float MaxHealth;
        public float Health;
        public float Damage;

        public float HealthPerWave = 0f;
        public float DamagePerWave = 0f;

        public int MoneyDrop;

        public TypeAspect TypeEnemy;

        public bool IsBoss;
    }
}
