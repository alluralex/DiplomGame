using UnityEngine;

namespace Assets.Scripts.Inventory
{
    public abstract class ArtefactEffect : ScriptableObject
    {
        public abstract void Apply(Hero hero);
    }
}