using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.Encodings.Web;

namespace ContactosWebApp.Models
{
    public class Contacto
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int IdContacto { get; set; }

        [DisplayName("Nombre")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El nombre del contacto es un dato requerido")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "El nombre debe contener entre 2 y 30 caracteres")]
        public string? Nombre { get; set; }

        [DisplayName("Dirección")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "La dirección del contacto es un dato requerido")]
        public string? Direccion { get; set; }

        [DisplayName("Correo")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El correo es un dato requerido")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                            ErrorMessage = "La dirección de correo electrónico ingresada no es válida")]
        [DataType(DataType.EmailAddress)]
        public string? Correo { get; set; }

        [DisplayName("Teléfono Movil")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El telefono movil del contacto es un dato requerido")]
        public string? TelefonoMovil { get; set; }

        [DisplayName("Teléfono Casa")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El telefono movil del contacto es un dato requerido")]
        public string? TelefonoCasa { get; set; }

    }
}
