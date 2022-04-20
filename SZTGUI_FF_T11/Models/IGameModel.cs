using System.Collections.Generic;

namespace SZTGUI_FF_T11_CORE.Models
{
    public interface IGameModel
    {
        Player Player { get; }
        int TimeCounter { get; set; }
        double GameAreaHeight { get; set; }
        double GameAreaWidth { get; set; }
        List<Ball> Balls { get; }
    }
}