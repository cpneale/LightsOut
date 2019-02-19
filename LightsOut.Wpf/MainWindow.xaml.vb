Imports LightsOut.Engine
Imports System.Linq
Imports System.Windows
Imports System.Windows.Controls.Primitives
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Shapes

Namespace LightsOut.Wpf
    Public Partial Class MainWindow
        Inherits Window

        Private _board As Board

        Public Sub New()
            InitializeComponent()
            _board = New Board(5)
            UpdateView()
        End Sub

        Private Sub UniformGrid_MouseUp(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
            If Not (TypeOf e.OriginalSource Is Rectangle) Then Return
            Dim position As Integer = (CType(sender, UniformGrid)).Children.IndexOf(CType(e.OriginalSource, UIElement))
            Dim x As Integer = position Mod 5
            Dim y As Integer = position / 5
            _board.Click(x, y)
            UpdateView()
        End Sub

        Private Sub UpdateView()
            Dim allCells = _board.Grid.SelectMany(Function(cells) cells).[Select](Function(cell, idx) New With {idx, cell
            })

            For Each cell In allCells
                Dim rect = CType(GameGrid.Children(cell.idx), Rectangle)
                rect.Fill = If(cell.cell, Brushes.LimeGreen, Brushes.DarkGreen)
            Next
        End Sub
    End Class
End Namespace
