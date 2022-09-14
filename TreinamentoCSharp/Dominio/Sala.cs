using System;

namespace TreinamentoCSharp.Dominio
{
    public class Sala : Base
    {
        public Sala(string nome, int capacidade, bool possuiTV, bool possuiProjetor)
        {
            this.Nome = nome.Trim().ToUpper();
            this.Capacidade = capacidade;
            this.PossuiTV = possuiTV;
            this.PossuiProjetor = possuiProjetor;
            this.DataCadastro = DateTime.Now;

        }

        public string Nome { get; private set; }
        public int Capacidade { get; private set; }
        public bool PossuiTV { get; private set; }   
        public bool PossuiProjetor { get; private set; }
        public DateTime DataCadastro { get; private set; }

        public void AlterarNome(string nome)
        {
            this.Nome = nome.Trim().ToUpper();
        }
        public void AlterarCapacidade(int capacidade)
        {
            this.Capacidade = capacidade;
        }
        public void AlterarPossuiTV (bool possuiTV)
        {
            this.PossuiTV = possuiTV;
        }
        public void AlterarProjetor (bool possuiProjetor)
        {
            this.PossuiProjetor = possuiProjetor;
        }
    }
}