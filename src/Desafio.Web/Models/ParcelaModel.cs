using System.ComponentModel.DataAnnotations;

namespace Desafio.Web.Models
{
    public class ParcelaModel
    {
        [Display(Name = "Número da parcela")]
        [Required(ErrorMessage = "É necessário informar o número.")]
        public int Numero { get; set; }

        [Display(Name = "Data de vencimento")]
        [Required(ErrorMessage = "É necessário informar a data de vencimento.")]
        public string DataVencimento { get; set; }

        [Display(Name = "Valor da parcela")]
        [Required(ErrorMessage = "É necessário informar o valor.")]
        public string Valor { get; set; }
    }
}