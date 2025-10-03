using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionWithObjects : MonoBehaviour
{
	[Header("Настройки ресурса")]
	public string resourceName;
	public int hitsToBreak;
	public GameObject resourceDrop;
	public int dropAmount = 1;

	private int currentHits = 0;
	private bool playerInRange = false;
	private float mineCooldown = 0.33f;
	private float nextMineTime = 0f;

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			playerInRange = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			playerInRange = false;
		}
	}

	void Update()
	{
		if (playerInRange && Input.GetKeyDown(KeyCode.E) && Time.time >= nextMineTime)
		{
			MineResource();
			DropResource();
			nextMineTime = Time.time + mineCooldown;
		}
		else if (playerInRange && Input.GetKeyDown(KeyCode.E) && Time.time < nextMineTime)
		{
			Debug.Log($"Колдаун ещё не прошёл. Оставшееся время = {nextMineTime}");
		}
	}

	void MineResource()
	{
		currentHits++;
		Debug.Log($"Добыча {resourceName} {currentHits}/{hitsToBreak}");

		if (currentHits >= hitsToBreak)
		{
			Destroy(gameObject);
		}
	}

	void DropResource()
	{
		for (int i = 0; i < dropAmount; i++)
		{
			Vector3 randomOffset = new Vector3(
				Random.Range(-0.7f, 0.7f),      
				-0.5f,
				Random.Range(-0.7f, 0.7f)  
			);

			Vector3 spawnPosition = transform.position + randomOffset;

			Instantiate(resourceDrop, spawnPosition, Quaternion.Euler(270,0,0));
		}
	}
}
