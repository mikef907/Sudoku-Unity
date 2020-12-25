using Mono.Data.Sqlite;
using System;
using System.Data;
using UnityEngine;

abstract public class ConnectionBase: IDisposable
{
    private readonly string connection = $"URI=file:{Application.persistentDataPath}/sudoku.db3";
    private bool disposedValue;

    protected IDbConnection Connection { get => new SqliteConnection(connection); }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                Connection.Close();
                Connection.Dispose();
            }
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
