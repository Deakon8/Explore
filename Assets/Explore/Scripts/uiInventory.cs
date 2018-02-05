using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiInventory : MonoBehaviour {

	public GameObject Inventory_obj;
	// Подтверждения, что ячейка не пустая.
	private bool done_1 = false; // Шлем
	//private bool done_2 = false;
	private bool done_3 = false; // Плита
	//private bool done_4 = false;
	private bool done_5 = false; // Перчатки
	//private bool done_6 = false;
	private bool done_7 = false; // Ботинки
	//private bool done_8 = false;

	void Update () {
		if (Input.GetButtonDown("inventory")) {
			if (Inventory_obj.activeInHierarchy == false) {
				Inventory_obj.SetActive (true);
				GameObject.Find (player.helmet_id).GetComponent<Image> ().enabled = true;
				GameObject.Find (player.plate_id).GetComponent<Image> ().enabled = true;
				GameObject.Find (player.gloves_id).GetComponent<Image> ().enabled = true;
				GameObject.Find (player.boots_id).GetComponent<Image> ().enabled = true;
			}
			else {
				GameObject.Find (player.helmet_id).GetComponent<Image> ().enabled = false;
				GameObject.Find (player.plate_id).GetComponent<Image> ().enabled = false;
				GameObject.Find (player.gloves_id).GetComponent<Image> ().enabled = false;
				GameObject.Find (player.boots_id).GetComponent<Image> ().enabled = false;
				Inventory_obj.SetActive (false);
			}
		}

		if ( done_1 == false) {
			player.Bon_Str = player.Bon_Str + GameObject.Find (player.helmet_id).GetComponent<equipment>().bonus_str;
			player.Bon_Dex = player.Bon_Dex + GameObject.Find (player.helmet_id).GetComponent<equipment>().bonus_dex;
			player.Bon_Con = player.Bon_Con + GameObject.Find (player.helmet_id).GetComponent<equipment>().bonus_con;
			player.Bon_Int = player.Bon_Int + GameObject.Find (player.helmet_id).GetComponent<equipment>().bonus_int;
			player.defense = player.defense + GameObject.Find (player.helmet_id).GetComponent<equipment>().defense;
			done_1 = true;
		}
		if ( done_3 == false) {
			player.Bon_Str = player.Bon_Str + GameObject.Find (player.plate_id).GetComponent<equipment>().bonus_str;
			player.Bon_Dex = player.Bon_Dex + GameObject.Find (player.plate_id).GetComponent<equipment>().bonus_dex;
			player.Bon_Con = player.Bon_Con + GameObject.Find (player.plate_id).GetComponent<equipment>().bonus_con;
			player.Bon_Int = player.Bon_Int + GameObject.Find (player.plate_id).GetComponent<equipment>().bonus_int;
			player.defense = player.defense + GameObject.Find (player.plate_id).GetComponent<equipment>().defense;
			done_3 = true;
		}
		if ( done_5 == false) {
			player.Bon_Str = player.Bon_Str + GameObject.Find (player.gloves_id).GetComponent<equipment>().bonus_str;
			player.Bon_Dex = player.Bon_Dex + GameObject.Find (player.gloves_id).GetComponent<equipment>().bonus_dex;
			player.Bon_Con = player.Bon_Con + GameObject.Find (player.gloves_id).GetComponent<equipment>().bonus_con;
			player.Bon_Int = player.Bon_Int + GameObject.Find (player.gloves_id).GetComponent<equipment>().bonus_int;
			player.defense = player.defense + GameObject.Find (player.gloves_id).GetComponent<equipment>().defense;
			done_5 = true;
		}
		if ( done_7 == false) {
			player.Bon_Str = player.Bon_Str + GameObject.Find (player.boots_id).GetComponent<equipment>().bonus_str;
			player.Bon_Dex = player.Bon_Dex + GameObject.Find (player.boots_id).GetComponent<equipment>().bonus_dex;
			player.Bon_Con = player.Bon_Con + GameObject.Find (player.boots_id).GetComponent<equipment>().bonus_con;
			player.Bon_Int = player.Bon_Int + GameObject.Find (player.boots_id).GetComponent<equipment>().bonus_int;
			player.defense = player.defense + GameObject.Find (player.boots_id).GetComponent<equipment>().defense;
			done_7 = true;
		}
	}
}
