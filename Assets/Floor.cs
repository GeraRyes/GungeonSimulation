using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor{
    //Room transition percentage
    public float TransitionToRoomChance,
                TransitionToBossChance,
                TransitionToChestChance;

    //Number of rooms per floor and remaining rooms
    public int RoomsOnFloor,
               RemainingRoomsOnFloor;

    //Boss and chest room counters
    public int ChestRoomsGenerated,
                BossRoomsGenerated;

    //Chance of pickups appearing; and chance per pickup type
    public float PickupChance,
                  KeyChance;

    //Chest generation chance when a room is cleared and the increment
    public float ChestAtClearChance,
                  ChestIncrementChance;

    //Chance of generation per chest type
    public float DChestChance,
                  CChestChance,
                  BChestChance,
                  AChestChance,
                  SChestChance;

    //Current floor counter
    public int currentFloor;

    //Previous rooms object
    public PlayerFloorData PFD;

    //Random Float
    

    Floor()
    { 
        this.TransitionToRoomChance = 85.18f;
        this.TransitionToBossChance = 0;
        this.TransitionToChestChance = 14.82f;

        this.RoomsOnFloor = 13;
        this.RemainingRoomsOnFloor = 13;

        this.ChestRoomsGenerated = 0;
        this.BossRoomsGenerated = 0;

        this.PickupChance = 26;
        this.KeyChance = 24.36f;

        this.ChestAtClearChance = 1;
        this.ChestIncrementChance = 9;


        this.DChestChance = 10;
        this.CChestChance = 50;
        this.BChestChance = 35;
        this.AChestChance = 4;
        this.SChestChance = 1;

        this.currentFloor = 1;

        this.PFD = new PlayerFloorData(0);

    }

    public void TransitionToNewRoom()
    {
        if (this.TransitionToBossChance == 0)
        {
            float R = Random.Range(0f, 100f);
            
            if ((R-this.TransitionToChestChance)<0)
            {
                
            }
            else
            {
                //Codigo para crear un cuarto
            }
        }
        else
        {

            float R = Random.Range(0f, 100f);
            if ((R - this.TransitionToBossChance) < 0)
            {
                //Codigo para crear un boss
            }
            else if ((R-this.TransitionToChestChance)<0)
            {
                //Codigo para crear un chest
            }
            else
            {
                //Codigo para crear un cuarto
            }
        }
    }
    

    public string GenerateChest()
    {
        string GeneratedChest;
        float R = Random.Range(0, 100);
        if (R - this.SChestChance <= 0)
        {
            GeneratedChest = "S";
        }
        else if (R - this.SChestChance <= 0)
        {
            GeneratedChest = "A";
        }
        else if (R - this.SChestChance <= 0)
        {
            GeneratedChest = "B";
        }
        else if (R - this.SChestChance <= 0)
        {
            GeneratedChest = "C";
        }
        else
        {
            GeneratedChest = "D";
        }

            return GeneratedChest;
    }
}
