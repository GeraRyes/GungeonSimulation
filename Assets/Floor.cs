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
    public int ChestRoomsLeft,
                BossRoomsLeft;

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
    public float R;

    Floor()
    { 
        this.TransitionToRoomChance = 85.18f;
        this.TransitionToBossChance = 0;
        this.TransitionToChestChance = 14.82f;

        this.RoomsOnFloor = 13;
        this.RemainingRoomsOnFloor = 13;

        this.ChestRoomsLeft = 0;
        this.BossRoomsLeft = 0;

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

        this.R = 0;
    }

    public void TransitionToNewRoom()
    {
        //If it's the first room
        if (this.TransitionToBossChance == 0)
        {
            this.R = Random.Range(0f, 100f);
            
            //If transitioned to chest room
            if ((this.RMinusChance(this.TransitionToChestChance))<0)
            {
                this.PFD.AddRoom(this.GenerateChest(), "None");
                this.ChestRoomsLeft--;
            }
            //If transitiones to normal room
            else
            {
                this.PFD.AddRoom(ChestDropRoomClear(), GeneratePickup());
            }
        }
        //If it's not the first room
        else
        {
            this.R = Random.Range(0f, 100f);
            //If transitioned to boss room
            if ((this.RMinusChance(this.TransitionToBossChance)) < 0)
            {
                this.PFD.AddRoom(GenerateChest(), "Key");
                this.BossRoomsLeft = 0;
            }
            //If transitioned to chest room
            else if ((this.RMinusChance(this.TransitionToChestChance))<0)
            {
                this.PFD.AddRoom(this.GenerateChest(), "None");
                this.ChestRoomsLeft--;
            }
            //If transitiones to normal room
            else
            {
                this.PFD.AddRoom(ChestDropRoomClear(), GeneratePickup());
            }
        }

        this.RemainingRoomsOnFloor--;
        this.AdjustProbability();
    }
    
    //Get a string with the generated chest in a room
    public string GenerateChest()
    {
        string GeneratedChest;
        this.R = Random.Range(0, 100);
        if (this.RMinusChance(this.SChestChance) <= 0)
        {
            GeneratedChest = "S";
        }
        else if (this.RMinusChance(this.AChestChance) <= 0)
        {
            GeneratedChest = "A";
        }
        else if (this.RMinusChance(this.BChestChance) <= 0)
        {
            GeneratedChest = "B";
        }
        else if (this.RMinusChance(this.CChestChance) <= 0)
        {
            GeneratedChest = "C";
        }
        else
        {
            GeneratedChest = "D";
        }

            return GeneratedChest;
    }

    public string GeneratePickup()
    {
        string Pickup;
        this.R = Random.Range(0, 100);

        //If a pickup is generated
        if (this.RMinusChance(this.PickupChance) <= 0)
        {
            this.R = Random.Range(0, 100);
            
            //If the pickup is a key
            if (this.RMinusChance(this.KeyChance) <= 0)
            {
                Pickup = "Key";
            }
            //If the pickup is something else
            else
            {
                Pickup = "Other";
            }
        }
        //If no pickup was generated
        else
        {
            Pickup = "None";
        }
        return Pickup;
    }

    public string ChestDropRoomClear()
    {
        string GeneratedChest;
        this.R = Random.Range(0, 100);
        if (this.RMinusChance(this.ChestAtClearChance) <= 0)
        {
            GeneratedChest = this.GenerateChest();
            this.ChestAtClearChance = 1;
        }
        else{
            GeneratedChest = "None";
            this.ChestAtClearChance += this.ChestIncrementChance;
        }
        return GeneratedChest;
    }


    //Adjust the probabilities after each room
    public void AdjustProbability()
    {
        //Adjust remaining floors
        this.TransitionToRoomChance = this.RemainingRoomsOnFloor - this.ChestRoomsLeft - this.BossRoomsLeft / this.RemainingRoomsOnFloor;
        this.TransitionToChestChance = this.ChestRoomsLeft / this.RemainingRoomsOnFloor;
        this.TransitionToBossChance = this.BossRoomsLeft / this.RemainingRoomsOnFloor;

    }

    public float RMinusChance(float chance)
    {
        this.R = this.R - chance;
        return R;
    }
}
