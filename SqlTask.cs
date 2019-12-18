using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACT.DFAssist.Data
{
	class SqlTask
	{
		private string _fn;
		private string _cstr;
		private SQLiteConnection _conn;

		public SqlTask(string filename)
		{
			_fn = filename;
			_cstr = $"Data Source = {filename};";

			if (!File.Exists(filename))
				CreateDatabase();
			else
				OpenSql();
		}

		private void OpenSql()
		{
			_conn = new SQLiteConnection(_cstr);
			_conn.Open();
		}

		private void CloseSql()
		{
			_conn?.Close();
			_conn = null;
		}

		private void CreateDatabase()
		{
			SQLiteConnection.CreateFile(_fn);
			OpenSql();

			// 인스턴스
			CreateTableInstance();

			// 루렛
			CreateTableIdName("roulette");

			// 지역
			CreateTableIdName("area");

			// FATE
			CreateTableIdAreaName("fate");
		}

		private void CreateTableInstance()
		{
			int res;
			string s;

			s = "create table instance (Id int primary key, filter varchar(100) default '', Tank int, Healer int, Dps int, Pvp int, nameen varchar(255) default '', nameja varchar(255) default '', nameko varchar(255) default '', namefr varchar(255) default '', namede varchar(255) default '')";
			using (var m = new SQLiteCommand(s, _conn))
				res = m.ExecuteNonQuery();

			s = "create index instance_index_nameen on instance(nameen)";
			using (var m = new SQLiteCommand(s, _conn))
				res = m.ExecuteNonQuery();

			s = "create index instance_index_filter on instance(filter)";
			using (var m = new SQLiteCommand(s, _conn))
				res = m.ExecuteNonQuery();
		}


		private void CreateTableIdName(string table)
		{
			int res;
			string s;

			s = $"create table {table}(id int primary key, nameen varchar(255) default '', nameja varchar(255) default '', nameko varchar(255) default '', namefr varchar(255) default '', namede varchar(255) default '')";
			using (var m = new SQLiteCommand(s, _conn))
				res = m.ExecuteNonQuery();

			s = $"create index {table}_nameen on {table}(nameen)";
			using (var m = new SQLiteCommand(s, _conn))
				res = m.ExecuteNonQuery();
		}

		private void CreateTableIdAreaName(string table)
		{
			int res;
			string s;

			s = $"create table {table}(id int primary key, area int, nameen varchar(255) default '', nameja varchar(255) default '', nameko varchar(255) default '', namefr varchar(255) default '', namede varchar(255) default '')";
			using (var m = new SQLiteCommand(s, _conn))
				res = m.ExecuteNonQuery();

			s = $"create index {table}_area on {table}(area)";
			using (var m = new SQLiteCommand(s, _conn))
				res = m.ExecuteNonQuery();

			s = $"create index {table}_nameen on {table}(nameen)";
			using (var m = new SQLiteCommand(s, _conn))
				res = m.ExecuteNonQuery();
		}

		private void UpdateResultText(MainForm frm, int index, int nins, int nro, int nar, int nfa, int maxins, int maxro, int maxar, int maxfa)
		{
			if ((index % 5) == 0)
			{
				var s =
					$"Instance {nins}/{maxins}\r\n" +
					$"Roulette {nro}/{maxro}\r\n" +
					$"Area {nar}/{maxar}\r\n" +
					$"Fate {nfa}/{maxfa}\r\n";
				frm.InvokeTextResult(s);

				frm.InvokePrgWorkingValue(index);
			}
		}

		//
		internal void InsertGameData(GameData gd, MainForm frm, string wh)
		{
			System.Diagnostics.Debug.WriteLine("데이터 시작");

			int index, nins, nro, nar, nfa;

			index = 0;
			nins = nro = nar = nfa = 0;

			frm.InvokePrgWorkingMaximum(gd.Instances.Count + gd.Roulettes.Count + gd.Areas.Count + gd.Fates.Count);

			// 인스턴스
			foreach (var i in gd.Instances)
			{
				nins++;
				index++;
				UpdateResultText(frm, index, nins, nro, nar, nfa, gd.Instances.Count, gd.Roulettes.Count, gd.Areas.Count, gd.Fates.Count);

				InsertGameDataInstance(wh, i.Key, i.Value);
			}

			// 루렛
			foreach (var i in gd.Roulettes)
			{
				nro++;
				index++;
				UpdateResultText(frm, index, nins, nro, nar, nfa, gd.Instances.Count, gd.Roulettes.Count, gd.Areas.Count, gd.Fates.Count);

				InsertGameDataItemIdName("roulette", wh, i.Key, i.Value.Name);
			}

			// 영역
			foreach (var i in gd.Areas)
			{
				nar++;
				index++;
				UpdateResultText(frm, index, nins, nro, nar, nfa, gd.Instances.Count, gd.Roulettes.Count, gd.Areas.Count, gd.Fates.Count);

				InsertGameDataItemIdName("area", wh, i.Key, i.Value.Name);

				// 페이트
				foreach (var f in i.Value.Fates)
				{
					nfa++;
					index++;
					UpdateResultText(frm, index, nins, nro, nar, nfa, gd.Instances.Count, gd.Roulettes.Count, gd.Areas.Count, gd.Fates.Count);

					InsertGameDataItemIdAreaName("fate", wh, f.Key, i.Key, f.Value.Name);
				}
			}

			// 페이트
			/*foreach (var i in gd.Fates)
			{
				nfa++;
				index++;
				UpdateResultText(frm, index, nins, nro, nar, nfa, gd.Instances.Count, gd.Roulettes.Count, gd.Areas.Count, gd.Fates.Count);

				InsertGameDataItemIdAreaName("fate", wh, i.Key, i.Value.Area, i.Value.Name);
			}*/

			frm.InvokePrgWorkingValue(index);
			//frm.InvokePrgWorkingValue(0);
			frm.InvokeEnableButtons(true);

			System.Diagnostics.Debug.WriteLine("데이터 끝");
		}

		private void InsertGameDataInstance(string wh, int id, GameData.Instance v)
		{
			bool has;
			int res;

			var s = $"select id from instance where id={id}";
			using (var m = new SQLiteCommand(s, _conn))
			{
				var rdr = m.ExecuteReader();
				has = rdr.HasRows;
			}

			// Id , Tank , Healer , Dps , Pvp , nameen , nameja , nameko , namefr , namede 
			if (!has)
			{
				// 만들어
				s = string.Format("insert into instance(id, Tank, Healer, Dps, Pvp, name{0}) values({1},{2},{3},{4},{5},'{6}')",
					wh, id, v.Tank, v.Healer, v.Dps, v.PvP ? 1 : 0, v.Name.Replace('\'', '`'));
				using (var m = new SQLiteCommand(s, _conn))
					res = m.ExecuteNonQuery();
			}
			else
			{
				// 어퍼
				s = string.Format("update instance set Tank={0}, Healer={1}, Dps={2}, Pvp={3}, name{4}='{5}' where Id={6}",
					v.Tank, v.Healer, v.Dps, v.PvP ? 1 : 0, wh, v.Name.Replace('\'', '`'), id);
				using (var m = new SQLiteCommand(s, _conn))
					res = m.ExecuteNonQuery();
			}
		}

		// 
		private void InsertGameDataItemIdName(string table, string wh, int id, string value)
		{
			bool has;
			int res;

			var s = $"select id from {table} where id={id}";
			using (var m = new SQLiteCommand(s, _conn))
			{
				var rdr = m.ExecuteReader();
				has = rdr.HasRows;
			}

			// id , name , nameja , nameko , namefr , namede 
			if (!has)
			{
				s = string.Format("insert into {0}(id, name{1}) values({2}, '{3}')",
					table, wh, id, value.Replace('\'', '`'));
				using (var m = new SQLiteCommand(s, _conn))
					res = m.ExecuteNonQuery();
			}
			else
			{
				s = string.Format("update {0} set name{1}='{2}' where Id={3}",
					table, wh, value.Replace('\'', '`'), id);
				using (var m = new SQLiteCommand(s, _conn))
					res = m.ExecuteNonQuery();
			}
		}

		// 
		private void InsertGameDataItemIdAreaName(string table, string wh, int id, int area, string value)
		{
			bool has;
			int res;

			var s = $"select id from {table} where id={id}";
			using (var m = new SQLiteCommand(s, _conn))
			{
				var rdr = m.ExecuteReader();
				has = rdr.HasRows;
			}

			// id , name , nameja , nameko , namefr , namede 
			if (!has)
			{
				s = string.Format("insert into {0}(id, area, name{1}) values({2}, {3}, '{4}')",
					table, wh, id, area, value.Replace('\'', '`'));
				using (var m = new SQLiteCommand(s, _conn))
					res = m.ExecuteNonQuery();
			}
			else
			{
				s = string.Format("update {0} set name{1}='{2}' where Id={3}",
					table, wh, value.Replace('\'', '`'), id);
				using (var m = new SQLiteCommand(s, _conn))
					res = m.ExecuteNonQuery();
			}
		}

		//
		private DataSet QueryQuery(string qry)
		{
			var sda = new SQLiteDataAdapter(qry, _conn);

			var ds = new DataSet();
			sda.Fill(ds);

			return ds;
		}


		//
		public DataSet QueryInstance()
		{
			var s = "select * from instance order by Id asc";
			return QueryQuery(s);
		}

		//
		public DataSet QueryRoulette()
		{
			var s = "select * from roulette order by Id asc";
			return QueryQuery(s);
		}

		//
		public DataSet QueryArea()
		{
			var s = "select * from area order by Id asc";
			return QueryQuery(s);
		}

		//
		public DataSet QueryFate()
		{
			var s = "select * from fate order by Area asc, Id asc";
			return QueryQuery(s);
		}
	}
}
