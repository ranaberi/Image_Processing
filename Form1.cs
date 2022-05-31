namespace Image_Processing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap SRC_IMG, DEST_IMG, Temp_IMG;

        private void button7_Click(object sender, EventArgs e)
        {
            pictureBox1.Load("C:\\Users\\ranab\\source\\repos\\Image_Processing\\img.jpg");
            SRC_IMG = new Bitmap(pictureBox1.Image);
            DEST_IMG = new Bitmap(SRC_IMG.Width, SRC_IMG.Height);
            Temp_IMG = new Bitmap(SRC_IMG.Width, SRC_IMG.Height);
        }



        private void button1_Click(object sender, EventArgs e)
        {
            double[,] K = new double[3, 3];
            K[0, 0] = 1 / 11.0; K[0, 1] = 1 / 11.0; K[0, 2] = 1 / 11.0;
            K[1, 0] = 1 / 11.0; K[1, 1] = 3 / 11.0; K[1, 2] = 1 / 11.0;
            K[2, 0] = 1 / 11.0; K[2, 1] = 1 / 11.0; K[2, 2] = 1 / 11.0;
            Convolution(K);
            pictureBox2.Image = DEST_IMG;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            double[,] K = new double[3, 3];
            K[0, 0] = 0.0275; K[0, 1] = 0.1102; K[0, 2] = 0.0275;
            K[1, 0] = 0.1102; K[1, 1] = 0.4421; K[1, 2] = 0.1102;
            K[2, 0] = 0.0275; K[2, 1] = 0.1102; K[2, 2] = 0.0275;
            Convolution(K);
            pictureBox2.Image = DEST_IMG;
        }

        private void Convolution(double[,] K)
        {
            for (int x = 1; x < pictureBox1.Image.Width - 1; x++)
                for (int y = 1; y < pictureBox1.Image.Height - 1; y++)
                {
                    int ResR = 0;
                    int ResG = 0;
                    int ResB = 0;
                    //Convolution
                    for (int i = 0; i < 3; i++)
                        for (int j = 0; j < 3; j++)
                        {
                            ResG += (int)(K[i, j] * SRC_IMG.GetPixel(x + i - 1, y + j - 1).G);
                            ResB += (int)(K[i, j] * SRC_IMG.GetPixel(x + i - 1, y + j - 1).B);
                            ResR += (int)(K[i, j] * SRC_IMG.GetPixel(x + i - 1, y + j - 1).R);
                        }

                    //Assign to new image

                    DEST_IMG.SetPixel(x, y, Color.FromArgb(ResR, ResG, ResB));

                }
        }




    }
}
