using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewPokemon", menuName = "Pokemon/Pokemon", order = 1)]
public class PokemonBase : ScriptableObject
{
    public int id;
    public string poke_name;

    public Sprite front;
    public Sprite back;

    public float atk_per_lvl;
    public float def_per_lvl;
    public float speed_per_lvl;
    public float hp_per_lvl;
    public float mana_per_lvl;


    public float getAttack(int level)
    {
        return atk_per_lvl * level;
    }
    public float getHealth(int level)
    {
        return hp_per_lvl * level;
    }
    public float getMana(int level)
    {
        return mana_per_lvl * level;
    }
    public float getDefense(int level)
    {
        return def_per_lvl * level;
    }
    public float getSpeed(int level)
    {
        return speed_per_lvl * level;
    }
    public Sprite getImgFront()
    {
        return front;
    }
    public Sprite getImgBack()
    {
        return back;
    }
    public string getName()
    {
        return poke_name;
    }


}
