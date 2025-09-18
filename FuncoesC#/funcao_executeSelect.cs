public static DataTable ExecuteSelect(string query)
{
    using var conn = GetConnection();
    conn.Open();

    using var cmd = new NpgsqlCommand(query, conn);
    using var da = new NpgsqlDataAdapter(cmd);
    var dt = new DataTable();
    da.Fill(dt);
    return dt;
}