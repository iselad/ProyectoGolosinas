namespace ProyectoGolosinas.Data
{
//Configuracion de MySQL
//Esta clase captura la cadena de conexion appsettings.json y la manda al proyecto de Datos
   public class MySQLconfiguracion
   {
 //Propiedad
 //se pone solo get ya que solo vamos a obtener 
       public string ConexionC {get;}
//Costructor de la clase 
      public MySQLconfiguracion (string conexionC)
       {
        ConexionC = conexionC;  
       }



   }
}
