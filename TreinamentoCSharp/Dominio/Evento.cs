using System;

namespace TreinamentoCSharp.Dominio
{
    public class Evento : Base
    {
        private DateTime dataInicio;
        private DateTime dataFim;
        private int salaId;

        public Evento(int salaId, string nome, DateTime dataInicio, DateTime dataFim)
        {
            SalaId = salaId;
            this.Nome = nome;
            this.DataInicio = dataInicio;
            this.DataFim = dataFim;
            this.DataCadastro = DateTime.Now;
        }

        public int SalaId { get; private set; }
        public string Nome { get; private set; }
        public DateTime DataInicio { get; private set; }
        public DateTime DataFim { get; private set; }
        public DateTime DataCadastro { get; private set; }

        public void AlterarSalaId(int salaId)
        {
            this.SalaId = salaId;
        }
        public void AlterarNome(string nome)
        {
            this.Nome = nome.Trim().ToUpper();
        }
        public void AlterarDataInicio(DateTime dataInicio)
        {
            this.DataInicio = dataInicio;
        }
        public void AlterarDataFim(DateTime dataFim)
        {
            this.DataFim = dataFim;
        }
    }
}