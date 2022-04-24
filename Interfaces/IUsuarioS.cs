
using ModeloE;

namespace ProyectoGolosinas.Interfaces;

public interface IUsuarioS
{
    //Metodos 
    Task<bool> Nuevo(Usuarios usuario);//para crear un nuevo Usuario
    Task<bool> Actualizar(Usuarios usuario);//Actualizar los Usuarios
    Task<bool> Eliminar(Usuarios usuario);//Eliminar Usuarios
    Task<IEnumerable<Usuarios>> GetLista();//Nos ayudara a listar todos los ususarios 
    Task<Usuarios> GetPorCodigo(string Codigo);//Seleccionar Usuario
}
