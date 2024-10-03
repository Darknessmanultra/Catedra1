using Microsoft.EntityFrameworkCore;

namespace Catedra.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }
        public DbSet<User> Users {get; set;} = null!;

        public static void SEEDER(UserContext context)
        {
            if(!context.Users.Any())
            {
                context.Users.AddRange(
                    new User{RUT="19.950.268-9", Nombre="Ivan Dorador",Correo="ivan.dorador@alumnos.ucn.cl",Genero="masculino",FechaNacimiento=new DateOnly(1998,3,19)},
                    new User{RUT="91.111.111-1", Nombre="Mario Mario",Correo="mariomario@mario.com",Genero="masculino",FechaNacimiento=new DateOnly(1981,9,10)},
                    new User{RUT="88.888.888-K", Nombre="Luigi Mario",Correo="luigimario@mario.com",Genero="masculino",FechaNacimiento=new DateOnly(1983,9,10)},
                    new User{RUT="69.696.969-6", Nombre="King Harkinian",Correo="mahboidinner@gmail.com",Genero="masculino",FechaNacimiento=new DateOnly(1994,6,29)},
                    new User{RUT="99.999.999-9", Nombre="Ivo Robotnik",Correo="EGG123@egg.com",Genero="masculino",FechaNacimiento=new DateOnly(1991,12,6)},
                    new User{RUT="99.950.999-K", Nombre="Dante Torobolino",Correo="mishow@minutos.cl",Genero="masculino",FechaNacimiento=new DateOnly(1998,3,19)},
                    new User{RUT="66.666.666-6", Nombre="Medusa",Correo="athenasucks@gmail.com",Genero="femenino",FechaNacimiento=new DateOnly(1998,3,19)},
                    new User{RUT="77.777.777-7", Nombre="Bitterman",Correo="waronstroggos@wor.com",Genero="masculino",FechaNacimiento=new DateOnly(1998,9,14)},
                    new User{RUT="98.765.432-1", Nombre="Que es eso",Correo="supoderes@sercoloramarillo.net",Genero="prefiero no decirlo",FechaNacimiento=new DateOnly(1000,12,12)},
                    new User{RUT="69.420.666-3", Nombre="Apache helicopter",Correo="myfavoritegender@hotmail.cl",Genero="otro",FechaNacimiento=new DateOnly(1903,6,13)}
                );
                context.SaveChanges();
            }
        }
    }
}