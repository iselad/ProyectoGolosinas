using Microsoft.AspNetCore.Components;
using ModeloE;
using ProyectoGolosinas.Interfaces;

namespace ProyectoGolosinas.Pages.Usuario;

partial class Usuario
{
    //Etiqueta
    [Inject] private IUsuarioS _usuarioS { get; set; }//Acceder a los metodos 
    //Almacenar el listados de los Datos 
    private IEnumerable<Usuarios> usuariosLista { get; set; }
    //Metodo para consultar a la base de Datos 
    //override: sobre escribir 
    protected override async Task OnInitializedAsync()
    {
        //cargamos la lista de usuarios
        usuariosLista = await _usuarioS.GetLista();
    }


}
