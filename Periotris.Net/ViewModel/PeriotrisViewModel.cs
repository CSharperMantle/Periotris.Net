﻿/*
 * Periotris.Net
 * Copyright (C) 2020-present Rong "Mantle" Bao (CSharperMantle)
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see < https://github.com/CSharperMantle/Periotris.Net/blob/main/LICENSE >.
 */

using Periotris.Net.Common;
using Periotris.Net.Customization.Map;
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
    public class PeriotrisViewModel : INotifyPropertyChanged
    {
        public PeriotrisViewModel()
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

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     Scaling factor for proper positioning.
        /// </summary>
        public static double Scale { get; private set; }

        public AssistanceGridMode AssistanceGridMode
        {
            get => SettingsManager.Instance.Settings.AssistanceGridMode;
            set
            {
                SettingsManager manager = SettingsManager.Instance;
                Settings clone = manager.Settings;
                clone.AssistanceGridMode = value;
                manager.Settings = clone;
            }
        }

        public ColorMode ColorMode
        {
            get => SettingsManager.Instance.Settings.ColorMode;
            set
            {
                SettingsManager manager = SettingsManager.Instance;
                Settings clone = manager.Settings;
                clone.ColorMode = value;
                manager.Settings = clone;
            }
        }

        public bool GameOver => _model.GameEnded && !_model.Victory;

        public bool GameWon => _model.GameEnded && _model.Victory;

        public bool Paused { get; set; }

        public Size PlayAreaSize
        {
            set
            {
                Scale = value.Width / MapManager.Instance.Map.ColumnsCount;
                _model.UpdateAllBlocks();
                RecreateAssistGrids();
            }
        }

        public INotifyCollectionChanged Sprites => _sprites;

        public TimeSpan? CurrentHighestScore => _model.CurrentHighestScore;

        public TimeSpan ElapsedTime => _model.ElapsedTime;

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

        /// <summary>
        ///     Start the underlying game in <see cref="PeriotrisModel" />.
        /// </summary>
        public void StartGame()
        {
            // Clear remaining sprites.
            _sprites.Clear();
            // Clear blocks.
            _blocksByPosition.Clear();

            RecreateAssistGrids();
            _model.StartGame();
            OnPropertyChanged(nameof(GameOver));
            OnPropertyChanged(nameof(GameWon));
            Paused = false;
            _gameTimer.Start();
            _timeDisplayRefreshTimer.Start();
        }

        private readonly List<FrameworkElement> _assistGridLines =
                                                                                                                            new();

        private readonly Dictionary<Position, FrameworkElement> _blocksByPosition =
            new();

        private readonly DispatcherTimer _gameTimer = new();

        private readonly PeriotrisModel _model = new();

        private readonly ObservableCollection<FrameworkElement> _sprites =
            new();

        private readonly DispatcherTimer _timeDisplayRefreshTimer = new();

        private bool _lastPaused = true;

        private void EndGame()
        {
            _gameTimer.Stop();
            _timeDisplayRefreshTimer.Stop();
            OnPropertyChanged(nameof(GameOver));
            OnPropertyChanged(nameof(GameWon));
            OnPropertyChanged(nameof(CurrentHighestScore));
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

        private void ModelBlockChangedEventHandler(object sender, BlockChangedEventArgs e)
        {
            if (!e.Disappeared)
            {
                if (!_blocksByPosition.Keys.Contains(e.BlockUpdated.Position))
                {
                    // Create a new BlockControl.
                    FrameworkElement blockControl =
                        TetrisControlHelper.AnnotatedBlockControlFactory(e.BlockUpdated, ColorMode, Scale);
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

        private void OnPropertyChanged(string propertyName = null)
        {
            PropertyChangedEventHandler propertyChanged = PropertyChanged;
            propertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
            if (AssistanceGridMode != AssistanceGridMode.Enabled)
            {
                return;
            }

            for (int x = 0; x < MapManager.Instance.Map.ColumnsCount; x++)
            {
                FrameworkElement scanLine = TetrisControlHelper.VerticalAssistGridLineFactory(
                    x, MapManager.Instance.Map.RowsCount, Scale);
                _assistGridLines.Add(scanLine);
                _sprites.Add(scanLine);
            }

            for (int y = 0; y < MapManager.Instance.Map.RowsCount; y++)
            {
                FrameworkElement scanLine = TetrisControlHelper.HorizontalAssistGridLineFactory(
                    y, MapManager.Instance.Map.ColumnsCount, Scale);
                _assistGridLines.Add(scanLine);
                _sprites.Add(scanLine);
            }
        }

        private void TimeDisplayTimerTickEventHandler(object sender, EventArgs e)
        {
            OnPropertyChanged(nameof(ElapsedTime));
        }
    }
}