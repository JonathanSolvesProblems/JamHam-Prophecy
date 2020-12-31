using UnityEngine;

public class HealthSystem
{
    private int health;
    private int healthMax;
    public HealthSystem(int healthMax)
    {
        this.healthMax = healthMax;
        health = healthMax;

    }

    public int GetHealth()
    {
        return health;
    }

    public void Damage(int hit)
    {
        this.health -= hit;
        if (health < 0) health = 0;
    }

    public void Heal(int heal)
    {
        this.health += heal;
        if (health > healthMax) health = healthMax;
    }
}
