using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACT.DFAssist.Data
{
	public partial class MainForm : Form
	{
		private string _workingdir;
		private SqlTask _sk;

		public MainForm()
		{
			InitializeComponent();

#if DEBUG
			_workingdir = @"F:\WORKSPC\ACT.DFAssist.Data";
#else
			_workingdir=Environment.CurrentDirectory;
			btnTest.Visible = false;
#endif


			_sk = new SqlTask(_workingdir + @"\GameData.sqlite");

			//
			ActiveControl = null;
			SetStyle(ControlStyles.Selectable, false);

			lstLang.SelectedIndex = 0;
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{

		}

		private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			//_sk?.Close();
		}

		internal void InvokeTextResult(string s)
		{
			if (txtResult.InvokeRequired)
			{
				txtResult.Invoke(new MethodInvoker(
					delegate ()
					{
						txtResult.Text = s;
					}));
			}
			else
			{
				txtResult.Text = s;
			}
		}

		internal void InvokeEnableButtons(bool enable)
		{
			if (btnReadGameData.InvokeRequired)
			{
				btnReadGameData.Invoke(new MethodInvoker(
					delegate ()
					{
						btnReadGameData.Enabled = enable;
						btnSave.Enabled = enable;
					}));
			}
			else
			{
				btnReadGameData.Enabled = enable;
				btnSave.Enabled = enable;
			}
		}

		internal void InvokePrgWorkingMaximum(int max)
		{
			if (prgWorking.InvokeRequired)
			{
				prgWorking.Invoke(new MethodInvoker(
					delegate ()
					{
						prgWorking.Maximum = max;
					}));
			}
			else
			{
				prgWorking.Maximum = max;
			}
		}

		internal void InvokePrgWorkingValue(int value)
		{
			if (prgWorking.InvokeRequired)
			{
				prgWorking.Invoke(new MethodInvoker(
					delegate ()
					{
						prgWorking.Value = value;
					}));
			}
			else
			{
				prgWorking.Value = value;
			}
		}

		private void btnTest_Click(object sender, EventArgs e)
		{
			GameData gd = new GameData(_workingdir + @"\ACT", "en");

			var t = new Task(() =>
			{
				//_sk.InsertGameData(gd, this);
			});
			t.Start();
		}

		private void btnReadGameData_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog()
			{
				Filter = "JSON (*.json)|*.json|모든파일 (*.*)|*.*",
				Title = "파일을 골라주쇼!",
				Multiselect = false,
				CheckFileExists = true,
				CheckPathExists = true,
			};

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				var s = dlg.SafeFileName;
				var li = s.LastIndexOf('.');

				if (li > 0)
				{
					var wh = s.Substring(li - 2, 2).ToLower();

					if (wh == "en" || wh == "ja" || wh == "ko" || wh == "fr" || wh == "de")
					{
						InvokeEnableButtons(false);

						// ㅇㅋ!
						var gd = new GameData(dlg.FileName);

						var t = new Task(() =>
						 {
							 _sk.InsertGameData(gd, this, wh);
						 });
						t.Start();

						return;
					}
				}

				// 뭔가 문제가 있겠지
			}
		}

		private void btnQueryInstance_Click(object sender, EventArgs e)
		{
			var ds = _sk.QueryInstance();
			dgvQuery.AutoGenerateColumns = true;
			dgvQuery.DataSource = ds.Tables[0];
		}

		private void btnQueryRoulette_Click(object sender, EventArgs e)
		{
			var ds = _sk.QueryRoulette();
			dgvQuery.AutoGenerateColumns = true;
			dgvQuery.DataSource = ds.Tables[0];
		}

		private void btnQueryArea_Click(object sender, EventArgs e)
		{
			var ds = _sk.QueryArea();
			dgvQuery.AutoGenerateColumns = true;
			dgvQuery.DataSource = ds.Tables[0];
		}

		private void btnQueryFate_Click(object sender, EventArgs e)
		{
			var ds = _sk.QueryFate();
			dgvQuery.AutoGenerateColumns = true;
			dgvQuery.DataSource = ds.Tables[0];
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			var l = lstLang.SelectedItem.ToString();

			SaveFileDialog dlg = new SaveFileDialog()
			{
				Filter = "Json (*.json)|*.json|Text (*.txt)|*.txt| All (*.*)|*.*",
				InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
				AddExtension = true,
				OverwritePrompt = false,
				FileName = $"dfas.{l}.json",
			};

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				var s = _sk.BuildResult(l);
				File.WriteAllText(dlg.FileName, s, Encoding.UTF8);

				MessageBox.Show("작업 했슴미", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}
	}
}
