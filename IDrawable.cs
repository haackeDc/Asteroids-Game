using Microsoft.Graphics.Canvas.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalWindows {
    public interface IDrawable {
        void Draw(CanvasAnimatedControl canvas);
    }
}
