using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Inventory.Artefact.ListArtefacts
{
    [CreateAssetMenu(menuName = "Artefacts/ArrowStandEffect")]
    public class A_ArrowStand : ArtefactEffect
    {
        public GameObject StandHero;

        public int Damage;

        public float AttackSpeed;

        public override void Apply(Hero hero)
        {
            GameObject spirit = Instantiate(StandHero, hero.transform.position, Quaternion.identity);
            spirit.transform.SetParent(hero.transform);
        }
    }
}
