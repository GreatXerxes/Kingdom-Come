using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InGameMenu : MonoBehaviour
{
    public Texture2D flag;

    List<Advisor> advisorList = new List<Advisor>();

    /**
    *   Screen size
    **/
    private bool hasUpdate = false;
    private static int width;
    private static int height;

    //Windows Tooggle
    public static bool isActive = false;

    public static bool listActive = false;
    private static bool needsRefresh = false;//Attempt to prevent the GUI from refreshing all the time
    public int selectedList = 0;

    public static bool descriptActive = false;
    public int selectedType = 0;

    public GameObject player;

    public GameObject eventWin;

    public GUIEvent prefab;

    // Use this for initialization
    void Start ()
    {
        //flag = getFlagIcon();

	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (hasUpdate == false)
        {
            width = Screen.width;
            height = Screen.height;
            hasUpdate = true;
        }
	}

    public Rect windowRect = new Rect(0, 100, 800, 800);

    void OnGUI()
    {

        if (GUI.Button(new Rect(0, 0, 100, 100), flag))
        {
            if (isActive)
            {
                isActive = false;
            }
            else
            {
                isActive = true;
            }
        }
        if (isActive)
        {
            windowRect = GUI.Window(0, windowRect, DoMyWindow, "My Window");//Draws UI Window
        }

        Rect listWindow = new Rect(350, 150, 350, 460);
        if (listActive)
        {
            listWindow = GUI.Window(1, listWindow, ListAdvisors, "List");//Draws UI Window
        }

        Rect descriptWindow = new Rect(350, 150, 250, 250);
        if (descriptActive)
        {
            descriptWindow = GUI.Window(2, descriptWindow, descriptionWindow, "Description");
        }
        
    }

    void DoMyWindow(int windowID)//Different tabs on the UI - god knows why int windowID is there
    {
        //Left Hand Side top
        GUI.Box(new Rect(2, 20, 394, 248), "");

        //Left Hand Side bottom
        GUI.Box(new Rect(2, 270, 394, 248), "");

        GUI.BeginGroup(new Rect(2, 270, 394, 248));
        int Yset = 0;
        for (int z = 1; z < 2; z++)
        { 
            if (GUI.Button(new Rect(0, 0 + Yset, 100, 40), "Temp"))
            {
                if (getPlayer().GetComponent<Player>().eventStore[z] != null)
                {
                    //Vector3 pos = new Vector3(0, 0, 0);
                    //GUIEvent gEvent = Instantiate(prefab, pos, Quaternion.identity) as GUIEvent;
                    eventWin = new GameObject("Events Window");
                    eventWin.AddComponent<GUIEvent>();
                    eventWin.GetComponent<GUIEvent>().setEvent(getPlayer().GetComponent<Player>().eventStore[z]);
                }
            }
            Yset += 40;
        }
        GUI.EndGroup();

        //Right Hand Side
        GUI.Box(new Rect(398, 20, 394, 500), "");

        //Diplomacy buttons
        if (GUI.Button(new Rect(400, 40, 40, 40), "Temp"))
        {
            if (descriptActive)
            {
                descriptActive = false;
                selectedType = 0;
            }
            else
            {
                descriptActive = true;
                selectedType = 1;
            }
        }
        if (GUI.Button(new Rect(440, 40, 200, 40), getName(1)))
        {
            selectedList = 1;
            listActive = true;
            needsRefresh = true;
        }
        if (GUI.Button(new Rect(640, 40, 40, 40), "X"))
        {
            if (getPlayer().GetComponent<Player>().chancellor != null)
            {
                advisorList.Add(getPlayer().GetComponent<Player>().chancellor);
                getPlayer().GetComponent<Player>().listAdvisor = advisorList;
                getPlayer().GetComponent<Player>().chancellor = null;
            }
        }

        //Stewardship
        if (GUI.Button(new Rect(400, 80, 40, 40), "Temp"))
        {
            if (descriptActive)
            {
                descriptActive = false;
                selectedType = 0;
            }
            else
            {
                descriptActive = true;
                selectedType = 2;
            }
        }
        if (GUI.Button(new Rect(440, 80, 200, 40), getName(2)))
        {
            selectedList = 2;
            listActive = true;
            needsRefresh = true;
        }
        if (GUI.Button(new Rect(640, 80, 40, 40), "X"))
        {
            if (getPlayer().GetComponent<Player>().steward != null)
            {
                advisorList.Add(getPlayer().GetComponent<Player>().steward);
                getPlayer().GetComponent<Player>().listAdvisor = advisorList;
                getPlayer().GetComponent<Player>().steward = null;
            }
        }
        if (getPlayer().GetComponent<Player>().rank >1)
        {
            //Marshal
            if (GUI.Button(new Rect(400, 120, 40, 40), "Temp"))
            {
                if (descriptActive)
                {
                    descriptActive = false;
                    selectedType = 0;
                }
                else
                {
                    descriptActive = true;
                    selectedType = 3;
                }
            }
            if (GUI.Button(new Rect(440, 120, 200, 40), getName(3)))
            {
                selectedList = 3;
                listActive = true;
                needsRefresh = true;
            }
            if (GUI.Button(new Rect(640, 120, 40, 40), "X"))
            {
                if (getPlayer().GetComponent<Player>().marshal != null)
                {
                    advisorList.Add(getPlayer().GetComponent<Player>().marshal);
                    getPlayer().GetComponent<Player>().listAdvisor = advisorList;
                    getPlayer().GetComponent<Player>().marshal = null;
                }
            }
            //Intrigue
            if (GUI.Button(new Rect(400, 160, 40, 40), "Temp"))
            {
                if (descriptActive)
                {
                    descriptActive = false;
                    selectedType = 0;
                }
                else
                {
                    descriptActive = true;
                    selectedType = 4;
                }
            }
            if (GUI.Button(new Rect(440, 160, 200, 40), getName(4)))
            {
                selectedList = 4;
                listActive = true;
                needsRefresh = true;
            }
            if (GUI.Button(new Rect(640, 160, 40, 40), "X"))
            {
                if (getPlayer().GetComponent<Player>().spymaster != null)
                {
                    advisorList.Add(getPlayer().GetComponent<Player>().spymaster);
                    getPlayer().GetComponent<Player>().listAdvisor = advisorList;
                    getPlayer().GetComponent<Player>().spymaster = null;
                }
            }
            if (getPlayer().GetComponent<Player>().rank > 2)
            {
                //Learning
                if (GUI.Button(new Rect(400, 200, 40, 40), "Temp"))
                {
                    if (descriptActive)
                    {
                        descriptActive = false;
                        selectedType = 0;
                    }
                    else
                    {
                        descriptActive = true;
                        selectedType = 5;
                    }
                }
                if (GUI.Button(new Rect(440, 200, 200, 40), getName(5)))
                {
                    selectedList = 5;
                    listActive = true;
                    needsRefresh = true;
                }
                if (GUI.Button(new Rect(640, 200, 40, 40), "X"))
                {
                    if (getPlayer().GetComponent<Player>().physician != null)
                    {
                        advisorList.Add(getPlayer().GetComponent<Player>().physician);
                        getPlayer().GetComponent<Player>().listAdvisor = advisorList;
                        getPlayer().GetComponent<Player>().physician = null;
                    }
                }

                //Servant
                if (GUI.Button(new Rect(400, 240, 40, 40), "Temp"))
                {
                    if (descriptActive)
                    {
                        descriptActive = false;
                        selectedType = 0;
                    }
                    else
                    {
                        descriptActive = true;
                        selectedType = 6;
                    }
                }
                if (GUI.Button(new Rect(440, 240, 200, 40), getName(6)))
                {
                    selectedList = 6;
                    listActive = true;
                    needsRefresh = true;
                }
                if (GUI.Button(new Rect(640, 240, 40, 40), "X"))
                {
                    if (getPlayer().GetComponent<Player>().servant != null)
                    {
                        advisorList.Add(getPlayer().GetComponent<Player>().servant);
                        getPlayer().GetComponent<Player>().listAdvisor = advisorList;
                        getPlayer().GetComponent<Player>().servant = null;
                    }
                }

                if (getPlayer().GetComponent<Player>().rank > 3)
                {
                    //Witch
                    if (GUI.Button(new Rect(400, 280, 40, 40), "Temp"))
                    {
                        if (descriptActive)
                        {
                            descriptActive = false;
                            selectedType = 0;
                        }
                        else
                        {
                            descriptActive = true;
                            selectedType = 7;
                        }
                    }
                    if (GUI.Button(new Rect(440, 280, 200, 40), getName(7)))
                    {
                        selectedList = 7;
                        listActive = true;
                        needsRefresh = true;
                    }
                    if (GUI.Button(new Rect(640, 280, 40, 40), "X"))
                    {
                        if (getPlayer().GetComponent<Player>().witch != null)
                        {
                            advisorList.Add(getPlayer().GetComponent<Player>().witch);
                            getPlayer().GetComponent<Player>().listAdvisor = advisorList;
                            getPlayer().GetComponent<Player>().witch = null;
                        }
                    }
                    //Order
                    if (GUI.Button(new Rect(400, 320, 40, 40), "Temp"))
                    {
                        if (descriptActive)
                        {
                            descriptActive = false;
                            selectedType = 0;
                        }
                        else
                        {
                            descriptActive = true;
                            selectedType = 8;
                        }
                    }
                    if (GUI.Button(new Rect(440, 320, 200, 40), getName(8)))
                    {
                        selectedList = 8;
                        listActive = true;
                        needsRefresh = true;
                    }
                    if (GUI.Button(new Rect(640, 320, 40, 40), "X"))
                    {
                        if (getPlayer().GetComponent<Player>().order != null)
                        {
                            advisorList.Add(getPlayer().GetComponent<Player>().order);
                            getPlayer().GetComponent<Player>().listAdvisor = advisorList;
                            getPlayer().GetComponent<Player>().order = null;
                        }
                    }
                }
            }
        }
    }

    void ListAdvisors(int windowID)//Different tabs on the UI - god knows why int windowID is there
    {
        
        if (needsRefresh)
        {
            advisorList = getPlayer().GetComponent<Player>().listAdvisor;

            switch (selectedList)
            {
                case 1:
                    advisorList.Sort(new SortByDip());
                    break;
                case 2:
                    advisorList.Sort(new SortBySte());
                    break;
                case 3:
                    advisorList.Sort(new SortByMar());
                    break;
                case 4:
                    advisorList.Sort(new SortByIntr());
                    break;
                case 5:
                    advisorList.Sort(new SortByLear());
                    break;
                case 6:
                    advisorList.Sort(new SortByLear());//Need to check gender
                    break;
                case 7:
                    advisorList.Sort(new SortByAra());
                    break;
                case 8:
                    advisorList.Sort(new SortByMar());
                    break;
                default:
                    break;

            }

            advisorList.Reverse();
            for (int x = 0; x < advisorList.Count; x++)
            {
                Debug.Log(advisorList[x].ToString());
            }
            //createTable(advisorList);
            
            needsRefresh = false;
        }

        //Color oldColor = GUI.color; // 1. save current color

        GUI.Label(new Rect(3, 19, 100, 40), "Name");
        int titleXOffset = 0;
        for (int j = 1; j <= 6; j++)
        {
            if (getRoleAttributes() == j)
            {
                //GUI.color = Color.green; // 2. apply color
                //Debug.Log("I ran");
                DrawBox(new Rect(104 + titleXOffset, 19, 40, 40), Color.red);
            }
            else
            {
                GUI.Box(new Rect(104 + titleXOffset, 19, 40, 40), "");
            }
            
            //GUI.color = oldColor;// 3. reset to old color
            GUI.Label(new Rect(115 + titleXOffset, 19, 40, 40), getIcon(j));
            titleXOffset += 40;
        }
        //GUI.Label(new Rect(3, 19, 100, 40), "Name");

        int yOffset = 0;
        for (int x = 0; x < advisorList.Count; x++)
        {
            
            string adName = advisorList[x].advisorName;
            if (GUI.Button(new Rect(3, 59 + yOffset, 100, 40), advisorList[x].advisorName))
            {
                if (getAdvisor() != null)
                {
                    advisorList.Add(getAdvisor());
                    getPlayer().GetComponent<Player>().listAdvisor = advisorList;
                }
                setAdvisor(advisorList[x]);
                listActive = false;
                advisorList.Remove(advisorList[x]);
                getPlayer().GetComponent<Player>().listAdvisor = advisorList;
                //getPlayer().GetComponent<Player>().listAdvisor.Remove(advisorList[x]);
            }

            int xOffset = 0;
            for (int t = 1; t <= 6; t++)
            {
                GUI.Box(new Rect(104 + xOffset, 59 + yOffset, 40, 40), "");
                GUI.Label(new Rect(116 + xOffset, 70 + yOffset, 40, 40),""+ getAdvisorAttubtue(advisorList[x], t));
                xOffset += 40;
            }

            yOffset += 40;
        }




    }

    void descriptionWindow(int windowId)
    {
        GUI.Box(new Rect(3, 19, 244, 40), "");//Title
        GUI.Box(new Rect(3, 60, 244, 102), "");//Description
        GUI.Label(new Rect(3, 19, 244, 40), getTitle(selectedType));
        
        GUI.Label(new Rect(3, 60, 244, 102), getDescription(selectedType));

        if (GUI.Button(new Rect(230, 0, 15, 15), "X"))
        {
            descriptActive = false;
            selectedType = 0;
        }
    }

    //UNUSED
    void createTable(List<Advisor> advisorList)
    {
        //Color oldColor = GUI.color; // 1. save current color
        int countNum = advisorList.Count + 1;
        for (int i = 0; i < countNum; i++)
        {
            if (i == 0)
            {
                //GUI.Box(new Rect(3, 19, 100, 40), "");
                //GUI.Label(new Rect(3, 19, 100, 40), "Name");
                GUI.Box(new Rect(350, 369, 100, 40), "");
                GUI.Label(new Rect(350, 369, 100, 40), "Name");
                /*for (int x = 1; i < 7; x++)
                {

                    /* if (selectedList == x)
                     {
                         GUI.color = Color.green; // 2. apply color
                     }
                    //GUI.Box(new Rect(104 + (41 * (x - 1)), 19, 40, 40), getIcon(x));
                    //GUI.color = oldColor;// 3. reset to old color
                }*/
            }
            else
            {
                /*UI.Box(new Rect(3, 19+ (41 * i), 100, 40), advisorList[i - 1].advisorName);
                for (int x = 1; i < 7; x++)
                {

                    if (selectedList == x)
                    {
                        GUI.color = Color.green; // 2. apply color
                    }
                    GUI.Box(new Rect(104 + (41 * (x - 1)), 19 + (41 * i), 40, 40), ("" + getAdvisorAttubtue(advisorList[i - 1], i)));
                    GUI.color = oldColor;// 3. reset to old color
                }*/
            }
        }
    }

    string getName(int role)
    {
        switch(role)
        {
            case 1:
                if (getPlayer().GetComponent<Player>().chancellor != null)
                {
                    return getPlayer().GetComponent<Player>().chancellor.advisorName;
                }
                else
                {
                    return "--------------------";
                }
            case 2:
                if (getPlayer().GetComponent<Player>().steward != null)
                {
                    return getPlayer().GetComponent<Player>().steward.advisorName;
                }
                else
                {
                    return "--------------------";
                }
            case 3:
                if (getPlayer().GetComponent<Player>().marshal != null)
                {
                    return getPlayer().GetComponent<Player>().marshal.advisorName;
                }
                else
                {
                    return "--------------------";
                }
            case 4:
                if (getPlayer().GetComponent<Player>().spymaster != null)
                {
                    return getPlayer().GetComponent<Player>().spymaster.advisorName;
                }
                else
                {
                    return "--------------------";
                }
            case 5:
                if (getPlayer().GetComponent<Player>().physician != null)
                {
                    return getPlayer().GetComponent<Player>().physician.advisorName;
                }
                else
                {
                    return "--------------------";
                }
            case 6:
                if (getPlayer().GetComponent<Player>().servant != null)
                {
                    return getPlayer().GetComponent<Player>().servant.advisorName;
                }
                else
                {
                    return "--------------------";
                }
            case 7:
                if (getPlayer().GetComponent<Player>().witch != null)
                {
                    return getPlayer().GetComponent<Player>().witch.advisorName;
                }
                else
                {
                    return "--------------------";
                }
            case 8:
                if (getPlayer().GetComponent<Player>().order != null)
                {
                    return getPlayer().GetComponent<Player>().order.advisorName;
                }
                else
                {
                    return "--------------------";
                }
            default:
                return "Number out of bounds";

        }
    }

    GameObject getPlayer()
    {
        return player = GameObject.Find("Player");
    }

    string getTitle(int num)
    {
        switch (num)
        {
            case 1: return "Chancellor";
            case 2: return "Steward";
            case 3: return "Marshal";
            case 4: return "Spymaster";
            case 5: return "Court Physician";
            case 6: return "Gentleman of the Bedchamber/Lady-in-waiting";
            case 7: return "Court Mage";
            case 8: return "Noble Order";
            default: return "";
        }
    }

    string getDescription(int num)
    {
        switch(num)
        {
            case 1:
                return "A chancellor is a secretary to a noble or royal person. \nIn charge relations between both the liege's court and the foreign courts.";
            case 2:
                return "The steward took care of the castle estate and household administration including the events in the great hall.\nOversees the construction of new buildings within the lieges realm.";
            case 3:
                return "The Marshal is the officer in charge of a household's horses, carts, wagons, containers and the transporting of goods.\n They also helped to keep their liege's levy trained and in shape \n Theu also help reduce the unrest in the realm.";
            case 4:
                return "A spymaster is the leader of a spy ring, run by a secret service.\nThey aim to discover plots in the realm as well as create their own.";
            case 5:
                return "A Court Physician is a trusted member of the royal court and is in charge of the medicines and remedies of a kingdom. ";
            case 6:
                return "They're duties are waiting on the liege when they ate in private, helping them to dress, guarding the bedchamber and water closet, and providing companionship";
            case 7:
                return "A Court Mage is a advisor on all things mystical and magical.";
            case 8:
                return "The leader of a group of elite warriors, said to be the right-hand of the liege.\n  In charge of special, dangerous mission's in the name of the liege.";
            default:
                return "";
        }
    }

    string getIcon(int num)
    {
        switch(num)
        {
            case 1:
                return "D";
            case 2:
                return "S";
            case 3:
                return "M";
            case 4:
                return "I";
            case 5:
                return "L";
            case 6:
                return "A";
            default:
                return "";
        }
    }

    int getAdvisorAttubtue(Advisor ad, int x)
    {
        switch(x)
        {
            case 1: return ad.diplomacy;
            case 2: return ad.stewardship;
            case 3: return ad.martial;
            case 4: return ad.intrigue;
            case 5: return ad.learning;
            case 6: return ad.arcane;
            default: return 0;
        }
    }

  

    Advisor getAdvisor()
    {
        switch (selectedList)
        {
            case 1:
                return getPlayer().GetComponent<Player>().chancellor;
            case 2:
                return getPlayer().GetComponent<Player>().steward;
            case 3:
                return getPlayer().GetComponent<Player>().marshal;
            case 4:
                return getPlayer().GetComponent<Player>().spymaster;
            case 5:
                return getPlayer().GetComponent<Player>().physician;
            case 6:
                return getPlayer().GetComponent<Player>().servant;
            case 7:
                return getPlayer().GetComponent<Player>().witch;
            case 8:
                return getPlayer().GetComponent<Player>().order;
            default:
                return null;
        }
    }

    void setAdvisor(Advisor a)
    {
        switch(selectedList)
        {
            case 1:
                getPlayer().GetComponent<Player>().chancellor = a;
                break;
            case 2:
                getPlayer().GetComponent<Player>().steward = a;
                break;
            case 3:
                getPlayer().GetComponent<Player>().marshal = a;
                break;
            case 4:
                getPlayer().GetComponent<Player>().spymaster = a;
                break;
            case 5:
                getPlayer().GetComponent<Player>().physician = a;
                break;
            case 6:
                getPlayer().GetComponent<Player>().servant = a;
                break;
            case 7:
                getPlayer().GetComponent<Player>().witch = a;
                break;
            case 8:
                getPlayer().GetComponent<Player>().order = a;
                break;
            default:
                break;
        }
    }


    //Add way for multiple important attributes
    int getRoleAttributes()
    {
        switch(selectedList)
        {
            case 1:
                return 1;
            case 2:
                return 2;
            case 3:
                return 3;
            case 4:
                return 4;
            case 5:
                return 5;
            case 6:
                return 5;// and 1
            case 7:
                return 6;
            case 8:
                return 3;
            default:
                return 0;
        }
    }

    void DrawBox(Rect position, Color color)
    {
        Color oldColor = GUI.color;

        GUI.color = color;
        GUI.Box(position, "");

        GUI.color = oldColor;
    }
}
