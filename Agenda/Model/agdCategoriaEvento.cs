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

    public partial class agdCategoriaEvento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public agdCategoriaEvento()
        {
            this.agdEvento = new HashSet<agdEvento>();
        }

        public int agdCategoriaEventoID { get; set; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "Esse campo � obrigat�rio")]
        [StringLength(50, ErrorMessage = "O campo deve conter no m�ximo 50 caracteres!!")]
        public string aceNome { get; set; }

        [Display(Name = "Cor")]
        public string aceCor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<agdEvento> agdEvento { get; set; }
    }
}