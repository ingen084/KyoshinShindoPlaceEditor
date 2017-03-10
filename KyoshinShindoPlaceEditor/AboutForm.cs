using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace KyoshinShindoPlaceEditor
{
	public partial class AboutForm : Form
	{
		public AboutForm()
		{
			InitializeComponent();
		}

		private void AboutForm_Load(object sender, EventArgs e)
		{
			label2.Text = "バージョン: " + Assembly.GetExecutingAssembly().GetName().Version;
		}

		private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
			=> Process.Start("https://twitter.com/ingen084");

		private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
			=> Process.Start("http://www.ingen084.net/");

		private void LinkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
			=> Process.Start("mailto:ingen188@gmail.com");

		private void LinkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
			=> Process.Start("http://steamcommunity.com/profiles/76561198121018552");

		private void LinkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
			=> Process.Start("http://www.kyoshin.bosai.go.jp/kyoshin/");

		private void LinkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
			=> Process.Start("http://www.geocities.jp/eqwatch2012/");

		private void LinkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
			=> Process.Start("http://compo031.daiwa-hotcom.com/wordpress/?p=29");
	}
}