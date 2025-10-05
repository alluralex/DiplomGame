using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Hero : MonoBehaviour
{
    private Animator animator;

	private Inventory inventory = new();
	void OnTriggerEnter(Collider other)
	{
        Item itemInRange;
		Debug.Log("� ����� � �������� � �����:" + other.tag + " � � ������: " + other.name);
		if (other.CompareTag("Item"))
		{
			itemInRange = other.GetComponent<Item>();
			if (itemInRange != null)
			{
				inventory.AddToInventory(itemInRange);
				Debug.Log($"{itemInRange.name} ��� ��������!");
				Destroy(itemInRange.gameObject);
			}
		}
	}
	void Start()
	{
		animator = GetComponentInChildren<Animator>();
	}
}
