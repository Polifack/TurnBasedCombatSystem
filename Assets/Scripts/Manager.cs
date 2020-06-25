using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public UI_TextFrame textFrame;
    public UI_CombatMenu combatMenu;
    public UI_Stats playerStats;
    public UI_Stats enemyStats;
    public UI_CombatFrame combatFrame;
    public SFXManager SFXmanager;

    public GameObject player;
    public GameObject enemy;

    DataSource ds;

    public PokemonInstance pokemon_player;
    public PokemonInstance pokemon_enemy;

    Queue<AbstractAction> actionQ = new Queue<AbstractAction>();
    AbstractAction currentAction;

    public static Manager instance;
    private void getPokemonData()
    {
        pokemon_player = ds.getPlayer();
        pokemon_enemy = ds.getEnemy();
    }
    public void enqueueAction(AbstractAction a)
    {
        actionQ.Enqueue(a);
    }
    public void enqueueActions(AbstractAction[] la)
    {
        foreach (AbstractAction a in la)
        {
            actionQ.Enqueue(a);
        }
    }
    
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        ds = GetComponent<DataSource>();
        getPokemonData();
        
        new SetEnemySpriteAction().Execute();
        new SetPlayerSpriteAction().Execute();

        actionQ.Enqueue(new HideButtonsFrameAction());
        actionQ.Enqueue(new DisplayTextAction("Welcome to the pokemon battle simulator"));
        actionQ.Enqueue(new DisplayTextAction("Now i will display you the buttons"));
        actionQ.Enqueue(new ShowButtonsFrameAction());

        currentAction = actionQ.Dequeue();
        currentAction.Execute();
    }

    void Update()
    {
        if (currentAction!=null && currentAction.IsDone())
        {
            currentAction = actionQ.Dequeue();
            currentAction.Execute();
        }
    }
}
