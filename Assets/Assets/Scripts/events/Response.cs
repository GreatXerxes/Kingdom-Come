using UnityEngine;
using System.Collections;
using System;

public abstract class Response
{
    public string text { get; set; }


    public Response(string inText)
    {
        text = inText;
        setToolTip();//Not sure this will work so testing is needed!!!!!
    }

    public abstract void runResponse();

    public abstract string setToolTip();
}

public class ResponseAddRelation : Response
{
    public static GameObject player;
    private int num;
    public ResponseAddRelation(string text, int numo) : base(text)
    {
        num = numo;
    }

    void addToRelations()
    {
        getLiege().npcRelations += num;
    }

    static GameObject getPlayer()
    {
        return player = GameObject.Find("Player");
    }

    static NPC getLiege()
    {
        return getPlayer().GetComponent<Player>().liege;
    }

    public override void runResponse()
    {
        addToRelations();
    }

    public override string setToolTip()
    {
        return "This will change relations by " + num + " with your liege";
    }
}

