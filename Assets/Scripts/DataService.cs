using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class DataService : ConnectionBase
{
    public void CreateTable<T>()
    {
        var props = typeof(T).GetProperties();
        IDbCommand command = Connection.CreateCommand();

        command.CommandText = $"CREATE TABLE IF NOT EXISTS {typeof(T).Name} " +
            $"(Id INTEGER PRIMARY KEY, ";

        foreach (var prop in props.Where(p => p.Name != "Id"))
        {
            command.CommandText += $"{prop.Name} {MapType(prop.PropertyType)}, ";
        }

        TrimCommand(command);
        command.CommandText += ")";

        ExecuteNonQuery(command);
    }

    public void Create<T>(T model)
    {
        var props = typeof(T).GetProperties();
        IDbCommand command = Connection.CreateCommand();

        command.CommandText = $"INSERT INTO {typeof(T).Name} (";

        foreach (var prop in props.Where(p => p.Name != "Id"))
        {
            command.CommandText += $"{prop.Name}, ";
        }

        TrimCommand(command);
        command.CommandText += ") VALUES ( ";

        foreach (var prop in model.GetType().GetProperties().Where(p => p.Name != "Id"))
        {
            command.CommandText += $"'{prop.GetValue(model)}', ";
        }

        TrimCommand(command);
        command.CommandText += ")";

        ExecuteNonQuery(command);
    }

    public List<SudokuGame> ReadSudokuGames()
    {
        var command = InitRead<SudokuGame>();

        List<SudokuGame> results = new List<SudokuGame>();

        IDataReader reader;
        using (var con = command.Connection)
        {
            con.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Debug.Log($"{reader.GetValue(0)} {reader.GetValue(1)} {reader.GetValue(2)} {reader.GetValue(3)} {reader.GetValue(4)} ");

                results.Add(new SudokuGame
                {
                    Id = reader.GetInt32(0),
                    Time = TimeSpan.Parse(reader.GetString(1)),
                    Seed = reader.GetInt32(2),
                    Attempt = reader.GetInt32(3),
                    Solved = Convert.ToBoolean(reader.GetValue(4))
                });
            }
            con.Close();
        }

        return results;
    }

    public int GetAttemptCount(int seed)
    {
        var command = Connection.CreateCommand();
        command.CommandText = $"SELECT COUNT(Seed) FROM SudokuGame WHERE Seed = {seed}";
        IDataReader reader;

        int result = 0;

        using (var con = command.Connection)
        {
            con.Open();
            reader = command.ExecuteReader();
            reader.Read();
            result = reader.GetInt32(0);
            con.Close();
        }

        return result;
    }

    internal void ClearCurrent()
    {
        IDbCommand command = Connection.CreateCommand();
        command.CommandText = "DELETE FROM CurrentGame";
        ExecuteNonQuery(command);
    }

    public CurrentGame ReadCurrentGame()
    {
        var command = InitRead<CurrentGame>();

        CurrentGame result = null;

        IDataReader reader;
        using (var con = command.Connection)
        {
            con.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Debug.Log($"{reader.GetValue(0)} {reader.GetValue(1)} {reader.GetValue(2)} {reader.GetValue(3)}");

                result = new CurrentGame
                {
                    Id = reader.GetInt32(0),
                    Seed = reader.GetInt32(1),
                    State = reader.GetString(2),
                    Timer = TimeSpan.Parse(reader.GetString(3))
                };
            }
            con.Close();
        }

        return result;
    }

    private IDbCommand InitRead<T>() {
        var props = typeof(T).GetProperties();
        IDbCommand command = Connection.CreateCommand();

        command.CommandText = $"SELECT ";

        foreach (var prop in props)
        {
            command.CommandText += $"{prop.Name}, ";
        }

        TrimCommand(command);
        command.CommandText += $" FROM {typeof(T).Name}";
        return command;
    }

    private void TrimCommand(IDbCommand command)
    {
        command.CommandText = command.CommandText.Trim();
        command.CommandText = command.CommandText.TrimEnd(',');
    }

    private string MapType(Type type)
    {
        switch (type.Name)
        {
            case "Int32": return "INTEGER";
            case "Boolean": return "INTEGER";
            default: return "TEXT";
        }
    }

    private void ExecuteNonQuery(IDbCommand command)
    {
        using (var con = command.Connection)
        {
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }
    }
}

