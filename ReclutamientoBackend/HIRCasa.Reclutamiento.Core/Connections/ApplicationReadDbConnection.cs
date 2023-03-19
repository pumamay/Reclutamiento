﻿using HIRCasa.Reclutamiento.Core.Contracts;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace HIRCasa.Reclutamiento.Core.Connections;

public class ApplicationReadDbConnection : IApplicationReadDbConnection, IDisposable
{
    private readonly IDbConnection connection;

    public ApplicationReadDbConnection(IConfiguration configuration)
    {
        connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
    }

    public async Task<IReadOnlyList<T>> QueryAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, CancellationToken cancellationToken = default)
    {
        return (await connection.QueryAsync<T>(sql, param, transaction)).AsList();
    }

    public async Task<IEnumerable<TResult>> QueryMapAsync<T1, T2, TResult>(string sql, Func<T1, T2, TResult> map, object? param = null, IDbTransaction? transaction = null, string splitOn = "Id", CancellationToken cancellationToken = default)
    {
        return await connection.QueryAsync(sql, map, param, transaction, true, splitOn);
    }

    public async Task<IEnumerable<TResult>> QueryMapAsync<T1, T2, T3, TResult>(string sql, Func<T1, T2, T3, TResult> map, object? param = null, IDbTransaction? transaction = null, string splitOn = "Id", CancellationToken cancellationToken = default)
    {
        return await connection.QueryAsync(sql, map, param, transaction, true, splitOn);
    }

    public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, CancellationToken cancellationToken = default)
    {
        return await connection.QueryFirstOrDefaultAsync<T>(sql, param, transaction);
    }

    public async Task<T> QuerySingleAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, CancellationToken cancellationToken = default)
    {
        return await connection.QuerySingleAsync<T>(sql, param, transaction);
    }

    public void Dispose()
    {
        connection.Dispose();
    }
}
