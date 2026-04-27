using Assets.Scripts.Inventory;
using UnityEngine;

[CreateAssetMenu(menuName = "Artefacts/PiggyMoneyEffect")]
public class A_PiggyMoney : ArtefactEffect
{
    public override void Apply(Hero hero)
    {
        hero.upgradeInfo.MoneyAdd += 1;
        hero.Artefacts.Add(this);
    }
}
