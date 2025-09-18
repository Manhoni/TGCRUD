 // === Executa DELETE simples, capturando trigger do PostgreSQL ===
 public static bool ExecuteDelete(string query, Dictionary<string, object> parametros)
 {
     using var conn = GetConnection();
     conn.Open();

     try
     {
         using var cmd = new NpgsqlCommand(query, conn);
         foreach (var param in parametros)
             cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);

         int rowsAffected = cmd.ExecuteNonQuery();
         return rowsAffected > 0;
     }
     catch (PostgresException ex)
     {
         // aqui já captura o erro da trigger
         throw new Exception($"Erro ao excluir: {ex.Message}");
     }
 }