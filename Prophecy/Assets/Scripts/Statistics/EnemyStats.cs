using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStatistics
{
    public override void Die()
    {
        base.Die();

        // Add ragdoll effect one day.

        Destroy(gameObject);
    }
}
