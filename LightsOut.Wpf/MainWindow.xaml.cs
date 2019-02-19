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
        private const int GridSize = 5;

        public MainWindow()
        {
            InitializeComponent();
            InitializeState();
        }

        private void InitializeState()
        {
            _board = new Board(GridSize);

            //handle state change event and update the view, if the board was running async on a different thread this would have to be (o,e) => Dispatcher.Invoke(() => UpdateView());
            _board.StateChange += (o, e) => UpdateView();
            UpdateView();
        }

        //gui event handlers
        private void UniformGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!(e.OriginalSource is Rectangle))
                return;

            int position = ((UniformGrid)sender).Children.IndexOf((UIElement)e.OriginalSource);
            int x = position % 5;
            int y = position / 5;

            _board.Click(x, y);
        }

        private void ResetGame_Click(object sender, RoutedEventArgs e)
        {
            InitializeState();
        }

        //view helper
        private void UpdateView()
        {
            var allCells = _board.Grid
                .SelectMany(cells => cells)
                .Select((cell, idx) => new { idx, cell });

            var gradientBrush = new RadialGradientBrush();
            gradientBrush.GradientStops.Add(new GradientStop(Colors.LimeGreen, 1));
            gradientBrush.GradientStops.Add(new GradientStop(Colors.White, 0));

            foreach (var cell in allCells)
            {
                var rect = (Rectangle)GameGrid.Children[cell.idx];
                if (cell.cell)
                    rect.Fill = gradientBrush;
                else
                    rect.Fill = Brushes.DarkGreen;
            }

            if (_board.GameStatus == Engine.Enums.GameStatus.PlayerOneWins)
            {
                var response = MessageBox.Show("Congratulations Player 1 you have turned off all the lights, hit Ok to play again", "Victory", MessageBoxButton.OK);
                InitializeState();
            }
        }
    }
}
