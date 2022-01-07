﻿using System;

namespace RepositoryPattern
{
    [Serializable]
    public class Student : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
    }
}
