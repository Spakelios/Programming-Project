using UnityEngine;
using UnityEngine.UI;
public class Unit : MonoBehaviour
{

    public string unitName; // character name 
    public int unitLevel; // character level

    public int damage;

    public int maxHP; // max health to be edited in unity
    public int currentHP; // current health to be edited in unity 

    public bool TakeDamage(int dmg)
    {
        currentHP -= dmg;  // if damage is taken remove from hp

        if (currentHP <= 0)
            return true;
        else
            return false;
    }

    public void Heal(int amount) 
    {
        currentHP += amount; // increase health 
        if (currentHP > maxHP) 
            currentHP = maxHP;
    }
}