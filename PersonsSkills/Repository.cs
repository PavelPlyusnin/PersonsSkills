using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PersonsSkills.Models;

namespace PersonsSkills.Models
{
   public class Repository
   {
        private readonly Conext conext;
       
        public Repository(Conext conext)
        {
            this.conext = conext;
        }

        public IQueryable<Person> GetPersons()
        {
            return conext.Persons.Include(person => person.Skills);
        }
        
        public Person GetPersonById(long personId)
        {
            return conext.Persons.Include(person => person.Skills)
                .FirstOrDefault(person => person.PersonId == personId);
        }

        public void AddPerson(Person newPerson)
        {
            conext.Persons.Add(newPerson);
            conext.SaveChanges();
        }

        public void DetectChangeSkill(string personName, string skillName, byte newLevel)
        {
            conext.ChangeTracker.AutoDetectChangesEnabled = false;
            Person person = conext.Persons.Include(sk => sk.Skills).First(p => p.Name == personName);
            Skill ownerSkill = person.Skills.First(ns => ns.Name == skillName);
            ownerSkill.Level = newLevel;
            conext.ChangeTracker.AutoDetectChangesEnabled = true;
            Console.WriteLine(conext.ChangeTracker.DebugView.LongView);
            conext.SaveChanges();
        }
        
        public void DeletePerson(Conext context, long personId)
        {
            Person person = context.Persons.SingleOrDefault(value => value.PersonId.Equals(personId));

            if (person != null) 
            {
                context.Entry(person).Collection(value => value.Skills).Load();
                context.Persons.Remove(person);
            }

            context.SaveChanges();
        }
    }
}
