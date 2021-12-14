using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{

 public TextMeshProUGUI nameText; // change the name in text box
 public TextMeshProUGUI levelText; // change level in text box
 public Slider hpSlider; // configure health

 public void SetHUD(Unit unit)
  // public units which store and allow me to change characters stats and health within unity
 // and easily call them in other scripts. 
 {
  nameText.text = unit.unitName;
  levelText.text = "Lvl " + unit.unitLevel;
  hpSlider.maxValue = unit.maxHP;
  hpSlider.value = unit.currentHP;
 }

 public void SetHP(int hp)
 {
  hpSlider.value = hp; 
 }

}