using System.Security.Cryptography;

namespace WinFormsApp4
{
    public partial class Form1 : Form
    {     
        Random random = new Random();

        //wie¿e z kr¹¿kami:
        List<Disc>[] towers = new List<Disc>[3];

        public Form1()
        {
            InitializeComponent();

            towers[0] = new List<Disc>();
            towers[1] = new List<Disc>();
            towers[2] = new List<Disc>();

            InitTowers();
        }

        void InitTowers()
        {
            towers[0].Clear();
            towers[1].Clear();
            towers[2].Clear();

            towers[0].Add(new Disc(100, Color.Red));
            towers[0].Add(new Disc(90, Color.Green));
            towers[1].Add(new Disc(80, Color.Blue));
            towers[2].Add(new Disc(70, Color.Yellow));
        }

        public void MoveDisc(int src, int dsc)
        {
            if (src == dsc)
                return;
            if (towers[src].Count == 0)
                return;

            Disc disc = towers[src].Last();
            towers[src].RemoveAt(towers[src].Count - 1);
            towers[dsc].Add(disc);

            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;


            g.DrawString("Wie¿e Hanoi", DefaultFont, Brushes.Purple, 0, 0);

            g.TranslateTransform(pictureBox1.Width / 2, 4*pictureBox1.Height/5);
            g.ScaleTransform(1, -1);

            g.DrawLine(new Pen(Color.Black, 10), -200, 0, 200, 0);
            g.DrawLine(new Pen(Color.Black, 5), -100, 0, -100, 150);
            g.DrawLine(new Pen(Color.Black, 5),    0, 0,    0, 150);
            g.DrawLine(new Pen(Color.Black, 5),  100, 0,  100, 150);



            //Rysujemy wie¿e nr 0
            for (int i =0; i < towers[0].Count; i++)
            {
                Disc disc = towers[0][i];
                g.DrawLine(new Pen(disc.color, 10), -100-disc.width/2, 10+10*i, -100 + disc.width / 2, 10+10*i);
            }

            //Rysujemy wie¿e nr 1
            for (int i = 0; i < towers[1].Count; i++)
            {
                Disc disc = towers[1][i];
                g.DrawLine(new Pen(disc.color, 10), 0 - disc.width / 2, 10 + 10 * i, 0 + disc.width / 2, 10 + 10 * i);
            }

            //Rysujemy wie¿e nr 2
            int h = 10;
            foreach (Disc disc in towers[2])
            {
                g.DrawLine(new Pen(disc.color, 10), +100 - disc.width / 2, h, +100 + disc.width / 2, h);
                h+=10;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int src = (int)numericUpDown1.Value;
            int dst = (int)numericUpDown2.Value;

            MoveDisc(src, dst);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int src = random.Next(3);
            int dst = random.Next(3);

            MoveDisc(src, dst);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            InitTowers();

            pictureBox1.Invalidate();
        }
    }
}