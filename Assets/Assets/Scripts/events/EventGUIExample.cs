using UnityEngine;
using System.Collections;

public class EventGUI : MonoBehaviour
{

    /*public Rect container;
    public GUISkin _mySkin;
    public Texture2D image;
    public string eventDescription;
    public GameObject target;
    Rect title;
    Rect pictureFrame;
    Rect description;
    Rect firstResponse;
    string targetName;

    bool tooltip = false;

    // Use this for initialization
    void Start()
    {
        //GUIEnabled.enabled = false;
        container = new Rect(Screen.width / 2 - 225, Screen.height / 2 - 300, 450, 600);
        title = new Rect(container.width / 2 - 100, 50, 200, 50);
        pictureFrame = new Rect(container.width / 2 - 195, 100, 390, 199);
        description = new Rect(50, 320, container.width - 100, 60);
        firstResponse = new Rect(25, 435, container.width - 50, 30);
        Time.timeScale = 0.0f;
    }

    void OnGUI()
    {
        GUI.skin = _mySkin;
        GUI.depth = -20;
        GUI.Box(container, "", "EventWindow");
        GUI.BeginGroup(container);
        GUI.Label(title, "New Elder", "BlackCenter");
        GUI.Box(pictureFrame, "", "PictureFrame");
        GUI.BeginGroup(pictureFrame);
        GUI.DrawTexture(new Rect(5, 5, pictureFrame.width - 10, pictureFrame.height - 10), image);
        GUI.EndGroup();
        GUI.Label(description, eventDescription, "BlackCenter");
        if (GUI.Button(firstResponse, "I will do my best to guide our community.", "Scroll"))
        {
            Time.timeScale = 1.0f;
            GUIEnabled.enabled = true;
            foreach (GameObject citizen in SaveManager.Instance.citizenList)
            {
                CitizenOpinion co = citizen.GetComponent<CitizenOpinion>();
                if (co != null)
                {
                    co.addOpinion(10);
                }
            }
            Authority.Instance.GetApprovalRating();
            Destroy(gameObject);
        }
        tooltip = firstResponse.Contains(Event.current.mousePosition);
        GUI.EndGroup();
        if (tooltip)
        {
            Rect tool = new Rect(Input.mousePosition.x + 10, Screen.height - Input.mousePosition.y - 15, 200, 40);
            GUI.Box(tool, "", "BuildMenu");
            GUI.BeginGroup(tool);
            GUI.Label(new Rect(10, 10, tool.width - 20, 20), "Everyone's opinion of " + targetName + " increased by 10", "TextBlack");
            GUI.EndGroup();
        }
        GameGUI.Instance.isOnOtherGUI = container.Contains(Event.current.mousePosition);
    }*/
}

