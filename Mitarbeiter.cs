public class Mitarbeiter
{
     public string Name { get; set; }
     public string Nachname { get; private set;} 
     public int Urlaubstage { get; private set; }
     public List<DateTime> Krankheitstage { get; private set; } 

  public Mitarbeiter( string Name, string Nachname, int Urlaubstage )

    this.Name = Name;
    this.Nachname = Nachname;
    this.Urlaubstage = Urlaubstage;
    this.Krankheitstage = new List<DateTime>();

  public void AddKrankheitstag(DateTime Krankheitstag)
  {
    Krankheitstage.Add(Krankheitstag);
  }
}
