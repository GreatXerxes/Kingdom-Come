using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : Soul
{
    
    public string username;
    public List<Advisor> listAdvisor = new List<Advisor>();

    //Store Player events
    TestEvents events;
    public List<GameEvent> listEvent = new List<GameEvent>();
    public GameEvent[] eventStore = new GameEvent[5];
    public int eventSlot;

    public Advisor chancellor;
    public Advisor steward;
    public Advisor marshal;
    public Advisor spymaster;
    public Advisor physician;
    public Advisor servant;
    public Advisor witch;
    public Advisor order;

    public int rank;
    public string title;

    public double gold = 0;
    public int personal_levy = 0;

    public NPC liege;

    public Kingdom kingdom;

	// Use this for initialization
	void Start ()
    {
        createLiege();//NOT SURE IF THIS WILL STAY HERE!!

        CreateAdvisor createAdv = new CreateAdvisor();
        listAdvisor = createAdv.createAdvisorToList();

        //Debug.Log("Liege Name: " + liege.NPCName);
        Debug.Log(""+ liege.ToString());


        //gameEventList = new GameEventList(this);

        //Debug.Log("Stored events: " +gameEventList.events.Count);



        //addRandomGameEvent();
    }

    // Update is called once per frame
    //GameObject newevent;
    void Update ()
    {
	    if (GameObject.Find("Events") == null)
        {
            //GameObject createEvent = Instantiate(newevent, transform.position, transform.rotation) as GameObject;
            GameObject newevent = new GameObject();
            newevent.name = "Events";
            newevent.AddComponent<TestEvents>();

            events = getEvents();
            EventTest();
        }
	}

    void addSpecificGameEvent(GameEvent e)
    {
        if(checkSpaceInArray())
        {
            eventStore[eventSlot] = e;
        }
    }

    void addRandomGameEvent()
    {
        if (checkSpaceInArray())
        {
        //eventSlot = 0; // temp
            /*int rand = Random.Range(0, gameEventList.events.Count);
            eventStore[eventSlot] = gameEventList.events[rand];*/

        }
    }

    void EventTest()
    {
        eventStore[0] = events.chancellorEvents[0];
    }


    bool checkSpaceInArray()
    {
        int count = 0;
        for (int i = 0; i < 5; i++)
        {
            if (eventStore[i] == null)
            {
                eventSlot = i;
                //break;
                return true;
            }
            count += 1;
        }
        if(count>5)
        {
            return false;
        }
        return false;


        /*if (eventStore == null || eventStore.Length == 0)
        {
            eventSlot = 0;
        }*/
    }

    public string rankTitle(int num, string gen)
    {
        switch(num)
        {
            case 1:
                if (gen.Equals("Male"))
                {
                    return "Count";
                }
                else
                {
                    return "Countess";
                }
            case 2:
                if (gen.Equals("Male"))
                {
                    return "Duke";
                }
                else
                {
                    return "Duchess";
                }
            case 3:
                if (gen.Equals("Male"))
                {
                    return "King";
                }
                else
                {
                    return "Queen";
                }
            case 4:
                if (gen.Equals("Male"))
                {
                    return "Emperor";
                }
                else
                {
                    return "Empress";
                }
            default:
                return "";  
        }
    }

    public string getLivingEstate(int num)
    {
        switch(num)
        {
            case 1:
                return "Estate";
            case 2:
                return "Manor House";
            case 3:
                return "Castle";
            case 4:
                return "Palace";
            default:
                return "not working right";
        }
    }

    void createLiege()
    {
        int gender = Random.Range(1, 3);
        NameGenerator gen = new NameGenerator();
        string liegeName = gen.createName(gender);
        int npcrelation = Random.Range(0, 101);
        int playerrelation = Random.Range(0, 101);
        liege = new NPC(liegeName, gender, npcrelation, playerrelation, rank + 1);
    }

    TestEvents getEvents()
    {
        return GameObject.Find("Events").GetComponent<TestEvents>();
    }
}
