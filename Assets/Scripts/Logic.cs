using System;
using System.Collections;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class Logic : MonoBehaviour
{
    public Floor Floor1,
                        Floor2,
                        Floor3,
                        Floor4,
                        Floor5,
                        CurrentFloor;
    public int          FloorNumber;
    public int          NumberOfKeys;
    public FloorReport  Floor1Report,
                        Floor2Report,
                        Floor3Report,
                        Floor4Report,
                        Floor5Report;
    public SpriteRenderer Room1SR,
                            ChestDrop,
                            KeyDrop;
    public Transform Room1Transform;
    public int          i;
    public bool         Room1Flag,
                        Room2Flag;
    public Sprite       ChestS,
                        ChestA,
                        ChestB,
                        ChestC,
                        ChestD;
    public Text         DItemText,
                        CItemText,
                        BItemText,
                        AItemText,
                        SItemText,
                        DChestText,
                        CChestText,
                        BChestText,
                        AChestText,
                        SChestText,
                        KeyText;


    // Start is called before the first frame update
    void Start()
    {
        this.FloorNumber = 1;
        this.SetFloorProbability();
        this.NumberOfKeys = 1;
        this.Room1Transform.position = new Vector3(0, -1, 0);

        
        this.Room1Flag = true;
        this.Room2Flag = true;

        var tempColor = this.KeyDrop.color;
        tempColor.a = 0f;
        this.KeyDrop.color = tempColor;
        this.ChestDrop.color = tempColor;
        StartCoroutine(work());
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator work()
    {
        while (this.FloorNumber != -1)
        {
            if (this.ChestDrop.color.a == 1f || this.KeyDrop.color.a == 1f)
            {
                yield return new WaitForSeconds(2f);
            }
            else
            {
                yield return new WaitForSeconds(0.01f);
            }
            
            this.DoNextStep();
        }
    }

    public void SetFloorProbability()
    {
        switch (this.FloorNumber)
        {
            case 1:
                this.Floor1 = new Floor(this.FloorNumber);
                this.CurrentFloor = this.Floor1;
                this.i = 0;
                break;
            case 2:
                this.Floor2 = new Floor(this.FloorNumber);
                this.CurrentFloor = this.Floor2;
                this.i = 0;
                break;
            case 3:
                this.Floor3 = new Floor(this.FloorNumber);
                this.CurrentFloor = this.Floor3;
                this.i = 0;
                break;
            case 4:
                this.Floor4 = new Floor(this.FloorNumber);
                this.CurrentFloor = this.Floor4;
                this.i = 0;
                break;
            case 5:
                this.Floor5 = new Floor(this.FloorNumber);
                this.CurrentFloor = this.Floor5;
                this.i = 0;
                break;
        }
    }

    public void DoNextStep()
    {
        if (this.CurrentFloor.RemainingRoomsOnFloor != 0)
        {
            this.CurrentFloor.TransitionToNewRoom();
            this.KeyChestOpacity();
            this.i++;
        }
        else
        {
            switch (this.FloorNumber)
            {
                case 1:
                    this.Floor1Report = new FloorReport(this.Floor1.PFD, this.FloorNumber);
                    break;
                case 2:
                    this.Floor2Report = new FloorReport(this.Floor2.PFD, this.FloorNumber);
                    break;
                case 3:
                    this.Floor3Report = new FloorReport(this.Floor3.PFD, this.FloorNumber);
                    break;
                case 4:
                    this.Floor4Report = new FloorReport(this.Floor4.PFD, this.FloorNumber);
                    break;
                case 5:
                    this.Floor5Report = new FloorReport(this.Floor5.PFD, this.FloorNumber);
                    break;
            }

            if (this.FloorNumber == 5)
            {
                this.Floor1Report.PrintReport();
                this.Floor2Report.PrintReport();
                this.Floor3Report.PrintReport();
                this.Floor4Report.PrintReport();
                this.Floor5Report.PrintReport();
                this.FloorNumber = -1;
            }
            else
            {
                this.FloorNumber++;
                this.SetFloorProbability();
            }
        }
        

    }

    public void KeyChestOpacity()
    {
        Room tmp = this.CurrentFloor.PFD.GetRoom(i);
        var tempColor = this.KeyDrop.color;
        switch (tmp.GeneratedChest)
        {
            case "S":
                tempColor.a = 1f;
                this.ChestDrop.color = tempColor;
                this.ChestDrop.sprite = this.ChestS;
                this.SChestText.text = (int.Parse(this.SChestText.text) + 1).ToString();
                if (this.NumberOfKeys > 0)
                {
                    this.SItemText.text = (int.Parse(this.SItemText.text) + 1).ToString();
                    this.NumberOfKeys--;
                    this.KeyText.text = NumberOfKeys.ToString();
                }
                break;
            case "A":
                tempColor.a = 1f;
                this.ChestDrop.color = tempColor;
                this.ChestDrop.sprite = this.ChestA;
                this.AChestText.text = (int.Parse(this.AChestText.text) + 1).ToString();
                if (this.NumberOfKeys > 0)
                {
                    this.AItemText.text = (int.Parse(this.AItemText.text) + 1).ToString();
                    this.NumberOfKeys--;
                    this.KeyText.text = NumberOfKeys.ToString();
                }
                break;
            case "B":
                tempColor.a = 1f;
                this.ChestDrop.color = tempColor;
                this.ChestDrop.sprite = this.ChestB;
                this.BChestText.text = (int.Parse(this.BChestText.text) + 1).ToString();
                if (this.NumberOfKeys > 0)
                {
                    this.BItemText.text = (int.Parse(this.BItemText.text) + 1).ToString();
                    this.NumberOfKeys--;
                    this.KeyText.text = NumberOfKeys.ToString();
                }
                break;
            case "C":
                tempColor.a = 1f;
                this.ChestDrop.color = tempColor;
                this.ChestDrop.sprite = this.ChestC;
                this.CChestText.text = (int.Parse(this.CChestText.text) + 1).ToString();
                if (this.NumberOfKeys > 0)
                {
                    this.CItemText.text = (int.Parse(this.CItemText.text) + 1).ToString();
                    this.NumberOfKeys--;
                    this.KeyText.text = NumberOfKeys.ToString();
                }
                break;
            case "D":
                tempColor.a = 1f;
                this.ChestDrop.color = tempColor;
                this.ChestDrop.sprite = this.ChestD;
                this.DChestText.text = (int.Parse(this.DChestText.text) + 1).ToString();
                if (this.NumberOfKeys > 0)
                {
                    this.DItemText.text = (int.Parse(this.DItemText.text) + 1).ToString();
                    this.NumberOfKeys--;
                    this.KeyText.text = NumberOfKeys.ToString();
                }
                break;
            case "None":
                tempColor.a = 0f;
                this.ChestDrop.color = tempColor;
                break;
        }
        switch (tmp.GeneratedPickup)
        {
            case "Key":
                tempColor.a = 1f;
                this.KeyDrop.color = tempColor;
                this.NumberOfKeys++;
                this.KeyText.text = NumberOfKeys.ToString();
                break;
            default:
                tempColor.a = 0f;
                this.KeyDrop.color = tempColor;
                break;
        }
    }
}
