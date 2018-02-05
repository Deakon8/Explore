using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class equipment : MonoBehaviour {

	[Header("General")]
	public string title;
	public string description;
	[Header("Characteristics[Weapon]")]
	public int atkdamage; // Урон от оружия.
	public int range; // Радиус атаки.
	public bool mass_attack; // Удар по всем целям в зоне или нет.
	public int atkspeed; // Задержка между ударами.
	[Header("Characteristics[Armor]")]
	public int defense; // Параметр защиты.
	[Header("Bonuses")]
	public int bonus_str;
	public int bonus_dex;
	public int bonus_con;
	public int bonus_int;

	public enum Type{
		weapon1, weapon2, helmet, plate, gloves, boots
	}

	void Start () {

	}

	void Update () {
		
	}
}
