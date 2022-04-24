using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using ModeloE;
using ProyectoGolosinas.Interfaces;

namespace ProyectoGolosinas.Pages.Usuario;

partial class EditarUsuario
{
    //Etiqueta
    [Inject] private IUsuarioS _usuarioS { get; set; }//Acceder a los metodos 
    [Inject] NavigationManager _navigationManager { get; set; }
    [Inject] SweetAlertService Swal { get; set; }
    //Variable que almacena el parametro
    [Parameter] public string Codigo { get; set; }
    

    //Objeto de la clase Usuario 
    Usuarios user = new Usuarios();
    //Metodo para consultar a la base de Datos 

    protected override async Task OnInitializedAsync()
    {
        //Validar que el Usuario Seleccione la ruta correcta
        if (!string.IsNullOrEmpty(Codigo))
        {
            //Para almacenar el objeto del Usuario
            user = await _usuarioS.GetPorCodigo(Codigo);
        }
    }
    //Metodo para Guardar 
    protected async Task Guardar()
    {
        if (string.IsNullOrEmpty(user.Codigo) || string.IsNullOrEmpty(user.Nombre) || string.IsNullOrEmpty(user.Rol) || user.Rol == "Seleccionar")
        {
            return;
        }

        bool edito = await _usuarioS.Actualizar(user);
        if (edito)
        {
            await Swal.FireAsync("Felicidades", "Usuario actualizado con exito", SweetAlertIcon.Success);
        }
        else
        {
            await Swal.FireAsync("Error", "Usuario no se pudo actualizar", SweetAlertIcon.Error);
        }
        _navigationManager.NavigateTo("/Usuarios");

        //Nos manda a la ruta Usuarios
        _navigationManager.NavigateTo("/Usuarios");
    }
    protected async Task Cancelar()
        //Llamar metodos
        {
        //retorna a la vista anterior 
        _navigationManager.NavigateTo("/Usuarios");
    }

protected async Task Eliminar()
    {
        bool elimino = false;

        SweetAlertResult resultado = await Swal.FireAsync(new SweetAlertOptions
        {
            Title = "¿Seguro que quiere eliminar el registro?",
            Icon = SweetAlertIcon.Question,
            ShowCancelButton = true,
            ConfirmButtonText = "Aceptar",
            CancelButtonText = "Cancelar"
        });

        if (!string.IsNullOrEmpty(resultado.Value))
        {
            elimino = await _usuarioS.Eliminar(user);

            if (elimino)
            {
                await Swal.FireAsync("Felicidades", "Usuario eliminado con exito", SweetAlertIcon.Success);
                _navigationManager.NavigateTo("/Usuarios");
            }
            else
            {
                await Swal.FireAsync("Error", "Usuario no se pudo eliminar", SweetAlertIcon.Error);
            }
        }
    }

}

    //claves o valores constantes
    enum Roles
    {
        Seleccionar,
        Administrador, 
        Usuario
    }


