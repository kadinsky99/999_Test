using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FormTest1
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
 
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            pic.initialize();
            
            //Random rnd = new Random();
            //キャラクターの登録
            pic.List.Add(_Myball);
            for (int i = 0; i < 1; i++)
            {
                Random _randam = new Random();
                int x = _randam.Next(50, pic.Width -100);
                int y =_randam.Next(50, pic.Height - 100);
                int dx = _randam.Next(0, 1) == 0 ? -1 : 1;
                int dy = _randam.Next(0, 1) == 0 ? -1 : 1;
                pic.List.Add(new OtherBall(x, y, dx, dy));
            }
            //pic.List.Add(new OtherBall(100, 100, 10, 10));
            //pic.List.Add(new OtherBall(100, 150, 20, 5));
            //pic.List.Add(new OtherBall(150, 100, 5, 20));
        }

        Ball _Myball = new MyBall(0, 0, 0, 0);
        //タイマーイベント
        private void timer1_Tick(object sender, EventArgs e)
        {
            pic.draw();
        }
        Point _oldPoint = Point.Empty;

        private void pic_MouseMove_1(object sender, MouseEventArgs e)
        {
        }

        private void moveMyball(){
            if (_oldPoint == Point.Empty)
            {
                _oldPoint = Cursor.Position;
                return;
            }

            //左端チェック
            if (_Myball._xy.X < 0)
            {
                _Myball._xy.X = 0;
            }

            //右端チェック
            if (_Myball._xy.X +_Myball._size.Width > pic.Width)
            {
                _Myball._xy.X = pic.Width - _Myball._size.Width;
            }

            //上端チェック
            if (_Myball._xy.Y < 0)
            {
                _Myball._xy.Y = 0;
            }

            //下端チェック
            if (_Myball._xy.Y + _Myball._size.Height > pic.Height)
            {
                _Myball._xy.Y = pic.Height - _Myball._size.Height;
            }

            //移動量算出
            int dx = Cursor.Position.X - _oldPoint.X;
            int dy = Cursor.Position.Y - _oldPoint.Y;

            _Myball._xy.X = _Myball._xy.X + dx;
            _Myball._xy.Y = _Myball._xy.Y + dy;

            _oldPoint = Cursor.Position;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            moveMyball();
        }
        
            
        
            
        }
    }
