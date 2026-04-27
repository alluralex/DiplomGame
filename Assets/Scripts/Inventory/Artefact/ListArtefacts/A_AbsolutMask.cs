using Assets.Scripts.Inventory;
using UnityEngine;
[CreateAssetMenu(menuName = "Artefacts/AbsolutMaskEffect")]
public class A_AbsolutMask : ArtefactEffect
{
    public override void Apply(Hero hero)
    {
        hero.upgradeInfo.damageMultiplayer += 0.25f;
        hero.Artefacts.Add(this);
    }
}
