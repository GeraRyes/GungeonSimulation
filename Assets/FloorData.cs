using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFloorData
{
    List<Room> Rooms;

    public PlayerFloorData()
    {
        
        Rooms = new List<Room>();
    }

    public void AddRoom(string GeneratedChest, string GeneratedPickup) 
    {
        this.Rooms.Add(new Room(GeneratedChest, GeneratedPickup));
    }

}

