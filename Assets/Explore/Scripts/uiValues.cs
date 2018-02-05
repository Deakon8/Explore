using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiValues : MonoBehaviour {

	public Text value_gold;
	public Text value_silver;
	public Text value_cooper;
	public Text value_skillpoints;
	public Text value_exp;
	public Text value_lvl;
	public Text value_hp;
	public Text value_mp;
	public Text value_stat_str;
	public Text value_stat_dex;
	public Text value_stat_con;
	public Text value_stat_int;

	public GameObject healthBar;
	public GameObject manaBar;
	public GameObject xpBar;

	void Update () {
		value_gold.text = "" + player.coins;
		value_silver.text = "" + player.silver;
		value_cooper.text = "" + player.cooper;
		value_skillpoints.text = "" + player.skillpoints;
		value_exp.text = charLvlManagement.exp + " / " + charLvlManagement.needexp;
		value_lvl.text = charLvlManagement.lvl + "";
		value_hp.text = player.hp + " / " + player.max_hp;
		value_mp.text = player.mp + " / " + player.max_mp;
		value_stat_str.text = player.Def_Str + " (+" + player.Bon_Str + ")";
		value_stat_dex.text = player.Def_Dex + " (+" + player.Bon_Dex + ")";
		value_stat_con.text = player.Def_Con + " (+" + player.Bon_Con + ")";
		value_stat_int.text = player.Def_Int + " (+" + player.Bon_Int + ")";

		float hp = (float)player.hp; float max_hp = (float)player.max_hp;
		float mp = (float)player.mp; float max_mp = (float)player.max_mp;
		float xp = (float)charLvlManagement.exp; float need_xp = (float)charLvlManagement.needexp;
		float calc_health = hp / max_hp;
		float calc_mana = mp / max_mp;
		float calc_xp = xp / need_xp;
		SetHealthBar (calc_health);
		SetManaBar (calc_mana);
		SetXpBar (calc_xp);
	}
	public void SetHealthBar(float myHealth){
		healthBar.transform.localScale = new Vector3(Mathf.Clamp(myHealth,0f ,1f), healthBar.transform.localScale.y, healthBar.transform.localScale.z);
	}
	public void SetManaBar(float myMana){
		manaBar.transform.localScale = new Vector3(Mathf.Clamp(myMana,0f ,1f), manaBar.transform.localScale.y, manaBar.transform.localScale.z);
	}
	public void SetXpBar(float myXp){
		xpBar.transform.localScale = new Vector3(Mathf.Clamp(myXp,0f ,1f), xpBar.transform.localScale.y, xpBar.transform.localScale.z);
	}
}
