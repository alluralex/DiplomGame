using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
	public class Item : MonoBehaviour
	{
		public string Name;
		public Texture2D Image;
        public int? buyPrice;
        public int sellPrice;

		public ItemType type;
    }

	public enum ItemType
	{
		Resource,
		Tower
	}
}
