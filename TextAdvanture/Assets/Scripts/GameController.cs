using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    [HideInInspector] public RoomNavigation roomNavigation;
    public Text displayText;
    [HideInInspector] public List<string> interactionDescriptionRoom = new List<string>();
    List<string> actionLog = new List<string>();

    private void Awake()
    {
        roomNavigation = GetComponent<RoomNavigation>();
    }
    public void DisplayLogText()
    {
        string logAsText = string.Join("\n", actionLog.ToArray());
        displayText.text = logAsText;
    }
    private void Start()
    {
        DisplayRoomText();

        DisplayLogText(); 
    }
    public void DisplayRoomText()
    {
        unpackRoom();

        string joinedInteractingDescription = string.Join("\n", interactionDescriptionRoom.ToArray());

        string text = roomNavigation.currentRoom.description + "\n" + joinedInteractingDescription;

        logStrignwithReturn(text);
    }
    public void logStrignwithReturn(string toadd)
    {
        actionLog.Add(toadd + "\n"); 
    }
    void clearCollectForNewRoom()
    {
        interactionDescriptionRoom.Clear();
        roomNavigation.clearExits();
    }
    private void unpackRoom()
    {

        roomNavigation.unpackExitRoom();
    }
    private void Update()
    {
        
    }
}
