using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Program
{
  static void Main()
  {
    List<Mitarbeiter> mitarbeiterListe = new List<Mitarbeiter>();
  }

  static List<Mitarbeiter> LoadMitarbeiter()
  {
    if (File.Exists("mitarbeiter.json"))
    {
       string jsonText = File.ReadAllText("mitarbeiter.json");
    }
  
}
