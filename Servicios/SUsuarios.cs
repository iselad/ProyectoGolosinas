using DatosBD.Interfaz;
using DatosBD.Repositorio;
using ModeloE;
using ProyectoGolosinas.Data;
using ProyectoGolosinas.Interfaces;

namespace ProyectoGolosinas.Servicios;
//Heredar la interfaz IUsuarioS
public class SUsuarios : IUsuarioS
{
    //objeto de MySQLConfiguracion, este va permitir al program.cs y acceder a la cadena de conexion
    // readonly  solo lectura
    private readonly MySQLconfiguracion _configuracion;
    private IUsuarioR rUsuario;
    //Cadena de conexion 
    public SUsuarios(MySQLconfiguracion configuracion)
    {
        _configuracion = configuracion;
        //accedemos al repositorio y le pasamos la cadena de conexion
        rUsuario= new RUsuario(configuracion.ConexionC);
    }
    //Mtodos implementados
    public async Task<bool> Actualizar(Usuarios usuario)
    {
        return await rUsuario.Actualizar(usuario);
    }

    public async Task<bool> Eliminar(Usuarios usuario)
    {
        return await rUsuario.Eliminar(usuario);
    }

    public async Task<IEnumerable<Usuarios>> GetLista()
    {
        //retornamos 
        return await rUsuario.GetLista();
    }

    public  async Task<Usuarios> GetPorCodigo(string codigo)
    {
       
        return await rUsuario.GetPorCodigo(codigo);   
    }

    public async Task<bool> Nuevo(Usuarios usuario)
    {
        return await rUsuario.Nuevo(usuario);
    }
}
