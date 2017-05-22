using UnityEngine;
using System.Collections;

public class GUIEvent : MonoBehaviour
{
    public Rect container;
    public GUISkin _mySkin;
    public Texture2D image;
    public string eventDescription;
    public GameObject target;
    Rect title;
    Rect pictureFrame;
    Rect description;
    Rect firstResponse;
    string targetName;

    GameEvent selectedEvent;

    bool tooltip = false;

    // Use this for initialization
    void Start ()
    {
        container = new Rect(Screen.width / 2 - 225, Screen.height / 2 - 300, 450, 600);
        title = new Rect(container.width / 2 - 100, 50, 200, 50);
        pictureFrame = new Rect(container.width / 2 - 195, 100, 390, 199);
        description = new Rect(50, 320, container.width - 100, 60);
        firstResponse = new Rect(25, 435, container.width - 50, 30);
        _mySkin = Resources.Load("Skins/MyGUISkin") as GUISkin;
        //Time.timeScale = 0.0f;
    }

    void OnGUI()
    {
        GUI.skin = _mySkin;
        GUI.depth = -20;
        GUI.Box(container, "", "EventWindow");

        GUI.BeginGroup(container);
        GUI.Label(title, selectedEvent.eventName, "BlackCenter");
        GUI.Box(pictureFrame, "", "PictureFrame");
        GUI.BeginGroup(pictureFrame);
        GUI.DrawTexture(new Rect(5, 5, pictureFrame.width - 10, pictureFrame.height - 10), image);
        GUI.EndGroup();
        GUI.Label(description, selectedEvent.description, "BlackCenter");

        int yOffSet = 0;
        for (int i = 0; i < selectedEvent.responses.Count; i++)
        {
            if (GUI.Button(new Rect(25, 435+ yOffSet, container.width - 50, 30), selectedEvent.responses[i].text, "Scroll"))
            {
                Time.timeScale = 1.0f;

                selectedEvent.responses[i].runResponse();

                Destroy(gameObject);
            }
            yOffSet += 30;
        }

        tooltip = firstResponse.Contains(Event.current.mousePosition);
        GUI.EndGroup();
        if (tooltip)
        {
            Rect tool = new Rect(Input.mousePosition.x + 10, Screen.height - Input.mousePosition.y - 15, 200, 40);
            GUI.Box(tool, "", "BuildMenu");
            GUI.BeginGroup(tool);
            int yAgainOffSet = 0;
            for (int i = 0; i < selectedEvent.responses.Count; i++)
            {
                GUI.Label(new Rect(10, 10 + yOffSet, tool.width - 20, 20), selectedEvent.responses[i].setToolTip(), "TextBlack");
                yAgainOffSet += 20;
            }
            GUI.EndGroup();
        }
        //GameGUI.Instance.isOnOtherGUI = container.Contains(Event.current.mousePosition);
    }

    public void setEvent(GameEvent e)
    {
        selectedEvent = e;
    }
}
