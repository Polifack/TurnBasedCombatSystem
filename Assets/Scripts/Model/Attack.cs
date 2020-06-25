using System;
using System.Collections.Generic;
using UnityEngine;

public enum AttackActionTypes { DAMAGE, STAT_CHANGE, STATUS_EFFECT, HEAL}


[Serializable]
public class StatChange
{
    public string statName;
    public int levelChange;
}


[Serializable]
public class AttackAction
{
    public AttackActionTypes actionType;
    public int actionAccuracy;
    public int actionPower;
    public bool isMainAction;
    public bool isSelf;
    public StatusEffect statusEffect;
    public StatChange statChange;
}


[CreateAssetMenu(fileName = "NewAttack", menuName = "Pokemon/Attack", order = 3)]
public class Attack : ScriptableObject
{
    public string Name;
    public GameObject Animation;
    public int Accuracy;
    public int ManaCost;
    public AttackAction[] actions;

    public List<AbstractAction> getAttackPlayer()
    {
        List<AbstractAction> a = new List<AbstractAction>();
        int i = 0;

        float rng = UnityEngine.Random.Range(0, 100);
        Debug.Log(rng);

        foreach (AttackAction aa in actions)
        {
            if (aa.isMainAction)
                if (rng > aa.actionAccuracy)
                {
                    a.Insert(i, new DisplayTextAction("Attack missed!"));
                    return a;
                }
        }

        foreach (AttackAction aa in actions)
        {
            if (!aa.isMainAction && rng > aa.actionAccuracy) continue;
            switch (aa.actionType)
            {
                case AttackActionTypes.DAMAGE:
                    a.Insert(i, new ChangeEnemyHPAction(CombatSystem.computeDamage(
                           Manager.instance.pokemon_player,
                           Manager.instance.pokemon_enemy,
                           aa.actionPower)));
                    i++;
                    break;
                
                case AttackActionTypes.STAT_CHANGE:
                    if (aa.isSelf)
                        a.Insert(i, new ChangePlayerStatsAction(aa.statChange.statName, aa.statChange.levelChange));
                    else
                        a.Insert(i, new ChangeEnemyStatsAction(aa.statChange.statName, aa.statChange.levelChange));
                    i++;
                    break;
                
                case AttackActionTypes.STATUS_EFFECT:
                    if (aa.isSelf)
                        a.Insert(i, new ChangePlayerAfflictionAction(aa.statusEffect));
                    else
                        a.Insert(i, new ChangeEnemyAfflictionAction(aa.statusEffect));
                    i++;
                    break;
                
                case AttackActionTypes.HEAL:
                    a.Insert(i, new ChangePlayerHPAction(aa.actionPower));
                    i++;
                    break;
            }
        }
        return a;
    }
    public List<AbstractAction> getAttackEnemy()
    {
        List<AbstractAction> a = new List<AbstractAction>();
        int i = 0;
        
        float rng = UnityEngine.Random.Range(0, 100);
        Debug.Log(rng);

        foreach(AttackAction aa in actions)
        {
            if (aa.isMainAction)
                if (rng > aa.actionAccuracy)
                {
                    a.Insert(i, new DisplayTextAction("Attack missed!"));
                    return a;
                }
        }

        foreach (AttackAction aa in actions)
        {
            if (!aa.isMainAction && rng > aa.actionAccuracy) continue;
            switch (aa.actionType)
                {
                    case AttackActionTypes.DAMAGE:
                        a.Insert(i, new ChangePlayerHPAction(CombatSystem.computeDamage(
                               Manager.instance.pokemon_enemy,
                               Manager.instance.pokemon_enemy,
                               aa.actionPower)));
                        i++;
                        break;

                    case AttackActionTypes.STAT_CHANGE:
                        if (aa.isSelf)
                            a.Insert(i, new ChangeEnemyStatsAction(aa.statChange.statName, aa.statChange.levelChange));
                        else
                            a.Insert(i, new ChangePlayerStatsAction(aa.statChange.statName, aa.statChange.levelChange));
                        i++;
                        break;

                    case AttackActionTypes.STATUS_EFFECT:
                        if (aa.isSelf)
                            a.Insert(i, new ChangeEnemyAfflictionAction(aa.statusEffect));
                        else
                            a.Insert(i, new ChangePlayerAfflictionAction(aa.statusEffect));
                        i++;
                        break;

                    case AttackActionTypes.HEAL:
                        a.Insert(i, new ChangeEnemyHPAction(aa.actionPower));
                        i++;
                        break;
                } 
        }
        return a;
    }
}
