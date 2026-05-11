using Assets.Scripts.Inventory;
using UnityEngine;

[CreateAssetMenu(menuName = "Artefacts/SpeedyBootsEffect")]
public class A_SpeedyBoots : ArtefactEffect
{
    public override void Apply(Hero hero)
    {
        hero.upgradeInfo.speedMultiplayer += 0.15f;
        hero.Artefacts.Add(this);
    }
}
