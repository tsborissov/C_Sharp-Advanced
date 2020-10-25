using System;
using System.Collections.Generic;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> data;

        public Clinic(int capacity)
        {
            this.Capacity = capacity;

            this.data = new List<Pet>();
        }

        public int Capacity { get; set; }
        public int Count
        {
            get { return this.data.Count; }
        }

        public void Add(Pet pet)
        {
            if (this.data.Count < this.Capacity)
            {
                this.data.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            bool isFound = false;

            foreach (var pet in this.data)
            {
                if (pet.Name == name)
                {
                    isFound = true;
                    this.data.Remove(pet);
                    break;
                }
            }

            return isFound;
        }

        public Pet GetPet(string name, string owner)
        {
            Pet targetPet = new Pet("", -1, "");

            foreach (var pet in this.data)
            {
                if (pet.Name == name && pet.Owner == owner)
                {
                    targetPet = pet;
                    break;
                }
            }

            if (targetPet.Age == -1)
            {
                return null;
            }
            else
            {
                return targetPet;
            }
        }

        public Pet GetOldestPet()
        {
            int oldestPetYears = -1;
            int oldestPetIndex = -1;

            for (int i = 0; i < this.data.Count; i++)
            {
                Pet currentPet = this.data[i];

                if (currentPet.Age > oldestPetYears)
                {
                    oldestPetYears = currentPet.Age;
                    oldestPetIndex = i;
                }
            }

            if (oldestPetIndex == -1)
            {
                return null;
            }
            else
            {
                return this.data[oldestPetIndex];
            }
        }

        public string GetStatistics()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine("The clinic has the following patients:");

            foreach (var pet in this.data)
            {
                result.AppendLine($"{pet.Name} {pet.Owner}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
