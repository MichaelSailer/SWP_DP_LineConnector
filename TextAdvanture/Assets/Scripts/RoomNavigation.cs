using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNavigation : MonoBehaviour
{
    public Room currentRoom;
    private GameController gameController;

    Dictionary<string, Room> exitDictionary = new Dictionary<string, Room>();

    private void Awake()
    {
        gameController = GetComponent<GameController>();

    }
    public void unpackExitRoom()
    {
        for (int i = 0; i < currentRoom.exits.Length; i++)
        {
            exitDictionary.Add(currentRoom.exits[i].keyString, currentRoom.exits[i].valueRoom);
            gameController.interactionDescriptionRoom.Add(currentRoom.exits[i].exitdescription);
            
        }
    }
    void attemptToCahngeRoom(string dictionNoun)
    {
        if (exitDictionary.ContainsKey(dictionNoun))
        {
            currentRoom = exitDictionary[dictionNoun];
            gameController.logStrignwithReturn("You head of to the " + dictionNoun);
            gameController.DisplayLogText();
        }
        else
        {
            gameController.logStrignwithReturn("There is no way to the " + dictionNoun);
        }
    }
    public void clearExits()
    {
        exitDictionary.Clear();
    }
}
