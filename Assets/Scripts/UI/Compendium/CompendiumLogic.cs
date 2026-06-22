using Assets.Scripts;
using System;
using Unity.VisualScripting;
using UnityEngine;

public class CompendiumLogic : MonoBehaviour
{
    private TypeAspect typeAspect;
    private bool isTowerMenu;

    public void AspectPhys()
    {
        typeAspect = TypeAspect.Physics;
    }
    public void AspectMagic()
    {
        typeAspect = TypeAspect.Magic;

    }
    public void AspectLight()
    {
        typeAspect = TypeAspect.Lighting;

    }
    public void ChangeToTower()
    {
        isTowerMenu = true;
    }
    public void ChangeToMob()
    {
        isTowerMenu = false;
        ChangeMenu();
    }

    private void ChangeMenu()
    {
        switch (typeAspect)
        {
            case TypeAspect.Lighting:
                switch (isTowerMenu)
                {
                    case true:
                        break;
                    case false:
                        break;
                }
                break;
            case TypeAspect.Magic:
                switch (isTowerMenu)
                {
                    case true:
                        break;
                    case false:
                        break;
                }
                break;
            case TypeAspect.Physics:
                switch (isTowerMenu)
                {
                    case true:
                        break;
                    case false:
                        break;
                }
                break;
            default:
                break;
        }
    }
}
