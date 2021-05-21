using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFloorData
{
    int NumberOfKeys;
    List<Room> Rooms;

    public PlayerFloorData(int NumberOfKeys)
    {
        this.NumberOfKeys = NumberOfKeys;
        Rooms = new List<Room>();
    }

    public void AddRoom(string GeneratedChest, string GeneratedPickup) 
    {
        this.Rooms.Add(new Room(GeneratedChest, GeneratedPickup));
        if (GeneratedPickup == "Yes")
        {
            this.NumberOfKeys++;
        }
    }

}

