using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.PlayerSettings
{
    public static class Statistic
    {
        private static StatisticHero data = new StatisticHero();

        public static int EnemiesDied
        {
            get => data.EnemiesDied;
            set => data.EnemiesDied = value;
        }
        public static int TotalAttempts
        {
            get => data.TotalAttempts;
            set => data.TotalAttempts = value;
        }
        public static int CompletedAttempts
        {
            get => data.CompletedAttempts;
            set => data.CompletedAttempts = value;
        }
        public static int MoneyEarned
        {
            get => data.MoneyEarned;
            set => data.MoneyEarned = value;
        }
        public static int ArtefactsBuy
        {
            get => data.ArtefactsBuy;
            set => data.ArtefactsBuy = value;
        }
        public static int FieldBuy
        {
            get => data.FieldBuy;
            set => data.FieldBuy = value;
        }
        public static int HealthGetCar
        {
            get => data.HealthGetCar;
            set => data.HealthGetCar = value;
        }
        public static int CompletedCrafts
        {
            get => data.CompletedCrafts;
            set => data.CompletedCrafts = value;
        }
        public static bool TutorialCompleted
        {
            get => data.TutorialCompleted;
            set => data.TutorialCompleted = value;
        }
        public static void Save()
        {
            JsonLogic.Save(data, "statistic.json");
        }

        public static void Load()
        {
            data = JsonLogic.Load<StatisticHero>("statistic.json");
        }
    }
}
