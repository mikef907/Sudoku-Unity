using System;


public class SudokuGame
{
    public int Id { get; set; }
    public TimeSpan Time { get; set; }
    public int Seed { get; set; }
    public int Attempt { get; set; }
    public bool Solved { get; set; }
}

public class CurrentGame
{ 
    public int? Id { get; set; }
    public int Seed { get; set; }
    public string State { get; set; }
    public TimeSpan Timer { get; set; }
}


