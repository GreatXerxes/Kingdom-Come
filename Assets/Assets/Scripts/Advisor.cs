using UnityEngine;
using System.Collections;

public class Advisor
{
    public string advisorName;

    public string gender;

    public int diplomacy;
    public int stewardship;
    public int martial;
    public int intrigue;
    public int learning;
    public int arcane;
    //public int diplomacy;

    public Advisor(string advisorName, int gender, int diplomacy, int stewardship, int martial, int intrigue, int learning, int arcane)
    {
        this.advisorName = advisorName;
        if (gender == 1)
        {
            this.gender = "Male";
        }
        else
        {
            this.gender = "Female";
        }

        this.diplomacy = diplomacy;
        this.stewardship = stewardship;
        this.martial = martial;
        this.intrigue = intrigue;
        this.learning = learning;
        this.arcane = arcane;
}


    override
    public string ToString()
    {
        string s = "";
        s = s + "Advisor Name: " + advisorName + "\n";
        s = s + "Gender: " + gender + "\n";
        s = s + "Diplomacy Skill: " + diplomacy + "\n";
        s = s + "Stewardship Skill: " + stewardship + "\n";
        s = s + "Martial Skill: " + martial + "\n";
        s = s + "Intrigue Skill: " + intrigue + "\n";
        s = s + "Learning Skill: " + learning + "\n";
        s = s + "Arcane Skill: " + arcane + "\n";

        return s;
    } 
}
