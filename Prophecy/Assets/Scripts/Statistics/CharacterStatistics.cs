using UnityEngine;

public class CharacterStatistics : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth {get; private set;} // can only set this value within this class, but others can get this value.
    public Stat damage;
    public Stat armor;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue); // damage never goes below 0 this way.

        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        // character dies **cry**
        Debug.Log(transform.name + " died.");
    }
}
