using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateAdvisor
{


    //Not sure if this is needed here
    public List<Advisor> listAdvisor = new List<Advisor>();

    public List<Advisor> rareAdvisorList = new List<Advisor>();

    // Use this for initialization
    /*void Start ()
    {
        addRareAdvisors();
        createAdvisor();
        for (int x = 0; x < listAdvisor.Count; x++)
        {
            Debug.Log(listAdvisor[x].ToString());
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}*/

    public List<Advisor> createAdvisorToList()
    {
        List<Advisor> playerListAdvisor = new List<Advisor>();
        addRareAdvisors();
        for (int i = 0; i < 10; i++)
        {
            int rareChance = Random.Range(0, 101);
            if (rareChance >= 90)
            {
                //Add rare Advisor - TODO Add a list of rare advisors
                int chance = Random.Range(0, rareAdvisorList.Count);
                Advisor rare = rareAdvisorList[chance];
                rareAdvisorList.Remove(rare);
                playerListAdvisor.Add(rare);
            }
            else
            {
                int gender = Random.Range(1, 3);
                NameGenerator gen = new NameGenerator();
                string advisorName = gen.createName(gender);
                int diplomacy = setAttributes();
                int stewardship = setAttributes();
                int martial = setAttributes();
                int intrigue = setAttributes();
                int learning = setAttributes();
                int arcane = setAttributes();

                Advisor advisor = new Advisor(advisorName, gender, diplomacy, stewardship, martial, intrigue, learning, arcane);
                playerListAdvisor.Add(advisor);
            }
        }
        return playerListAdvisor;
    }

void createAdvisor()
    {
        for (int i = 0; i<10; i++ )
        {
            int rareChance = Random.Range(0, 101);
            Debug.Log("Rare Chance: " + rareChance);
            if (rareChance >= 90)
            {
                //Add rare Advisor - TODO Add a list of rare advisors
                Debug.Log("Rare Advisor");
                Debug.Log(rareAdvisorList.Count);
                int chance = Random.Range(0, rareAdvisorList.Count);
                Debug.Log(chance);
                Advisor rare = rareAdvisorList[chance];
                rareAdvisorList.Remove(rare);
                listAdvisor.Add(rare);
            }
            else
            {
                int gender = Random.Range(1, 3);
                NameGenerator gen = new NameGenerator();
                string advisorName = gen.createName(gender);
                int diplomacy = setAttributes();
                int stewardship = setAttributes();
                int martial = setAttributes();
                int intrigue = setAttributes();
                int learning = setAttributes();
                int arcane = setAttributes();

                Advisor advisor = new Advisor(advisorName, gender, diplomacy, stewardship, martial, intrigue, learning, arcane);
                listAdvisor.Add(advisor);
            }
        }
        
    }

    int setAttributes()
    {
        int weightedChance = Random.Range(1, 101);
        if (weightedChance < 60)//0-10
        {
            return Random.Range(0, 10 +1);
        }
        else if (weightedChance >=60 && weightedChance <90)//11-13
        {
            return Random.Range(11, 13 + 1);
        }
        else if (weightedChance >=90 && weightedChance < 97)//14-16
        {
            return Random.Range(14, 16 + 1);
        }
        else//17-20
        {
            return Random.Range(17, 20 + 1);
        }
    }

    void addRareAdvisors()
    {
        rareAdvisorList.Add(new Advisor("Zuo Ci", 1, 15, 5, 8, 12, 17, 19));
        rareAdvisorList.Add(new Advisor("Lu Bu", 1, 1, 5, 20, 1, 8, 0));
        rareAdvisorList.Add(new Advisor("Zhuge Liang", 1, 15, 17, 16, 12, 16, 3));
        rareAdvisorList.Add(new Advisor("Sima Yi", 1, 12, 10, 15, 18, 17, 1));



    }
}
