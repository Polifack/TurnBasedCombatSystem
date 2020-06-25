using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewStatusEffect", menuName = "Pokemon/StatusEffect", order = 3)]
public class StatusEffect : ScriptableObject
{
    public int id;
    public int duration_turns;
    public string effect_name;
}
