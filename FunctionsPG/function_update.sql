CREATE OR REPLACE FUNCTION atualizar_cliente(
    p_cliente_id INT,
    p_nome VARCHAR,
    p_email VARCHAR,
    p_telefone VARCHAR
) RETURNS INT AS $$
DECLARE
    v_qtde INT;
BEGIN
    -- Cliente precisa existir
    SELECT COUNT(*) INTO v_qtde FROM Clientes WHERE cliente_id = p_cliente_id;
    IF v_qtde = 0 THEN
        RETURN -200; -- Cliente não encontrado
    END IF;

    -- Nome não pode ser vazio
    IF p_nome IS NULL OR LENGTH(TRIM(p_nome)) = 0 THEN
        RETURN -201; -- Nome inválido
    END IF;

    -- Atualiza cliente
    UPDATE Clientes
    SET nome = p_nome,
        email = p_email,
        telefone = p_telefone
    WHERE cliente_id = p_cliente_id;

    RETURN 0; -- Sucesso

EXCEPTION
    WHEN others THEN
        RETURN -999; -- Erro genérico
END;
$$ LANGUAGE plpgsql;
