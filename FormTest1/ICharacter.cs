using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FormTest1
{
    public interface ICharacter
    {
        void draw(Graphics g);
        void Animation(CharacterPictureBox pic);
    }
}
