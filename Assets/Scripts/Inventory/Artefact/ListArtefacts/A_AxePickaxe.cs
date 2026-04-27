using Assets.Scripts.Inventory;
using UnityEngine;
[CreateAssetMenu(menuName = "Artefacts/AxePickaxeEffect")]

public class A_AxePickaxe : ArtefactEffect
{
    public override void Apply(Hero hero)
    {
        hero.upgradeInfo.ResourceMultiplayer += 20;
        hero.Artefacts.Add(this);
    }
}
