﻿using CleanCodeSeries.Workshop.Lesson4.EasyOOP;
using System;

namespace CleanCodeSeries.Workshop.Lesson4.SOLID
{
    public class RandomiserZero : IRandom
    {
        private Random _random = new Random();
        public int Next(int value) => 0;
    }
}