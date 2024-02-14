using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using VaitsekhovskiiOS.interfaces;

namespace VaitsekhovskiiOS.classes
{
    internal class Farm
    {
        List<Animal> listOfClass = new List<Animal>();
        public event EventHandler<string> CreateEvent;
        //useless events
        //public event EventHandler<string> SaveEvent;
        //public event EventHandler<string> OpenEvent;
        private string fileName;
        public Farm()
        {
            fileName = "text.txt";
        }
        public List<Animal> ListOfAnimals
        {
            get => listOfClass;
            set => listOfClass = value;
            
        }
        public string FileName
        {
            get => fileName;
            set => fileName = value;
        }
        public void GridFiller(DataGridView grid, List<Animal> list)
        {
            foreach (var creature in list)
            {
                grid.Rows.Add(creature.Name, creature.Weight, creature.Type);
            }
        }
        public List<Animal> OpenFile(string userAnswer)
        {
            if(userAnswer!=String.Empty)
            {
                fileName = userAnswer;
                //OpenEvent?.Invoke(this, userAnswer);
                List<Animal> Animals = new List<Animal>();
                StreamReader sr = new StreamReader(userAnswer);
                string[] buffer;
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    buffer = line.Split(',');
                    if (buffer[0] == "Animal" && buffer.Length == 3)
                    {
                        Animals.Add(new Animal(buffer[1], Convert.ToDouble(buffer[2])));
                    }
                    if (buffer[0] == "Mammal" && buffer.Length == 4)
                    {
                        Animals.Add(new Mammal(buffer[1], Convert.ToDouble(buffer[2]), buffer[3]));
                    }
                    if (buffer[0] == "Artiodactyl" && buffer.Length == 5)
                    {
                        Animals.Add(new Artiodactyl(buffer[1], Convert.ToDouble(buffer[2]), buffer[3], Convert.ToBoolean(buffer[4])));
                    }
                }
                sr.Close();
                this.ListOfAnimals = Animals;
            }
            return listOfClass;
        }

        public void SaveFile(List<Animal> listOfAnimals)
        {
            StreamWriter sw = new StreamWriter(this.FileName, false);
            foreach (var Fauna in listOfAnimals)
            {
                if (Fauna is Animal wild)
                {
                    if(Fauna.Type=="Animal")
                    {
                        sw.WriteLine("{0},{1},{2}", wild.Type, wild.Name, wild.Weight);
                    }
                }
                if (Fauna is Mammal mams)
                {
                    if (Fauna.Type == "Mammal")
                    { 
                        sw.WriteLine("{0},{1},{2},{3}", mams.Type, mams.Name, mams.Weight, mams.Gender); 
                    }
                }
                if (Fauna is Artiodactyl horns)
                {
                    if (Fauna.Type == "Artiodactyl")
                    {
                        sw.WriteLine("{0},{1},{2},{3},{4}", horns.Type, horns.Name, horns.Weight, horns.Gender, Convert.ToString(horns.Horns));
                    } 
                }
            }
            sw.Close();
            this.ListOfAnimals = listOfAnimals;
            //SaveEvent?.Invoke(this, this.FileName);
        }

        public void CreateFile(string userAnswer)
        {
            this.FileName = userAnswer;
            StreamWriter sw = new StreamWriter(userAnswer, false);
            sw.WriteLine();
            sw.Close();
            CreateEvent?.Invoke(this, this.FileName);
            this.OpenFile(this.FileName);
        }

        public void DeleteItem(int itemIndex)
        {
            this.ListOfAnimals.RemoveAt(itemIndex);
            SaveFile(this.ListOfAnimals);
        }

        public List<Animal> Sort(List<Animal> list, int index, int riseFall)
        {
            if(riseFall==0)
            {
                if (index == 2)
                {
                    list.Sort(delegate (Animal c1, Animal c2) { return c1.Name.CompareTo(c2.Name); });
                }
                if (index == 1)
                {
                    list.Sort(delegate (Animal c1, Animal c2) { return c1.Type.CompareTo(c2.Type); });
                }
                if (index == 3)
                {
                    list.Sort(delegate (Animal c1, Animal c2) { return c1.Weight.CompareTo(c2.Weight); });
                }
            }
            else
            {
                if (index == 2)
                {
                    list.Sort(delegate (Animal c1, Animal c2) { return c1.Name.CompareTo(c2.Name); });
                    list.Reverse();
                }
                if (index == 1)
                {
                    list.Sort(delegate (Animal c1, Animal c2) { return c1.Type.CompareTo(c2.Type); });
                    list.Reverse();
                }
                if (index == 3)
                {
                    list.Sort(delegate (Animal c1, Animal c2) { return c1.Weight.CompareTo(c2.Weight); });
                    list.Reverse();
                }
            }
            return list;
        }
    }
}
