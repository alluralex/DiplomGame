using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.PlayerSettings
{
    public static class Settings
    {
        private static SettingsPlayer data = new SettingsPlayer();

        public static float MouseGetting
        {
            get => data.MouseGetting;
            set => data.MouseGetting = value;
        }
        public static float MusicValue
        {
            get => data.MusicValue;
            set => data.MusicValue = value;
        }
        public static float SoundValue
        {
            get => data.SoundValue;
            set => data.SoundValue = value;
        }
        public static float MasterValue
        {
            get => data.MasterValue;
            set => data.MasterValue = value;
        }

        public static void Save()
        {
            JsonLogic.Save(data, "settings.json");
        }

        public static void Load()
        {
            data = JsonLogic.Load<SettingsPlayer>("settings.json");
        }
    }
}
