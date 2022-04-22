using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SZTGUI_FF_T11_Renderer
{
    public interface IGameRenderer
    {
        void Display(DrawingContext ctx);
    }
}
