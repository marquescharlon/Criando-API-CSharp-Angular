using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace TreinamentoCSharp.Model
{
    public class EventoModel : ValidationAttribute
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Còdigo da Sala Obrigatório")]
        public int SalaId { get; set; }

        [Required(ErrorMessage = "Nome obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Data de Início Obrigatória")]
        public DateTime DataInicio { get; set; }
        
        [Required(ErrorMessage = "Data do Término Obrigatória")]
        public DateTime DataFim { get; set; }
        public string SalaI { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            EventoModel eventView = (EventoModel)validationContext.ObjectInstance;

            return ValidationResult.Success;
        }

    }
}