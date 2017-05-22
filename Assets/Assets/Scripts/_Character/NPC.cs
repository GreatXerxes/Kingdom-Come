using UnityEngine;
using System.Collections;

public class NPC : Soul 
{
    //public string NPCName { get; set; }
    public string gender { get; set; }
    public int npcRelations { get; set; }
    public int playerRelations { get; set; }
    public int rank { get; set; }

    public NPC(string nameo, int genNum, int npcRelationo, int playerRelationo, int ranko)
    {
        soulName = nameo;
        if (genNum == 1)
        {
            this.gender = "Male";
        }
        else
        {
            this.gender = "Female";
        }
        npcRelations = npcRelationo;
        playerRelations = playerRelationo;
        rank = ranko;
    }

    override
    public string ToString()
    {
        string s = "";
        s = s + "NPC Name: " + soulName + "\n";
        s = s + "Gender: " + gender + "\n";
        s = s + "NPC Relationship: " + npcRelations + "\n";
        s = s + "Player Relationship: " + playerRelations + "\n";
        s = s + "Rank: " + rank + "\n";
        return s;
    }

}
