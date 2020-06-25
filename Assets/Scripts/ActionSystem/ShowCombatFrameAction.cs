using System;

public class ShowCombatFrameAction : AbstractAction
{
    public override void Execute()
    {
        string[] attacksNames = new string[4];
        Attack[] pokemonAttacks = Manager.instance.pokemon_player.getAttacks();
        int i = 0;
        foreach(Attack a in pokemonAttacks)
        {
            attacksNames[i] = a.Name;
            i++;
        }

        Manager.instance.combatFrame.setButtons(
             attacksNames,
             new Action[4] {
                () => executeAttack(pokemonAttacks[0]),
                () => executeAttack(pokemonAttacks[1]),
                () => executeAttack(pokemonAttacks[2]),
                () => executeAttack(pokemonAttacks[3])});
    }

    void executeAttack(Attack a)
    {
        Manager.instance.enqueueAction(new ExecuteAttackAction(a, true));
        SetDone();
    }

}
