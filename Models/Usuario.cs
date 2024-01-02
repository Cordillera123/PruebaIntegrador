﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IntegradorP.Models;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    [Required(ErrorMessage = "El nombre es requerido")]
    public string NombreUsu { get; set; }

    [Required(ErrorMessage = "La cédula es requerida")]
    public string CedulaUsu { get; set; }

    [Required(ErrorMessage = "El correo electrónico es requerido")]
    [EmailAddress(ErrorMessage = "Correo electrónico no válido")]
    public string EmailUsu { get; set; }

    [Required(ErrorMessage = "La contraseña es requerida")]
    public string Password { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();

    public virtual ICollection<UsuarioPerfil> UsuarioPerfils { get; set; } = new List<UsuarioPerfil>();
}
