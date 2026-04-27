using Assets.Scripts.Inventory;
using UnityEngine;
[CreateAssetMenu(menuName = "Artefacts/CouponForSellEffect")]
public class A_CouponForSell : ArtefactEffect
{
    public override void Apply(Hero hero)
    {
        hero.GridManager.cellCost = hero.GridManager.cellCost / 2;
        hero.GridManager.moneyadd = hero.GridManager.moneyadd / 2;
        hero.GridManager.gridUI.CostZone.text = hero.GridManager.cellCost.ToString();
        hero.Artefacts.Add(this);

    }
}
