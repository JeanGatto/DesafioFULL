using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Desafio.Web.Models
{
    public class DividaModel
    {
        [Display(Name = "Número do título")]
        [Required(ErrorMessage = "É necessário informar o número do título.")]
        public string Numero { get; set; }

        [Display(Name = "% de multa")]
        [Required(ErrorMessage = "É necessário informar o valor da multa.")]
        public decimal Multa { get; set; }

        [Display(Name = "% de juros")]
        [Required(ErrorMessage = "É necessário informar o valor do juros ao mês.")]
        public decimal JurosAoMes { get; set; }

        [Display(Name = "Nome do devedor")]
        [Required(ErrorMessage = "É necessário informar o nome.")]
        public string NomeCompleto { get; set; }

        [Display(Name = "CPF do Devedor")]
        [Required(ErrorMessage = "É necessário informar o CPF.")]
        public string CPF { get; set; }

        [Display(Name = "Parcelas")]
        [Required(ErrorMessage = "É necessário informar ao menos uma parcela.")]
        public IEnumerable<ParcelaModel> Parcelas { get; set; }
    }
}
