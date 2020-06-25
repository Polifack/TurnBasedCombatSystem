using System;
using UnityEngine;


[Serializable]
public class PokemonInstance
{
    int id;
    PokemonBase source;
    int level;

    float base_attack;
    float base_speed;
    float base_defense;
    float base_hp;
    float base_mana;

    float current_hp;
    float current_mana;

    StatusEffect affliction = null;

    PokemonAttack[] attacks = new PokemonAttack[4];
    public PokemonInstance(PokemonBase _source, int _level, int _id, PokemonAttack[] _attacks)
    {
        id = _id;
        level = _level;
        source = _source;

        base_attack = source.getAttack(level);
        base_speed = source.getSpeed(level);
        base_defense = source.getDefense(level);
        base_hp = source.getHealth(level);
        base_mana = source.getMana(level);

        current_hp = base_hp;
        current_mana = base_mana;

        attacks = _attacks;
    }
    public PokemonInstance(PokemonBase _source, int _level, PokemonAttack[] _attacks)
    {
        id = UnityEngine.Random.Range(0, 999);
        level = _level;
        source = _source;

        base_attack = source.getAttack(level);
        base_speed = source.getSpeed(level);
        base_defense = source.getDefense(level);
        base_hp = source.getHealth(level);
        base_mana = source.getMana(level);

        current_hp = base_hp;
        current_mana = base_mana;

        attacks = _attacks;
    }
    public PokemonBase getSource()
    {
        return source;
    }

    public float getHealthPercentage()
    {
        return current_hp / base_hp;
    }
    public float getManaPercentage()
    {
        return current_mana / base_mana;
    }
    public PokemonAttack[] getAttacks()
    {
        return attacks;
    }

    public void changeStat(string stat, float nLevels)
    {
        switch (stat)
        {
            case "atk": base_attack += nLevels * source.atk_per_lvl; break;
            case "def": base_defense += nLevels * source.def_per_lvl; break;
            case "speed": base_speed += nLevels * source.speed_per_lvl; break;
        }
    }
    public bool changeMana(float ammount)
    {
        if (current_mana-ammount <= 0) return true;
        current_mana = current_mana + ammount;
        return false;
    }
    public bool changeHealth(float ammount)
    {
        current_hp = Mathf.Clamp(current_hp + ammount, 0, base_hp);
        if (current_hp == 0) return true;
        return false;
    }

    public float getAttack() { return base_attack; }
    public float getDeffense() { return base_defense; }
    public float getSpeed() { return base_speed; }

    public int getLevel() { return level; }

    public StatusEffect getAffliction() { return affliction; }
    public void setAffliction(StatusEffect s) { affliction = s; }

}
