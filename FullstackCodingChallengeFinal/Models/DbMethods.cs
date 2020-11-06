using FullstackCodingChallengeFinal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullstackCodingChallengeFinal.Models
{
    public class DbMethods
    {

		public static int AddOnePerson(string firstName)
		{
			return AddOnePerson(new PersonModel() { FirstName = firstName });
		}
        public static int AddOnePerson(PersonModel person)
        {
            person.PersonId = 0;

            using (var context = new CompanyContext())
            {
                context.PersonModel.Add(person);
                context.SaveChanges();
            }

            return person.PersonId;
        }

        public static string[] GetAllPersonNames()
        {
            using (var context = new CompanyContext())
            {
                return context.PersonModel
                    .Select(s => s.FirstName)
                    .ToArray();
            }
        }

        public static int AddOneClient(string name)
        {
            return AddOneClient(new ClientsModel() { Name = name });
        }
        public static int AddOneClient(ClientsModel client)
        {
            client.ClientId = 0;

            using (var context = new CompanyContext())
            {
                context.ClientsModel.Add(client);
                context.SaveChanges();
            }

            return client.ClientId;
        }

        public static string[] GetAllClients()
        {
            using (var context = new CompanyContext())
            {
                return context.ClientsModel
                    .Select(s => s.Name)
                    .ToArray();
            }
        }

    }
}
