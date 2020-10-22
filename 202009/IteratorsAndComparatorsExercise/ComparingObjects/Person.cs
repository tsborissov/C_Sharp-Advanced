﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ComparingObjects
{
    class Person : IComparable<Person>
    {
        private string name;
        private int age;
        private string town;

        public Person(string name, int age, string town)
        {
            this.name = name;
            this.age = age;
            this.town = town;
        }

        public int CompareTo([AllowNull] Person other)
        {
            if (this.name.CompareTo(other.name) != 0)
            {
                return this.name.CompareTo(other.name);
            }

            if (this.age.CompareTo(other.age) != 0)
            {
                return this.age.CompareTo(other.age);
            }

            return this.town.CompareTo(other.town);
        }
    }
}
