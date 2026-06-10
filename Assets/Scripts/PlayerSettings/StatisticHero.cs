using System;
using UnityEngine;

[Serializable]
public class StatisticHero
{
    public int EnemiesDied;
    public int TotalAttempts;
    public int CompletedAttempts;
    public int MoneyEarned;
    public int ArtefactsBuy;
    public int FieldBuy;
    public int HealthGetCar;
    public int CompletedCrafts;

    public bool TutorialCompleted = false;
    public bool IsAdmin = false;
}
