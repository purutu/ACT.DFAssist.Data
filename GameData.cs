using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACT.DFAssist.Data
{
	class GameData
	{
		public class Instance
		{
			public int Id { get; set; }
			public string Name { get; set; }
			public byte Tank { get; set; }
			public byte Healer { get; set; }
			public byte Dps { get; set; }
			public bool PvP { get; set; }
		}

		public class Roulette
		{
			public string Name { get; set; }

			public static explicit operator Roulette(string name)
			{
				return new Roulette { Name = name };
			}
		}

		public class Area
		{
			public string Name { get; set; }
			public IReadOnlyDictionary<int, Fate> Fates { get; set; }
		}

		public class Fate
		{
			public Area Area { get; set; }
			public string Name { get; set; }
			public bool Special { get; set; }

			public static explicit operator Fate(string name)
			{
				return new Fate { Name = name };
			}
		}

		public class Group
		{
			public decimal Version { get; set; }
			public Dictionary<int, Instance> Instances { get; set; }
			public Dictionary<int, Roulette> Roulettes { get; set; }
			public Dictionary<int, Area> Areas { get; set; }
		}

		public decimal Version { get; private set; }

		public IReadOnlyDictionary<int, Area> Areas { get; private set; } = new Dictionary<int, Area>();
		public IReadOnlyDictionary<int, Instance> Instances { get; private set; } = new Dictionary<int, Instance>();
		public IReadOnlyDictionary<int, Roulette> Roulettes { get; private set; } = new Dictionary<int, Roulette>();
		public IReadOnlyDictionary<int, Fate> Fates { get; private set; } = new Dictionary<int, Fate>();

		public GameData(string path, string lang)
		{
			var file = string.Concat("gamedata-", lang, ".json");
			var name = Path.Combine(path, file);

			var json = File.ReadAllText(name, System.Text.Encoding.UTF8);
			Fill(json);
		}

		public GameData(string filename)
		{
			var json = File.ReadAllText(filename, System.Text.Encoding.UTF8);
			Fill(json);
		}

		private void Fill(string json)
		{
			if (string.IsNullOrWhiteSpace(json))
				return;

			try
			{
				var data = JsonConvert.DeserializeObject<Group>(json);
				var version = data.Version;

				if (version > decimal.Truncate(Version))
				{
					var fates = new Dictionary<int, Fate>();
					foreach (var area in data.Areas)
					{
						foreach (var fate in area.Value.Fates)
						{
							fate.Value.Area = area.Value;
							fate.Value.Special = fate.Value.Name.StartsWith("SP:");
							fates.Add(fate.Key, fate.Value);
						}
					}

					Areas = data.Areas;
					Instances = data.Instances;
					Roulettes = data.Roulettes;
					Fates = fates;
					Version = version;
				}
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.ToString());
			}
		}
	}
}
