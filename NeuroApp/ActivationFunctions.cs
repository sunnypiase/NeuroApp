﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroApp
{
    public static class ActivationFunctions
    {
        public static double Sigmoid(double x) => 1.0 / (1.0 + Math.Pow(Math.E, -x));
        public static double InputFunc(double x) => x;

    }
}
