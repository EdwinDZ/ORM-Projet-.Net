using System;
namespace ORMProjet.Connection
{
    public interface ISQLConnection
    {
        Boolean Connection();
        Boolean Disconnection();
    }
}
