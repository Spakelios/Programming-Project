using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.WSA;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST } // enumarates states to switch between turns

public class BattleSystem : MonoBehaviour
{

	public GameObject playerPrefab; //player
	public GameObject enemyPrefab; // enemy 

	public Transform playerBattleStation; // player spawn point
	public Transform enemyBattleStation; // enemy spawn point

	Unit playerUnit; // player info
	Unit enemyUnit; // enemy info

	public TextMeshProUGUI dialogueText;

	public BattleHUD playerHUD;
	public BattleHUD enemyHUD;

	private thing thing;

	public BattleState state; // can change state in unity

	void Start()
	{
		state = BattleState.START; // trigger start state 
		StartCoroutine(SetupBattle());
	}

	IEnumerator SetupBattle()
	{
		GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
		playerUnit = playerGO.GetComponent<Unit>(); // spawn player

		GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
		enemyUnit = enemyGO.GetComponent<Unit>(); // spawn enemy

		dialogueText.text = "A  " + enemyUnit.unitName + " attacked! "; // enemy interaction dialogue

		playerHUD.SetHUD(playerUnit);
		enemyHUD.SetHUD(enemyUnit);

		yield return new WaitForSeconds(0f); // wait one secound before player turn

		state = BattleState.PLAYERTURN;
		PlayerTurn();
	}

	IEnumerator PlayerAttack()
	{
		bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

		enemyHUD.SetHP(enemyUnit.currentHP); //
		dialogueText.text = "The attack is successful!";

		yield return new WaitForSeconds(2f); // wait 2 seconds 

		if (isDead) // if enemy is dead 
		{
			state = BattleState.WON; // trigger win state 
			EndBattle();
		}
		else
		{
			state = BattleState.ENEMYTURN; // start enemy turn 
			StartCoroutine(EnemyTurn());
		}
	}

	IEnumerator EnemyTurn()
	{

		dialogueText.text = enemyUnit.unitName + " attacks!"; // enemy attack dialogue trigger

		yield return new WaitForSeconds(1f); // wait one second 

		bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

		playerHUD.SetHP(playerUnit.currentHP);

		yield return new WaitForSeconds(0f); // wait one second 

		if (isDead)
		{
			state = BattleState.LOST; // trigger loss state 
			EndBattle();
		}
		else
		{
			state = BattleState.PLAYERTURN; // trigger player turn
			PlayerTurn();
		}

	}

	void EndBattle()
	{
		if (state == BattleState.WON)
		{
			dialogueText.text = "You won the battle!"; // trigger victory text and reload scene
			thing thing = new thing();
			thing.isLoaded = false;

		}
		else if (state == BattleState.LOST)
		{
			dialogueText.text = "You were defeated."; // trigger end dialogue 
		}
	}

	void PlayerTurn()
	{
		dialogueText.text = "What will you do? ";
	}

	IEnumerator PlayerHeal()
	{
		playerUnit.Heal(5); // increase health by 5 

		playerHUD.SetHP(playerUnit.currentHP); // show in hud
		dialogueText.text = "You Healed!";

		yield return new WaitForSeconds(1f); // wait 2 seconds 

		state = BattleState.ENEMYTURN; // trigger enemy turn 
		StartCoroutine(EnemyTurn());
	}

	public void OnAttackButton()
	{
		if (state != BattleState.PLAYERTURN) // if its the player turn state allow button click to do damage
			return;

		StartCoroutine(PlayerAttack());
	}

	public void OnHealButton()
	{
		if (state != BattleState.PLAYERTURN) // if its the player turn allow button click to heal player
			return;

		StartCoroutine(PlayerHeal());
	}
}