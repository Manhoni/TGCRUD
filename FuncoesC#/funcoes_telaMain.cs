// DELETAR CLIENTE
private void btnDeletar_Click(object sender, RoutedEventArgs e)
{
    if (string.IsNullOrWhiteSpace(txtClienteId.Text))
    {
        MessageBox.Show("Selecione um cliente para excluir.");
        return;
    }

    var parametros = new Dictionary<string, object>
    {
        {"@id", int.Parse(txtClienteId.Text)}
    };

    try
    {
        bool ok = DataService.ExecuteDelete("DELETE FROM Clientes WHERE cliente_id = @id", parametros);
        MessageBox.Show(ok ? "Cliente excluído com sucesso." : "Nenhum cliente encontrado.");
        CarregarClientes();
        LimparCampos();
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message); // aqui já mostra o erro do trigger
    }
}

// CONSULTAR CLIENTES + PEDIDOS
private void btnConsultar_Click(object sender, RoutedEventArgs e)
{
    CarregarClientes();
}

private void CarregarClientes()
{
    dgClientes.ItemsSource = DataService.ExecuteSelect("SELECT * FROM selecionar_clientes_completo()").DefaultView;
}

// Quando seleciona no grid, preenche os campos
private void dgClientes_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
{
    if (dgClientes.SelectedItem is DataRowView row)
    {
        txtClienteId.Text = row["cliente_id"].ToString();
        txtNome.Text = row["nome"].ToString();
        txtCPF.Text = row["cpf"].ToString();
        txtEmail.Text = row["email"].ToString();
        txtTelefone.Text = row["telefone"].ToString();
    }
}