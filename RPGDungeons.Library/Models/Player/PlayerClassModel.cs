using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGDungeons.Library.Models
{
    public class PlayerClassModel
    {
        private string _name;
        private double _multiplierHitPoints;
        private double _multiplierMagicPoints;
        private double _multiplierAgility;
        private double _multiplierStrength;
        private double _multiplierIntellignce;
        private double _multiplierAttack;
        private double _multiplierDefense;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public double MultiplierHitPoints
        {
            get { return _multiplierHitPoints; }
            set { _multiplierHitPoints = value; }
        }
        public double MultiplierMagicPoints
        {
            get { return _multiplierMagicPoints; }
            set { _multiplierMagicPoints = value; }
        }
        public double MultiplierAgility
        {
            get { return _multiplierAgility; }
            set { _multiplierAgility = value; }
        }
        public double MultiplierStrength
        {
            get { return _multiplierStrength; }
            set { _multiplierStrength = value; }
        }
        public double MultiplierIntellignce
        {
            get { return _multiplierIntellignce; }
            set { _multiplierIntellignce = value; }
        }
        public double MultiplierAttack
        {
            get { return _multiplierAttack; }
            set { _multiplierAttack = value; }
        }
        public double MultiplierDefense
        {
            get { return _multiplierDefense; }
            set { _multiplierDefense = value; }
        }

        public PlayerClassModel(string name)
        {
            Name = name;
        }
    }
}
