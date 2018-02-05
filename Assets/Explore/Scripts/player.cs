using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
	public static int charapter;
	public static int coins;
	public static int silver;
	public static int cooper;
	public static int skillpoints;
	public static int exp;
	public static int hp;
	public static int max_hp;
	public static int mp;
	public static int max_mp;
	public static int defense;
	public static int Str; // CURRENT Strength
	public static int Dex; // CURRENT Dexterity
	public static int Con; // CURRENT Consitution
	public static int Int; // CURRENT Intellect
	public static int Bon_Str; // BONUS
	public static int Bon_Dex; // BONUS
	public static int Bon_Con; // BONUS
	public static int Bon_Int; // BONUS
	public static int Def_Str; // DEFAULT
	public static int Def_Dex; // DEFAULT
	public static int Def_Con; // DEFAULT
	public static int Def_Int; // DEFAULT
	[Header("Sounds")]
	public AudioSource coin_pickup;
	public AudioSource potion_pickup;
	[Header("Attack settings")] // Для атаки
	public static int full_damage;
	public static int def_damage;
	public Transform punch1;
	public float punch1Radius;
	public static bool attack = false;
	// Для спеллов
	public static bool spell1 = false;
	public static bool spell2 = false;
	public static bool spell3 = false;
	[Header("Equipment")]
	public static string helmet_id;
	public static string plate_id;
	public static string gloves_id;
	public static string boots_id;

	void Start () {
		coins = PlayerPrefs.GetInt("Coins");
		silver = PlayerPrefs.GetInt("Silver");
		cooper = PlayerPrefs.GetInt("Cooper");
		exp = PlayerPrefs.GetInt("Exp");
		hp = PlayerPrefs.GetInt("Hp");
		mp = PlayerPrefs.GetInt("Mp");
		charapter = PlayerPrefs.GetInt("Char");
		helmet_id = PlayerPrefs.GetString("Helmet");
		plate_id = PlayerPrefs.GetString("Plate");
		gloves_id = PlayerPrefs.GetString("Gloves");
		boots_id = PlayerPrefs.GetString("Boots");
	}

	void Update () {
		// Сохранение значений
		PlayerPrefs.SetInt("Char", charapter);
		PlayerPrefs.SetInt("Coins", coins);
		PlayerPrefs.SetInt("Silver", silver);
		PlayerPrefs.SetInt("Cooper", cooper);
		PlayerPrefs.SetInt("Exp", exp);
		PlayerPrefs.SetInt("Hp", hp);
		PlayerPrefs.SetInt("Mp", mp);
		PlayerPrefs.SetString("Helmet", helmet_id);
		PlayerPrefs.SetString("Plate", plate_id);
		PlayerPrefs.SetString("Gloves", gloves_id);
		PlayerPrefs.SetString("Boots", boots_id);

		// Считаем текущие характеристики персонажа. (Стандартные + бонусные)
		max_hp = Con * 28;
		max_mp = Int * 12;
		Str = Def_Str + Bon_Str;
		Dex = Def_Dex + Bon_Dex;
		Con = Def_Con + Bon_Con;
		Int = Def_Int + Bon_Int;

		// Действия
		if(Input.GetButtonDown("attack"))
		{
			StartCoroutine (attack_func ());
			Fight2D.Action(punch1.position, punch1Radius, 10, full_damage, false);
		}
		if(Input.GetButtonDown("spell_1"))
		{
			if (spell1 == false) {
				Fight2D.Action (punch1.position, punch1Radius, 10, full_damage + 15, false);
			}
			StartCoroutine (spell1_func ());
		}
		if(Input.GetButtonDown("spell_2"))
		{
			if (spell2 == false) {
				Fight2D.Action (punch1.position, punch1Radius, 10, full_damage + 25, false);
			}
			StartCoroutine (spell2_func ());
		}
		if(Input.GetButtonDown("spell_3"))
		{
			if (spell3 == false) {
				hp = hp + 10;
				if (hp > max_hp) {hp = max_hp;}
			}
			StartCoroutine (spell3_func ());
		}

		// Задаем параметры персонажам
		// 1 персонаж
		if (charapter == 1) {
			Def_Str = 5;
			Def_Dex = 5;
			Def_Con = 5;
			Def_Int = 5;
			full_damage = def_damage + (Str/2);
		}
		// 2 персонаж
		if (charapter == 2) {
			Def_Str = 2;
			Def_Dex = 6;
			Def_Con = 4;
			Def_Int = 8;
			full_damage = def_damage + (Str/2);
		}
		// 3 персонаж
		if (charapter == 3) {
			Def_Str = 4;
			Def_Dex = 7;
			Def_Con = 5;
			Def_Int = 4;
			full_damage = def_damage + (Str/2);
		}
		// 4 персонаж
		if (charapter == 4) {
			Def_Str = 8;
			Def_Dex = 3;
			Def_Con = 7;
			Def_Int = 2;
			full_damage = def_damage + (Str/2);
		}
		// 5 персонаж
		if (charapter == 5) {
			Def_Str = 6;
			Def_Dex = 4;
			Def_Con = 8;
			Def_Int = 2;
			full_damage = def_damage + (Str/2);
		}

		// ТЕСТ ФУНКЦИИ
		if (Input.GetKeyDown (KeyCode.T)) {
			coins = 1;
			silver = 1;
			cooper = 1;
			exp = 1;
			hp = 10;
			mp = 10;
		}
		if (Input.GetKeyDown (KeyCode.Y)) {
			coins = 60000;
			silver = 100;
			cooper = 20;
			exp = 10000;
			hp = max_hp;
			mp = max_mp;
			helmet_id = "helmet_1";
			plate_id = "plate_1";
			gloves_id = "gloves_1";
			boots_id = "boots_1";
		}
		if (Input.GetKeyDown (KeyCode.Return)) {
			exp = exp + 100;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Coins"))
		{
			Destroy(other.gameObject);
			coin_pickup.Play();
			coins = coins + Random.Range(0, 10);
		}
		if (other.gameObject.CompareTag("HpPotion"))
		{
			Destroy(other.gameObject);
			potion_pickup.Play();
			hp = hp + 45;
			if (hp > max_hp) {hp = max_hp;}
		}
		if (other.gameObject.CompareTag("MpPotion"))
		{
			Destroy(other.gameObject);
			potion_pickup.Play();
			mp = mp + 20;
			if (mp > max_mp) {mp = max_mp;}
		}
	}
	public IEnumerator attack_func() {
		if (attack == false) {
			attack = true;
			yield return new WaitForSeconds(0.5f); // Скорость атаки (Имитация)
			attack = false;
		}
	}
	public IEnumerator spell1_func() {
		if (spell1 == false) {
			spell1 = true;
			yield return new WaitForSeconds(2f); // Откат скилла
			spell1 = false;
		}
	}
	public IEnumerator spell2_func() {
		if (spell2 == false) {
			spell2 = true;
			yield return new WaitForSeconds(5f); // Откат скилла
			spell2 = false;
		}
	}
	public IEnumerator spell3_func() {
		if (spell3 == false) {
			spell3 = true;
			yield return new WaitForSeconds(5f); // Откат скилла
			spell3 = false;
		}
	}
}