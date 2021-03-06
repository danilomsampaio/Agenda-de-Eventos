//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Agenda.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class agdUsuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public agdUsuario()
        {
            this.agdContato = new HashSet<agdContato>();
        }

        public int agdUsuarioID { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Esse campo � obrigat�rio")]
        [EmailAddress(ErrorMessage = "Endere�o de Email Invalido!!")]
        [StringLength(254, ErrorMessage = "O campo deve conter no m�ximo 254 caracteres!!")]
        public string ausEmail { get; set; }

        [Required(ErrorMessage = "Esse campo � obrigat�rio")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        [StringLength(12, MinimumLength = 4, ErrorMessage = "O campo deve conter entre 4 a 12 caracteres!!")]
        public string ausSenha { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<agdContato> agdContato { get; set; }
    }
}