using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSource : MonoBehaviour
{
    public PokemonBase player_base;
    public PokemonBase enemy_base;

    public int player_level;
    public int enemy_level;

    public Attack[] player_attacks;
    public Attack[] enemy_attacks;

    PokemonInstance player;
    PokemonInstance enemy;

    public void initializeDemoPokemons()
    {
        player = new PokemonInstance(player_base, player_level, player_attacks);
        enemy = new PokemonInstance(enemy_base, enemy_level, enemy_attacks);
    }

    private void Awake()
    {
        initializeDemoPokemons();
    }

    public PokemonInstance getPlayer()
    {
        return player;
    }
    public PokemonInstance getEnemy()
    {
        return enemy;
    }
}
