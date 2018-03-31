using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class PetClinic
{
    private Pet[] pets;

    public PetClinic(string name, int roomCount)
    {
        ValidateRoomCount(roomCount);
        this.pets = new Pet[roomCount];
        this.Name = name;
    }
    public string Name { get;}

    public int MiddleRoom => this.pets.Length / 2;

    public bool HasEmptyRooms => this.pets.Any(p => p == null);

    public bool Add(Pet pet)
    {
        var currentRoom = this.MiddleRoom;

        for (int i = 0; i < this.pets.Length; i++)
        {
            if (i % 2 != 0)
            {
                currentRoom -= i;
            }
            else
            {
                currentRoom += i;
            }

            if (this.pets[currentRoom] == null)
            {
                this.pets[currentRoom] = pet;
                return true;
            }
        }

        return false;
    }

    public string Print(int roomNumber)
    {
        return this.pets[roomNumber - 1]?.ToString() ?? "Room empty";
    }

    public string Print()
    {
        var result = new StringBuilder();

        for (int i = 1; i <= this.pets.Length; i++)
        {
            result.AppendLine(this.Print(i));
        }

        return result.ToString().TrimEnd();
    }

    public bool Release()
    {
        for (int i = 0; i < this.pets.Length; i++)
        {
            var index = (this.MiddleRoom + i) % this.pets.Length;
            if (this.pets[index] != null)
            {
                this.pets[index] = null;
                return true;
            }
        }
        return false;
    }

    private static void ValidateRoomCount(int roomCount)
    {
        if (roomCount % 2 == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");

        }
    }
}

