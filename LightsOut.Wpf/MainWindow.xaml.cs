using LightsOut.Engine;
using System.Linq;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace LightsOut.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Board _board;

        public MainWindow()
        {
            InitializeComponent();
            _board = new Board(5);
            UpdateView();
        }

        private void UniformGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!(e.OriginalSource is Rectangle))
                return;

            int position = ((UniformGrid)sender).Children.IndexOf((UIElement)e.OriginalSource);
            int x = position % 5;
            int y = position / 5;

            _board.Click(x, y);

            UpdateView();
        }

        private void UpdateView()
        {
            var allCells = _board.Grid
                .SelectMany(cells => cells)
                .Select((cell, idx) => new { idx, cell });

            foreach (var cell in allCells)
            {
                var rect = (Rectangle)GameGrid.Children[cell.idx];
                rect.Fill = cell.cell ? Brushes.LimeGreen : Brushes.DarkGreen;
            }
        }
    }
}
