using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class JsonLogic
    {
        private static string GetPath(string fileName)
        {
            string directory = Path.GetDirectoryName(Application.dataPath);
            return Path.Combine(directory, fileName);
        }

        public static void Save<T>(T data, string fileName)
        {
            string path = GetPath(fileName);
            string directory = Path.GetDirectoryName(path);
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            string json = JsonUtility.ToJson(data, true);
            File.WriteAllText(path, json);
            Debug.Log($"Saved to {path}");
        }

        public static T Load<T>(string fileName) where T : new()
        {
            string path = GetPath(fileName);
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                return JsonUtility.FromJson<T>(json);
            }
            return new T();
        }
    }
}
