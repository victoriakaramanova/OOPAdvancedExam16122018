﻿using System.Collections.Generic;
using TheTankGame.Entities.Miscellaneous;
using TheTankGame.Entities.Miscellaneous.Contracts;
using TheTankGame.Entities.Parts.Contracts;
using TheTankGame.Entities.Vehicles.Contracts;

namespace TheTankGame.Entities.Vehicles
{
    public class Revenger : BaseVehicle
    {
        public Revenger(string model, double weight, decimal price, int attack, int defense, int hitPoints, IAssembler assembler) 
            : base(model, weight, price, attack, defense, hitPoints, assembler)
        {
        }
    }
}