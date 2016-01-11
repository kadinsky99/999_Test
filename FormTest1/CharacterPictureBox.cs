using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace FormTest1
{
    public class CharacterPictureBox:PictureBox
    {


        private Bitmap _Bitmap;
        public List<ICharacter> List = new List<ICharacter>();

        public void initialize()
        {
            _Bitmap = new Bitmap(this.Width, this.Height);
        }

        public void draw()
        {
            using (Graphics g = Graphics.FromImage(_Bitmap))
            {
                g.Clear(Color.Black);
                foreach(var character in List)
                {
                    character.draw(g);
                }

                
            }

            foreach (var character in List)
            {
                character.Animation(this);
            }

            this.Image = _Bitmap;

        }
    }
}
