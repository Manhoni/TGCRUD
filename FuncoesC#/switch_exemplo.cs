// INSERIR CLIENTE
private void btnInserir_Click(object sender, RoutedEventArgs e)
{
    var parametros = new Dictionary<string, object>
    {
        {"@p_nome", txtNome.Text},
        {"@p_cpf", txtCPF.Text},
        {"@p_email", txtEmail.Text},
        {"@p_telefone", txtTelefone.Text}
    };

    int result = DataService.ExecuteFunction("inserir_cliente", parametros);

    switch (result)
    {
        case 0:
            MessageBox.Show("Cliente cadastrado com sucesso.");
            CarregarClientes();
            LimparCampos();
            break;
        case -100:
            MessageBox.Show("Erro: Nome inválido.");
            break;
        case -101:
            MessageBox.Show("Erro: CPF inválido.");
            break;
        case -102:
            MessageBox.Show("Erro: CPF já cadastrado.");
            break;
        default:
            MessageBox.Show("Erro desconhecido. Código: " + result);
            break;
    }
}