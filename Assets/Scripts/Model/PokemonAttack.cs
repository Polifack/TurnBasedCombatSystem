using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class StatChange
{
    public string stat_name;
    public int level_change;

    public override string ToString()
    {
        string modifier = "";
        switch (Math.Abs(level_change))
        {
            case 1:
                modifier = "a bit";
                break;
            case 2:
                modifier = "a lot";
                break;
            case 3:
                modifier = "moitirmo de dios";
                break;
        }

        return stat_name + ((level_change > 0) ? " increased " : " decreased ") + modifier;
    }
}

[CreateAssetMenu(fileName = "NewAttack", menuName = "Pokemon/Attack", order = 2)]
public class PokemonAttack : ScriptableObject
{
    public int id;
    public string attack_name;
    public int mana_cost;
    public float accuracy;
    public GameObject animation;

    //damage attack
    public bool is_damage;
    public float power;
    public float dmg_accuracy;

    //status attack
    public bool is_status;
    public StatusEffect status;
    public float status_accuracy;

    //stats attack
    public bool is_stats;
    public bool is_self;
    public List<StatChange> stats_change;
    public float stats_accuracy;

    //health attack
    public bool is_health;
    public int health_change;
    public float health_accuracy;
}
