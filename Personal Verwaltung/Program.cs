using System; //para poder usar Console.WriteLine()
using System.Collections.Generic; //para usar con List<T>
using System.IO; //Para usar  con File.ReadAllText()
using System.Text.Json;
using System.Linq;

namespace PersonalVerwaltung
{
	internal class Program
	{
		static void Main(string[] args)

		{
			Console.WriteLine("Personalverwaltung gestartet!");

			List<Mitarbeiter> mitarbeiterListe = LoadMitarbeiter();

			while (true)
			{
				Console.WriteLine("1) Mitarbeiter anzeigen");
				Console.WriteLine("2) Mitarbeiter hinzufügen");
				Console.WriteLine("3) Mitarbeiter entfernen");
				Console.WriteLine("4) Beenden");
				Console.Write("Auswahl: ");

				string eingabe = Console.ReadLine();
				Console.WriteLine($"DEBUG eingabe = '{eingabe}', Länge = {eingabe.Length}");

				if (eingabe == "1")
				{
					if (mitarbeiterListe.Count == 0)

						Console.WriteLine("Keine Mitarbeiter vorhanden.");

					else

						foreach (var mitarbeiter in mitarbeiterListe)

							Console.WriteLine($"{mitarbeiter.Name} {mitarbeiter.Nachname}");
					Console.WriteLine($"Urlaubstage: {mitarbeiter.Urlaubstage}");

					if (mitarbeiter.Krankheitstage.Count == 0)

						Console.WriteLine("Krankheitstage: keine");

					else

						Console.WriteLine("Krankheitstage:");

					foreach (var tag in mitarbeiter.Krankheitstage)


						Console.WriteLine($" - {tag.ToShortDateString()}");


					Console.WriteLine();

                }



				else if (eingabe == "2")
				{
					Console.Write("Name: ");
					string name = Console.ReadLine();

					Console.Write("Nachname: ");
					string nachname = Console.ReadLine();

					Console.Write("Urlaubstage: ");
					int urlaubstage = int.Parse(Console.ReadLine());

					Mitarbeiter neuer = new Mitarbeiter(name, nachname, urlaubstage);

					mitarbeiterListe.Add(neuer);

					SaveMitarbeiter(mitarbeiterListe);

					Console.WriteLine("Mitarbeiter hinzugefügt.");

				}

				else if (eingabe == "3")
				{
					Console.Write("Name des Mitarbeiters: ");
					string name = Console.ReadLine();
					Console.Write("Nachname des Mitarbeiters: ");
					string nachname = Console.ReadLine();

					var zuLoeschen = mitarbeiterListe
						.FirstOrDefault(m => m.Name == name && m.Nachname == nachname);

					if (zuLoeschen == null)
					
						Console.WriteLine("Mitarbeiter nicht gefunden.");

					
					else
					
						mitarbeiterListe.Remove(zuLoeschen);
						SaveMitarbeiter(mitarbeiterListe);
						Console.WriteLine("Mitarbeiter gelöscht.");

					
				}

				else if (eingabe == "4")
				{
					SaveMitarbeiter(mitarbeiterListe);
					Console.WriteLine("Programm beendet.");
					break;
				}

				else
				{
					Console.WriteLine("Ungültige Auswahl.");
				}
			}

		}
	
		
		static void SaveMitarbeiter(List<Mitarbeiter> mitarbeiterListe)
		{
			string jsonText = JsonSerializer.Serialize(mitarbeiterListe, new JsonSerializerOptions { WriteIndented = true });
			File.WriteAllText("mitarbeiter.json", jsonText);

		}
		static List<Mitarbeiter> LoadMitarbeiter()

		{
			if (File.Exists("mitarbeiter.json"))
			{
				string jsonText = File.ReadAllText("mitarbeiter.json");
				List<Mitarbeiter>? Liste = JsonSerializer.Deserialize<List<Mitarbeiter>>(jsonText);
				return Liste ?? new List<Mitarbeiter>();
			}
			return new List<Mitarbeiter>();

		
		}

	}
}



