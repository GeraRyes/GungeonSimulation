using System;
using System.Collections.Generic;
using UnityEngine;

public class FloorReport
{
    public List<string> TotalChests;
    public List<string> TotalPickups;
    public int FloorNumber;

    public FloorReport()
    {
        this.TotalChests.Add("None");
        this.TotalPickups.Add("None");
        this.FloorNumber = 0;
    }

    public FloorReport(PlayerFloorData PFD, int FloorNumber)
    {
        this.TotalChests = new List<string>();
        this.TotalPickups = new List<string>();

        this.FloorNumber = FloorNumber;
        for (int i=0; i<PFD.GetRoomList().Count; i++)
        {
            this.TotalChests.Add(PFD.GetRoom(i).GeneratedChest);
            this.TotalPickups.Add(PFD.GetRoom(i).GeneratedPickup);
        }
    }

    public void PrintReport()
    {
        for (int i = 0; i < this.TotalChests.Count; i++)
        {
            Debug.Log("Cofres obtenidos en el piso: " + this.FloorNumber+" - "+this.TotalChests[i]);
        }
        for (int i = 0; i < this.TotalPickups.Count; i++)
        {
            Debug.Log("Pickups obtenidos en el piso: " + this.FloorNumber+" - "+this.TotalPickups[i]);
        }
    }

}
