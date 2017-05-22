using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameEvent
{
    public string eventName { get; set; }
    public string description { get; set; }
    public List<Response> responses = new List<Response>();

    int type { get; set; }
    int variant { get; set; }

    public GameEvent(string name, string des, List<Response> responso, int ty, int var)
    {
        eventName = name;
        description = des;
        responses = responso;
        type = ty;
        variant = var;
    }


    public GameEvent(string name, string des, int ty, int var)
    {
        eventName = name;
        description = des;
        type = ty;
        variant = var;
    }
}


public class GameEventList
{
    public List<GameEvent> events;

    public GameEventList(Player player)
    {

        /*events = new List<GameEvent>();
        Debug.Log("GAMEEVENT LIST CON is running!!!!");
        GameEventLiegeRelationsFeast liegeFeast = new GameEventLiegeRelationsFeast(player);
        events.Add(liegeFeast);*/
    }
}
