﻿using System;

namespace HeptaSoft.SmartEntityTests.TestData
{
    public class ClassA
    {
        public int NumericProperty { get; set; }
        public DateTime DateProperty { get; set; }
        public string StringProperty { get; set; }
        public ClassA ObjectProperty { get; set; }
    }
}
