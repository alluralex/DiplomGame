using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

using UnityEngine;

public class ObjectGame : MonoBehaviour
{
	[Header("Настройки ресурса")]
	public string resourceName;
	public int hitsToBreak;
	public GameObject resourceDrop;
	public int dropAmount = 1;
	public int currentHits = 0;

	
}
