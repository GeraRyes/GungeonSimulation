using System;
using System.Collections;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        this.FloorNumber = 1;
        this.SetFloorProbability();
        this.NumberOfKeys = 0;
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
            yield return new WaitForSeconds(0.05f);
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
                break;
            case 2:
                this.Floor2 = new Floor(this.FloorNumber);
                this.CurrentFloor = this.Floor2;
                break;
            case 3:
                this.Floor3 = new Floor(this.FloorNumber);
                this.CurrentFloor = this.Floor3;
                break;
            case 4:
                this.Floor4 = new Floor(this.FloorNumber);
                this.CurrentFloor = this.Floor4;
                break;
            case 5:
                this.Floor5 = new Floor(this.FloorNumber);
                this.CurrentFloor = this.Floor5;
                break;
        }
    }

    public void DoNextStep()
    {
        if (this.CurrentFloor.RemainingRoomsOnFloor != 0)
        {
            this.CurrentFloor.TransitionToNewRoom();
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
}
