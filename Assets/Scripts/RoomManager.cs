using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{

    public GameObject[] rooms;

    public void HideRooms(int number)
    {
        for (int i = 0; i < rooms.Length; i++)
        {
            if (i == number)
                continue;

            rooms[i].SetActive(false);
        }
    }

    public void RevealAllRooms()
    {
        foreach (GameObject room in rooms)
        {
            room.SetActive(true);
        }
    }

    //All room Must have Tags. Required Tags are written in ProbLoader.

    public void AddRoom(int number, string roomTag)
    {
        
        rooms[number] = GameObject.FindWithTag(roomTag);
    }
}
