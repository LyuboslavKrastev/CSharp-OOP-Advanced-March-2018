using System;
using System.Collections.Generic;
using System.Linq;

public class GameController
{
    private IArmy army;
    private IWareHouse wareHouse;
    private MissionController missionController;
    private ISoldierFactory soldierFactory;
    private IMissionFactory missionFactory;
    private IWriter writer;

    public GameController(IWriter writer)
    {
        this.army = new Army();
        this.wareHouse = new WareHouse();
        this.missionController = new MissionController(army, wareHouse);
        this.soldierFactory = new SoldierFactory();
        this.missionFactory = new MissionFactory();
        this.writer = writer;
    }

    public void GiveInputToGameController(string input)
    {
        var data = input.Split();

        if (data[0].Equals("Soldier"))
        {
            if (data[1] == "Regenerate")
            {
                army.RegenerateTeam(data[2]);
            }
            else
            {
                string soldierType = data[1];
                string soldierName = data[2];
                int age = int.Parse(data[3]);
                double experience = double.Parse(data[4]);
                double endurance  = double.Parse(data[5]);

                ISoldier soldier = this.soldierFactory
                    .CreateSoldier(soldierType, soldierName, age, experience, endurance);
                if (!this.wareHouse.TryEquipSoldier(soldier))
                {
                    string message = string.Format(OutputMessages.SoldierCannotBeEquiped, soldierType, soldierName);
                    throw new ArgumentException(message);
                }
                army.AddSoldier(soldier);
            }
        }
        else if (data[0].Equals("WareHouse"))
        {
            string name = data[1];
            int number = int.Parse(data[2]);

            this.wareHouse.AddAmmunition(name, number);
        }
        else if (data[0].Equals("Mission"))
        {
            string missionType = data[1];
            double scoreToComplete = double.Parse(data[2]);
            IMission mission = this.missionFactory.CreateMission(missionType, scoreToComplete);

            writer.AppendLine(this.missionController.PerformMission(mission).Trim());
        }
    }

    public void RequestResult()
    {
        this.missionController.FailMissionsOnHold();
        this.writer.AppendLine(OutputMessages.Results);
        this.writer.AppendLine(string.Format(OutputMessages.SuccessfulMissionsCount, this.missionController.SuccessMissionCounter));
        this.writer.AppendLine(string.Format(OutputMessages.FailedMissionsCount, this.missionController.FailedMissionCounter));
        this.writer.AppendLine(OutputMessages.Soldiers);

        foreach (var soldier in this.army.Soldiers.OrderByDescending(s => s.OverallSkill))
        {
            this.writer.AppendLine(soldier.ToString());
        }
    }
}