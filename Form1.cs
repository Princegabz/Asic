namespace Asic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public static int Read()
        {
            int Count = 0;
            using (StreamReader reader = new StreamReader(@"Products.txt"))
            {
                string fileContent = reader.ReadToEnd();
                Count = fileContent.Length;
                Thread.Sleep(5000);  
            }
                return Count;
        }
       
        private async void btnProcess_Click_1(object sender, EventArgs e) //Will bve used in task 2
        {
            Task<int> task = new Task<int>(Read);

            task.Start();
            lblState.Text = "File processing. lease wait...";
            MessageBox.Show("This has been run by the main thread");

            int count = await task;
            lblCount.Text = count.ToString();

            lblState.Text = "Number of chars in file";
        }
    }
}