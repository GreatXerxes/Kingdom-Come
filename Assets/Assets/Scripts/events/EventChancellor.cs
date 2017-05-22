using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameEventChancellor
{
    public List<GameEvent> events = new List<GameEvent>();

    //Events
    GameEventLiegeRelationsFeast liegeFeast = new GameEventLiegeRelationsFeast();
    
    public GameEventChancellor()
    {
        events.Add(liegeFeast);
    }
}

public class GameEventLiegeRelationsFeast : GameEvent
{
    public static GameObject player;
    //public Player player;
    public NPC liege;

    static string eventLieName = "Liege Feast";
    static string eventDescr = "";
    //string eventDescr = "Our Liege, " + player.rankTitle(getLiege().rank, getLiege().gender) + " " + getLiege().NPCName + " has invited you to a feast held in their " + player.getLivingEstate(getLiege().rank) + ".\n How will you respond?";

    static int type = 1;
    static int variant = 1;

    public GameEventLiegeRelationsFeast() : base(eventLieName, eventDescr, type, variant)
    {
        //player = play;
        description = "Our Liege, " + getPlayer().GetComponent<Player>().rankTitle(getLiege().rank, getLiege().gender) + " " + getLiege().soulName + " has invited you to a feast held in their " + getPlayer().GetComponent<Player>().getLivingEstate(getLiege().rank) + ".\n How will you respond?";
        ResponseAddRelation firstResponse = new ResponseAddRelation("Of Course, I will attend", 10);
        responses.Add(firstResponse);
        ResponseAddRelation secondResponse = new ResponseAddRelation("I'm busy on that day!", -15);
        responses.Add(secondResponse);

    }


    static GameObject getPlayer()
    {
        return player = GameObject.Find("Player");
    }

    NPC getLiege()
    {
        return getPlayer().GetComponent<Player>().liege;
    }

}
