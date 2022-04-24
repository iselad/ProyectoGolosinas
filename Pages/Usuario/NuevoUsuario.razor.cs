using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using ModeloE;
using ProyectoGolosinas.Interfaces;

namespace ProyectoGolosinas.Pages.Usuario;

partial class NuevoUsuario
{
    [Inject] private IUsuarioS sUsuario { get; set; }
    [Inject] private NavigationManager navigationManager { get; set; }
    [Inject] SweetAlertService Swal { get; set; }
    private Usuarios user = new Usuarios();
    //Metodo para Guardar 
    protected async Task Guardar()
    {
        if (string.IsNullOrEmpty(user.Codigo) || string.IsNullOrEmpty(user.Nombre) || string.IsNullOrEmpty(user.Rol) || user.Rol == "Seleccionar")
        {
            return;
        }

        bool inserto = await sUsuario.Nuevo(user);
        if (inserto)
        {
            await Swal.FireAsync("Felicidades", "Usuario Creado con exito", SweetAlertIcon.Success);
        }
        else
        {
            await Swal.FireAsync("Error", "Usuario no se pudo Crear", SweetAlertIcon.Error);
        }
        navigationManager.NavigateTo("/Usuarios");

        //Nos manda a la ruta Usuarios
        navigationManager.NavigateTo("/Usuarios");
    }
    protected async Task Cancelar()
    {
        navigationManager.NavigateTo("/Usuarios");
    }
    }

