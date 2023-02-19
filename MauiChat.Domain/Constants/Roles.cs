using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiChat.Domain.Constants
{
	public class Roles
	{
		public const string AdminPro = "Administrador Pro";
		public const string AdminProGuid = "2c5e174e-3b0e-446f-86af-483d56fd7210";
		public const string AdminProDescription = "Los administradores pro tienen acceso completo y sin restricciones a la plataforma";

		public const string Admin = "Administrador";
		public const string AdminGuid = "caddad05-120f-48a8-b659-ff4528e5df97";
		public const string AdminDescription = "Los administradores tienen acceso completo y sin restricciones dentro de la plataforma de chat";

		public const string User = "Usuario";
		public const string UserGuid = "33dde250-ddde-42db-a4b9-5a2355082391";
		public const string UserDescription = "Los usuarios pueden acceder a la mayoria de opciones de la plataforma y no pueden hacer cambios accidentales o intencionados";
	}
}
