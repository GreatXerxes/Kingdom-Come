using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestEvents : MonoBehaviour
{
    public List<GameEvent> chancellorEvents = new List<GameEvent>();


    // Use this for initialization
    void Start ()
    {
        chancellorEvents = new GameEventChancellor().events;
        Debug.Log(chancellorEvents.Count);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (GameObject.Find("Events Window") == null)
        {
            //GameObject createEvent = Instantiate(newevent, transform.position, transform.rotation) as GameObject;
            GameObject newevent = new GameObject();
            newevent.name = "Events Window";
            newevent.AddComponent<GUIEvent>();
            newevent.GetComponent<GUIEvent>().setEvent(chancellorEvents[0]);


        }
    }
}
