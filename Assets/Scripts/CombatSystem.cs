﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    public static float computeDamage(PokemonInstance attacker, PokemonInstance deffender, float attackPower)
    {
        float attackerDamage = attacker.getAttack();
        float deffenderDeffense = deffender.getDeffense();

        float attackerLevel = attacker.getLevel();

        return -1 * (((((attackerLevel * 2 / 5) + 2) * attackPower * attackerDamage / deffenderDeffense) / 50) + 2);
    }
}
