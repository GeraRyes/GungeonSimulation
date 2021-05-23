using Random = UnityEngine.Random;

public class Floor{
    //Room transition percentage
    public float TransitionToRoomChance,
                TransitionToBossChance,
                TransitionToChestChance;

    //Number of rooms per floor and remaining rooms
    public int RemainingRoomsOnFloor;

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

    //
    public bool FirstRoomFlag;

    public Floor(int FloorNumber)
    {
        //Universal variables
        this.ChestRoomsLeft = 2;
        this.BossRoomsLeft = 1;

        this.PickupChance = 26;
        this.KeyChance = 24.36f;

        this.ChestAtClearChance = 1;
        this.ChestIncrementChance = 9;

        this.PFD = new PlayerFloorData();
        this.R = 0;
        this.FirstRoomFlag = false;

        //Per floor variables
        switch (FloorNumber)
        {
            case 1:
                this.RemainingRoomsOnFloor = 13;
                this.DChestChance = 35;
                this.CChestChance = 32;
                this.BChestChance = 20;
                this.AChestChance = 9;
                this.SChestChance = 4;
                this.currentFloor = 1;
                break;
            case 2:
                this.RemainingRoomsOnFloor = 16;
                this.DChestChance = 10;
                this.CChestChance = 37;
                this.BChestChance = 40;
                this.AChestChance = 9;
                this.SChestChance = 4;
                this.currentFloor = 2;
                break;
            case 3:
                this.RemainingRoomsOnFloor = 20;
                this.DChestChance = 2;
                this.CChestChance = 26;
                this.BChestChance = 54;
                this.AChestChance = 12.5f;
                this.SChestChance = 5.5f;
                this.currentFloor = 3;
                break;
            case 4:
                this.RemainingRoomsOnFloor = 22;
                this.DChestChance = 2;
                this.CChestChance = 20;
                this.BChestChance = 50;
                this.AChestChance = 20;
                this.SChestChance = 8;
                this.currentFloor = 4;
                break;
            case 5:
                this.RemainingRoomsOnFloor = 24;
                this.DChestChance = 0;
                this.CChestChance = 10;
                this.BChestChance = 42.5f;
                this.AChestChance = 35;
                this.SChestChance = 12.5f;
                this.currentFloor = 5;
                break;
        }
        
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
                this.PFD.AddRoom(this.GenerateChest(), "Key");
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
        if (this.RemainingRoomsOnFloor != 0)
        {
            this.AdjustProbability();
        }
        
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
        if (!this.FirstRoomFlag)
        {
            this.TransitionToRoomChance = this.RemainingRoomsOnFloor - this.ChestRoomsLeft/ this.RemainingRoomsOnFloor;
            this.TransitionToChestChance = this.ChestRoomsLeft / this.RemainingRoomsOnFloor;
            this.TransitionToBossChance = 0;
            this.FirstRoomFlag = true;
        }
        else
        {
            this.TransitionToRoomChance = this.RemainingRoomsOnFloor - this.ChestRoomsLeft - this.BossRoomsLeft / this.RemainingRoomsOnFloor;
            this.TransitionToChestChance = this.ChestRoomsLeft / this.RemainingRoomsOnFloor;
            this.TransitionToBossChance = this.BossRoomsLeft / this.RemainingRoomsOnFloor;
        }
        

    }

    public float RMinusChance(float chance)
    {
        this.R = this.R - chance;
        return R;
    }
}
