﻿namespace back.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Qualification { get; set; }

        public User(int id, string firstName, string lastName, string email, int qualification)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Qualification = qualification;
        }
    }
}
