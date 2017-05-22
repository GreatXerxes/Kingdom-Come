using UnityEngine;
using System.Collections;

public class CreateNation : MonoBehaviour
{
    public bool isPlayerNation = false;

    int numOfNations = 0;
    public Nation nation;

	// Use this for initialization
	void Start ()
    {
        /*if (GameObject.Find("Player Nation") == null)
        {
            isPlayerNation = true;
        }

        if (isPlayerNation)
        {
            Nation playerNation = new Nation(isPlayerNation);
        }*/

        nation = new Nation(false);

        debugStuff(nation);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void debugStuff(Nation n)
    {
        Debug.Log(n.toString());
        if (n.empire!= null)
        {
            
            Debug.Log(n.empire.toString());
            for(int x = 0; x < n.empire.listKingdom.Count; x++)
            {
                Debug.Log(n.empire.listKingdom[x].toString());
                for(int y = 0; y < n.empire.listKingdom[x].listDuchy.Count; y++)
                {
                    Debug.Log(n.empire.listKingdom[x].listDuchy[y].toString());
                    for(int z = 0; z < n.empire.listKingdom[x].listDuchy[y].listCounty.Count; z++)
                    {
                        Debug.Log(n.empire.listKingdom[x].listDuchy[y].listCounty[z].toString());
                        for (int a = 0; a < n.empire.listKingdom[x].listDuchy[y].listCounty[z].listTerritory.Count; a++)
                        {
                            Debug.Log(n.empire.listKingdom[x].listDuchy[y].listCounty[z].listTerritory[a].toString());
                        }
                    }
                }
            }
            
        }
        else
        {
            Debug.Log(n.kingdom.toString());
            for (int x = 0; x < n.kingdom.listDuchy.Count; x++)
            {
                Debug.Log(n.kingdom.listDuchy[x].toString());
                for (int y = 0; y < n.kingdom.listDuchy[x].listCounty.Count; y++)
                {
                    Debug.Log(n.kingdom.listDuchy[x].listCounty[y].toString());
                    for (int z = 0; z < n.kingdom.listDuchy[x].listCounty[y].listTerritory.Count; z++)
                    {
                        Debug.Log(n.kingdom.listDuchy[x].listCounty[y].listTerritory[z].toString());
                    }
                }
            }
        }
    }
}
