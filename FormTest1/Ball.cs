using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    

namespace FormTest1
{
    class Ball:ICharacter
    {
        //位置
        public Point _xy = new Point();

        //サイズ
        public Size _size = new Size();

        //色
        int _color = 0; //0:自機　1:敵
        public const int _MyBall = 0;
        public const int _OtherBall = 1;

        //ボールの個数を決定
        Random _rnd = new Random();

        Vector _vector = new Vector(10,10);
        public void draw(Graphics g)
        {
            Brush brush;
            Pen pen;

            if (_color == 0)
            {
                brush = Brushes.Aquamarine;
                pen = Pens.Aqua;
            }else{
                brush = Brushes.BlueViolet;
                pen = Pens.BurlyWood;
            }

            //g.DrawLine(Pens.Aqua, _xy.X,_xy.Y, 100, 100);
            g.FillEllipse(brush, _xy.X, _xy.Y, _size.Width, _size.Height);
            g.DrawEllipse(pen, _xy.X, _xy.Y, _size.Width, _size.Height);
        }
        


        //コンストラクタ
        public Ball(int color, int x, int y, int dx, int dy)
        {
            _xy = new Point(x, y);
            _size = new Size(50, 50);
            _vector = new Vector(dx, dy);
            _color = color;
        }

        //アニメーション
        public void Animation(CharacterPictureBox pic)
        {
            _xy.X = _xy.X + _vector.dx;
            _xy.Y = _xy.Y + _vector.dy;

            //右端かどうか
            if (_xy.X + _size.Width > pic.Width)
            {
                _vector.dx = -(_vector.dx);
            }

            //左端かどうか
            if (_xy.X < 0)
            {
                _vector.dx = -(_vector.dx);
            }

            //下端かどうか
            if (_xy.Y + _size.Height > pic.Height)
            {
                _vector.dy = -(_vector.dy);
            }

            //上端かどうか
            if (_xy.Y < 0)
            {
                _vector.dy = -(_vector.dy);
            }
        }
    }
    class MyBall : Ball
    {
        public MyBall(int x, int y, int dx, int dy)
            : base(_MyBall, x, y, dx, dy)
        {

        }
    }

    class OtherBall : Ball
    {
        public OtherBall(int x, int y, int dx, int dy)
            : base(_OtherBall, x, y, dx, dy)
        {

        }
    }
}
