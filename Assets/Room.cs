using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{ 
    public string GeneratedChest;
    public string GeneratedPickup;

    
        public Room(string GeneratedChest, string GeneratedPickup)
        {
            this.GeneratedChest = GeneratedChest;
            this.GeneratedPickup = GeneratedPickup;
        }
    
}
