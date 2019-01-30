using System.ComponentModel.DataAnnotations;

namespace AgendaClinicaVivaEstetica.Dominio.Enumeradores
{
    public enum EnumTipoServico
    {
        [Display(Name = "Massagem de 30 minutos")]
        Massagem30Minutos,
        [Display(Name = "Massagem de 1 hora")]
        Massagem1Hora,
        [Display(Name = "Outros")]
        Outros
    }
}
