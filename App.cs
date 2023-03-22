namespace WrdEditor
{
	public partial class App : Form
	{
		MainWindow mw;
		public App()
		{
			InitializeComponent();
		}

		public void Init()
		{
			mw = new MainWindow();
			mw.ShowDialog();
		}
	}
}