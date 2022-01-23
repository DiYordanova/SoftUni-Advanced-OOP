﻿using System;
using System.Collections.Generic;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public abstract class Animal
    {
        protected Animal(string name, double weight, HashSet<string> allowedFoods, double weightModifier)
        {
            Name = name;
            Weight = weight;           
            AllowedFoods = allowedFoods;
            WeightModifier = weightModifier;
        }
        private HashSet<string> AllowedFoods { get; set; }

        private double WeightModifier { get; set; }

        public string  Name { get; private set; }

        public double  Weight { get; private set; }

        public int FoodEaten { get; private set; }

        public abstract string ProduceSound();

        public void Eat(Food food)
        {
            string foodGetType = food.GetType().Name;

            if (!AllowedFoods.Contains(foodGetType))
            {
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {foodGetType}!");
            }

            this.FoodEaten += food.Quantity;

            this.Weight += this.WeightModifier * food.Quantity;
        }
    }
}
