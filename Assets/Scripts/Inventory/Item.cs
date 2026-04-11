using Assets.Scripts.Inventory;
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
		public ItemData itemData;
    }

	public enum ItemType
	{
		Resource,
		Tower,
		Artefact
	}
}
