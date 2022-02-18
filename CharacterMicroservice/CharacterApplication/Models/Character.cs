using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterApplication.Models
{
    public class Character
    {
        private string _id;
        private string _name;
        private string _power;
        private string _description;
        private string _type;
        private int _rank;

        public Character()
        {
        }
        public Character(string id)
        {
            ID = id;
        }
        public Character(string id, string name, string power, string description, string type, int rank)
        {
            ID = id;
            Name = name;
            Power = power;
            Description = description;
            Type = type;
            Rank = rank;
        }
        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Power
        {
            get { return _power; }
            set { _power = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public int Rank
        {
            get { return _rank; }
            set { _rank = value; }
        }
    }
}
