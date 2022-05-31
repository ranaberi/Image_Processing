namespace Image_Processing
{
    public partial class Form1 : Form
    {
        Bitmap SRC_IMG, DEST_IMG, Temp_IMG;

        private void button1_Click(object sender, EventArgs e)
        {
            int[,] K = new int[3, 3];
            K[0, 0] = 1; K[0, 1] = 1; K[0, 2] = 1;
            K[1, 0] = 1; K[1, 1] = 3; K[1, 2] = 1;
            K[2, 0] = 1; K[2, 1] = 1; K[2, 2] = 1;

            for (int x = 1; x < pictureBox1.Image.Width-1; x++)
                for (int y = 1; y < pictureBox1.Image.Height-1; y++)
                {
                    int ResR = 0;
                    int ResG = 0;
                    int ResB = 0;
                    //Convolution
                    for (int i = 0; i < 3; i++)
                        for (int j = 0; j < 3; j++)
                        {
                            ResG += K[i, j]* SRC_IMG.GetPixel(x + i - 1, y + j - 1 ).G;
                            ResB += K[i, j] * SRC_IMG.GetPixel(x + i - 1, y + j - 1).B;
                            ResR += K[i, j] * SRC_IMG.GetPixel(x + i - 1, y + j - 1).R;
                        }
                    ResR = ResR / 11;
                    ResG = ResG / 11;
                    ResB = ResB / 11;

                    //Assign to new image

                    DEST_IMG.SetPixel(x, y, Color.FromArgb(ResR, ResG, ResB));

                    }
                    pictureBox2.Image = DEST_IMG;
                }


        public Form1()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            pictureBox1.Load("C:\\Users\\ranab\\source\\repos\\Image_Processing\\img.jpeg");
            SRC_IMG = new Bitmap(pictureBox1.Image);
            DEST_IMG = new Bitmap(SRC_IMG.Width, SRC_IMG.Height);
            Temp_IMG = new Bitmap(SRC_IMG.Width, SRC_IMG.Height);
        }


    }

        
    }
