using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Bullet2D : MonoBehaviour {

	public int damage;
	public float durability;

	void Start()
	{
		// уничтожить объект по истечению указанного времени (секунд), если пуля никуда не попала
		Destroy(gameObject, durability);
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(!coll.isTrigger) // чтобы пуля не реагировала на триггер
		{
			switch(coll.tag)
			{
			case "Player":
				Fight2D.Action(this.transform.position, 0.15f, 11, damage, false);
				Destroy(gameObject);
				break;
			case "Enemy_2":
				// что-то еще...
				break;
			}
		}
	}
}
