using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_StatusEffectIndicator : MonoBehaviour
{
    public TextMeshProUGUI statusEffectName;

    public void setStatusEffect(StatusEffect s)
    {
        statusEffectName.text = s.effect_name;
    }
}
