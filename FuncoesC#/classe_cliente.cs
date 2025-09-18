namespace CrudApp.Models
{
    public class Cliente
    {
        public int Cliente_Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public int? Pedido_Id { get; set; }        // pode ser nulo se nao tiver pedido
        public DateTime? Data_Pedido { get; set; } // pode ser nulo
        public decimal? Valor_Total { get; set; }  // pode ser nulo
    } 
}
