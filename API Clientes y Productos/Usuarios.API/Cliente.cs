using System;

namespace Usuarios.API
{
	public class Cliente
	{
		public int Id { get; set; }
		
        public string Rut { get; set; }

        public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Email { get; set; }

		public string Address { get; set; }

	}
}
