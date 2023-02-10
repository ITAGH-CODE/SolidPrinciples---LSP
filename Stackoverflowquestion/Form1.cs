namespace Stackoverflowquestion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int val1, val2;
            int.TryParse(textBox1.Text, out val1);
            int.TryParse(textBox2.Text, out val2);

            textBox3.Text = (val1 + val2).ToString();
        }

        protected void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text) && String.IsNullOrEmpty(textBox2.Text))
            {
                textBox3.Text = Convert.ToString(Convert.ToInt32(textBox1.Text) + Convert.ToInt32(textBox2.Text) / 2).ToString();
            }

        }
    }
}