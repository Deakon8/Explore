using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charLvlManagement : MonoBehaviour {

	public static int exp;
	public static int needexp;
	public static int lvl;

	public static int needexp_2 = 800;
	public static int needexp_3 = 1680;
	public static int needexp_4 = 3530;
	public static int needexp_5 = 7410;

	void Update () {
		exp = PlayerPrefs.GetInt("Exp");
		if (exp < needexp_2) {
			lvl = 1;
			needexp = needexp_2;
		}
		if (exp >= needexp_2) {
			lvl = 2;
			needexp = needexp_3;
		}
		if (exp >= needexp_3) {
			lvl = 3;
			needexp = needexp_4;
		}
		if (exp >= needexp_4) {
			lvl = 4;
			needexp = needexp_5;
		}
		if (exp >= needexp_5) {
			lvl = 5;
		}
	}
}
