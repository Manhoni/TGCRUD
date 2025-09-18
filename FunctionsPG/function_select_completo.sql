CREATE OR REPLACE FUNCTION selecionar_clientes_completo()
RETURNS TABLE (
    cliente_id INT,
    nome VARCHAR,
    cpf VARCHAR,
    email VARCHAR,
    telefone VARCHAR,
    rua VARCHAR,
    numero VARCHAR,
    cidade VARCHAR,
    estado VARCHAR,
    cep VARCHAR,
    pedido_id INT,
    data_pedido DATE,
    valor_total DECIMAL(10,2)
) AS $$
BEGIN
    RETURN QUERY
    SELECT
        c.cliente_id,
        c.nome,
        c.cpf,
        c.email,
        c.telefone,
        e.rua,
        e.numero,
        e.cidade,
        e.estado,
        e.cep,
        p.pedido_id,
        p.data_pedido,
        p.valor_total
    FROM Clientes c
    LEFT JOIN Enderecos e ON c.cliente_id = e.cliente_id
    LEFT JOIN Pedidos p ON c.cliente_id = p.cliente_id
    ORDER BY c.nome, p.data_pedido;
END;
$$ LANGUAGE plpgsql;
