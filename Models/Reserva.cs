namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // Código Implementado            
            
            if (Suite.Capacidade >= hospedes.Count())
            {
                Hospedes = hospedes;
            }
            else
            {
                // Código implementado
                throw new ArgumentException("\n\tA quantidade de Hospedes é maior que a capacidade da suíte!" +
                                            "\n\tSelecione outra suíte!");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // Código Implementado

            return Hospedes.Count();
        }

        public decimal CalcularValorDiaria()
        {
            // Código implementado
            decimal valor = Suite.ValorDiaria;

            // Código Implementado
            if (DiasReservados >= 10)
            {
                valor = (DiasReservados * valor) * 0.9M;
            }
            else
            {
                valor = DiasReservados * valor;
            }

            return valor;
        }
    }
}