using Periotris.Net.Common;
using Periotris.Net.Customization.Settings;
using Periotris.Net.Model;
using Periotris.Net.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Periotris.Net.ViewModel
{
    public class TetrisViewModel : INotifyPropertyChanged
    {
        private readonly List<FrameworkElement> _assistGridLines =
            new();

        private readonly Dictionary<Position, FrameworkElement> _blocksByPosition =
            new();

        private readonly DispatcherTimer _gameTimer = new();

        private readonly TetrisModel _model = new();

        private readonly ObservableCollection<FrameworkElement> _sprites =
            new();

        private readonly DispatcherTimer _timeDisplayRefreshTimer = new();

        private bool _lastPaused = true;

        public TetrisViewModel()
        {
            Scale = 1;

            _model.BlockChanged += ModelBlockChangedEventHandler;
            _model.GameEnd += ModelGameEndEventListener;

            _gameTimer.Interval = TimeSpan.FromSeconds(PeriotrisConst.GameUpdateIntervalSeconds);
            _gameTimer.Tick += GameUpdateTimerTickEventHandler;

            _timeDisplayRefreshTimer.Interval = TimeSpan.FromSeconds(PeriotrisConst.TimeDisplayUpdateIntervalSeconds);
            _timeDisplayRefreshTimer.Tick += TimeDisplayTimerTickEventHandler;

            EndGame();
        }

        /// <summary>
        ///     Scaling factor for proper positioning.
        /// </summary>
        /// <remarks>
        ///     TODO.
        /// </remarks>
        public static double Scale { get; private set; }

        public Size PlayAreaSize
        {
            set
            {
                Scale = value.Width / PeriotrisConst.PlayAreaWidth;
                _model.UpdateAllBlocks();
                RecreateAssistGrids();
            }
        }

        public INotifyCollectionChanged Sprites => _sprites;

        public bool GameOver => _model.GameEnded && !_model.Victory;

        public bool GameWon => _model.GameEnded && _model.Victory;

        public TimeSpan ElapsedTime => _model.ElapsedTime;

        public TimeSpan? CurrentHighestScore => _model.CurrentHighestScore;

        public bool Paused { get; set; }

        public bool ShouldRenderColors
        {
            get => _model.Settings.ShouldRenderColors;
            set
            {
                Settings clone = _model.Settings;
                clone.ShouldRenderColors = value;
                _model.Settings = clone;
            }
        }

        public bool ShouldRenderGridAssistance
        {
            get => _model.Settings.ShouldRenderGridAssistance;
            set
            {
                Settings clone = _model.Settings;
                clone.ShouldRenderGridAssistance = value;
                _model.Settings = clone;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     Start the underlying game in <see cref="TetrisModel" />.
        /// </summary>
        public void StartGame()
        {
            RecreateAssistGrids();
            foreach (FrameworkElement block in _blocksByPosition.Values)
            {
                _sprites.Remove(block);
            }

            _model.StartGame();
            OnPropertyChanged(nameof(GameOver));
            OnPropertyChanged(nameof(GameWon));
            Paused = false;
            _gameTimer.Start();
            _timeDisplayRefreshTimer.Start();
        }

        /// <summary>
        /// KeyDown event handler.
        /// </summary>
        /// <param name="key">The <see cref="Key"/> pressed.</param>
        /// <returns>Whether the key is handled, that is, a key for game control.</returns>
        public bool OnKeyDown(Key key)
        {
            if (Paused)
            {
                if (key == Key.Escape)
                {
                    Paused = !Paused;
                }

                return true;
            }

            switch (key)
            {
                case Key.A:
                    _model.MoveActiveTetrimino(MoveDirection.Left);
                    break;
                case Key.S:
                    _model.MoveActiveTetrimino(MoveDirection.Down);
                    break;
                case Key.D:
                    _model.MoveActiveTetrimino(MoveDirection.Right);
                    break;
                case Key.W:
                    _model.RotateActiveTetrimino(RotationDirection.Right);
                    break;
                case Key.Left:
                    _model.MoveActiveTetrimino(MoveDirection.Left);
                    break;
                case Key.Down:
                    _model.MoveActiveTetrimino(MoveDirection.Down);
                    break;
                case Key.Right:
                    _model.MoveActiveTetrimino(MoveDirection.Right);
                    break;
                case Key.Up:
                    _model.RotateActiveTetrimino(RotationDirection.Right);
                    break;
                case Key.Space:
                    _model.InstantDropActiveTetrimino();
                    break;
                case Key.Escape:
                    Paused = !Paused;
                    break;
                default:
                    return false;
            }
            return true;
        }

        private void EndGame()
        {
            _gameTimer.Stop();
            _timeDisplayRefreshTimer.Stop();
            OnPropertyChanged(nameof(GameOver));
            OnPropertyChanged(nameof(GameWon));
            OnPropertyChanged(nameof(CurrentHighestScore));
        }

        private void RecreateAssistGrids()
        {
            foreach (FrameworkElement line in _assistGridLines)
            {
                if (_sprites.Contains(line))
                {
                    _sprites.Remove(line);
                }
            }

            _assistGridLines.Clear();
            if (!ShouldRenderGridAssistance)
            {
                return;
            }

            for (int x = 0; x < PeriotrisConst.PlayAreaWidth; x++)
            {
                FrameworkElement scanLine = TetrisControlHelper.VerticalAssistGridLineFactory(
                    x, PeriotrisConst.PlayAreaHeight, Scale);
                _assistGridLines.Add(scanLine);
                _sprites.Add(scanLine);
            }

            for (int y = 0; y < PeriotrisConst.PlayAreaHeight; y++)
            {
                FrameworkElement scanLine = TetrisControlHelper.HorizontalAssistGridLineFactory(
                    y, PeriotrisConst.PlayAreaWidth, Scale);
                _assistGridLines.Add(scanLine);
                _sprites.Add(scanLine);
            }
        }

        private void OnPropertyChanged(string propertyName = null)
        {
            PropertyChangedEventHandler propertyChanged = PropertyChanged;
            propertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ModelBlockChangedEventHandler(object sender, BlockChangedEventArgs e)
        {
            if (!e.Disappeared)
            {
                if (!_blocksByPosition.Keys.Contains(e.BlockUpdated.Position))
                {
                    // Create a new BlockControl.
                    FrameworkElement blockControl =
                        TetrisControlHelper.AnnotatedBlockControlFactory(e.BlockUpdated, ShouldRenderColors, Scale);
                    _blocksByPosition.Add(e.BlockUpdated.Position, blockControl);
                    _sprites.Add(blockControl);
                }
            }
            else
            {
                if (_blocksByPosition.Keys.Contains(e.BlockUpdated.Position))
                {
                    _sprites.Remove(_blocksByPosition[e.BlockUpdated.Position]);
                    _blocksByPosition.Remove(e.BlockUpdated.Position);
                }
            }
        }

        private void ModelGameEndEventListener(object sender, EventArgs e)
        {
            EndGame();
        }

        private void GameUpdateTimerTickEventHandler(object sender, EventArgs e)
        {
            if (_lastPaused != Paused)
            {
                OnPropertyChanged(nameof(Paused));
                _lastPaused = Paused;
            }

            if (!Paused)
            {
                _model.Update();
            }
            // Update interval
            _gameTimer.Interval = TimeSpan.FromSeconds(PeriotrisConst.GameUpdateIntervalSeconds);
        }

        private void TimeDisplayTimerTickEventHandler(object sender, EventArgs e)
        {
            OnPropertyChanged(nameof(ElapsedTime));
        }
    }
}