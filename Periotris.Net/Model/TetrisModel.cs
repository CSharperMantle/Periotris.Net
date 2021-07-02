using Periotris.Net.Common;
using Periotris.Net.Customization.History;
using Periotris.Net.Model.Generation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Periotris.Net.Model
{
    public class TetrisModel
    {
        /// <summary>
        ///     "Frozen" or inactive blocks. They can not be moved by user.
        /// </summary>
        private readonly List<Block> _frozenBlocks = new();

        /// <summary>
        ///     Leader-board and scoreboard.
        /// </summary>
        private readonly History _history;

        /// <summary>
        ///     Tetriminos that are waiting to be inserted to the playing field.
        /// </summary>
        private readonly Stack<Tetrimino> _pendingTetriminos = new();

        private readonly Random _random = new();

        /// <summary>
        ///     Stopwatch for recording play time and score-boarding.
        /// </summary>
        private readonly Stopwatch _stopwatch = new();

        /// <summary>
        ///     The active and only user-controllable <see cref="Tetrimino" /> on the field.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Operation to <see cref="_activeTetrimino" /> should be done through
        ///         <see cref="MoveActiveTetrimino(MoveDirection)" />
        ///         and <see cref="RotateActiveTetrimino(RotationDirection)" />
        ///     </para>
        ///     <para>
        ///         This is the only <see cref="Tetrimino" /> exists. After a <see cref="Tetrimino" /> is hit,
        ///         it will be "frozen" and the <see cref="Tetrimino.Blocks" /> will be transferred to
        ///         <see cref="_frozenBlocks" />.
        ///     </para>
        /// </remarks>
        private Tetrimino _activeTetrimino;

        /// <summary>
        ///     Construct a new <see cref="TetrisModel" /> whose game is initially ended.
        /// </summary>
        public TetrisModel()
        {
            _history = History.ReadFromFile();
            EndGame(false);
        }

        /// <summary>
        ///     Whether the game is ended.
        /// </summary>
        public bool GameEnded { get; private set; }

        /// <summary>
        ///     Whether the game won.
        /// </summary>
        public bool Victory { get; private set; }

        /// <summary>
        ///     The <see cref="Stopwatch.Elapsed" /> of the current game.
        /// </summary>
        public TimeSpan ElapsedTime => _stopwatch.Elapsed;

        /// <summary>
        ///     Set by <see cref="EndGame(bool)" /> to check if the current run's time is lower than
        ///     any other records.
        /// </summary>
        public bool NewHighScore { get; private set; }

        public TimeSpan? CurrentHighestScore => _history.FastestRecord;

        /// <summary>
        ///     End the current game.
        /// </summary>
        public void EndGame(bool victory)
        {
            GameEnded = true;
            Victory = victory;
            _stopwatch.Stop();
            if (victory)
            {
                NewHighScore = _history.AddNewScore(_stopwatch.Elapsed);
                History.WriteToFile(_history);
            }

            _pendingTetriminos.Clear();
            PeriotrisConst.GameUpdateIntervalSeconds = PeriotrisConst.OriginalGameUpdateIntervalSeconds;
            OnGameEnd();
        }

        /// <summary>
        ///     Reset and start a new game.
        /// </summary>
        public void StartGame()
        {
            // Clear frozen blocks
            foreach (Block block in _frozenBlocks)
            {
                OnBlockChanged(block, true);
            }

            _frozenBlocks.Clear();

            // Clear active tetrimino (if we have to do so)
            if (_activeTetrimino != null)
            {
                UpdateActiveTetrimino(true);
                _activeTetrimino = null;
            }

            // Fill in tetriminos
            IEnumerable<Tetrimino> generatedTetriminos = PatternGenerator.GetPlayablePattern(_random).Reverse();
            foreach (Tetrimino tetrimino in generatedTetriminos)
            {
                _pendingTetriminos.Push(tetrimino);
            }

            // Ready to start a new game
            _stopwatch.Reset();
            _stopwatch.Start();
            SpawnNextTetrimino();
            GameEnded = false;
        }

        /// <summary>
        ///     Move <see cref="_activeTetrimino" />, freeze and pop out a new <see cref="Tetrimino" /> if necessary.
        /// </summary>
        /// <param name="direction">The direction to move to</param>
        public void MoveActiveTetrimino(MoveDirection direction)
        {
            // The game has not fully started!
            if (GameEnded || _activeTetrimino == null)
            {
                return;
            }

            // First, notify that the old Blocks are removed...
            UpdateActiveTetrimino(true);

            if (direction == MoveDirection.Down)
            {
                // When we need to move down, we will have to freeze the blocks if the
                // Tetrimino hit the ground or other blocks.
                if (!_activeTetrimino.TryMove(direction, CheckBlockCollision))
                {
                    // Move them to the frozen block list and replace it.
                    FreezeActiveTetrimino();
                    // Re-add them and spawn a new Tetrimino.
                    UpdateActiveTetrimino(false);
                    SpawnNextTetrimino();
                }

                // Go normally.
            }
            else
            {
                // Move sideways.
                _activeTetrimino.TryMove(direction, CheckBlockCollision);
            }

            // Re-add moved blocks.
            UpdateActiveTetrimino(false);
        }

        /// <summary>
        ///     Rotate <see cref="_activeTetrimino" />.
        /// </summary>
        /// <param name="direction">The direction to rotate to</param>
        public void RotateActiveTetrimino(RotationDirection direction)
        {
            // The game has not fully started!
            if (GameEnded)
            {
                return;
            }

            UpdateActiveTetrimino(true);
            _activeTetrimino.TryRotate(direction, CheckBlockCollision);
            UpdateActiveTetrimino(false);
        }

        /// <summary>
        ///     Instant fix the <see cref="_activeTetrimino" /> to the lowest possible position.
        /// </summary>
        public void InstantDropActiveTetrimino()
        {
            if (GameEnded)
            {
                return;
            }

            UpdateActiveTetrimino(true);
            // Move until we done.
            while (_activeTetrimino.TryMove(MoveDirection.Down, CheckBlockCollision))
            {
            }

            UpdateActiveTetrimino(false);
        }

        /// <summary>
        ///     Update the game field.
        /// </summary>
        /// <remarks>
        ///     This method will automatically move down <see cref="_activeTetrimino" /> once, check whether
        ///     exist deletable lines and end game if necessary.
        /// </remarks>
        public void Update()
        {
            if (GameEnded)
            {
                return;
            }

            MoveActiveTetrimino(MoveDirection.Down);
            // Or, if any frozen block's atomic number is not equal to the template's
            // block's on its same location, i.e., the placed element is not at the 
            // position it should be, then a misplaced block is found.
            // End the game.
            foreach (Block block in _frozenBlocks)
            {
                if (GeneratorHelper.PeriodicTableTemplate[block.Position.Y,
                    block.Position.X].AtomicNumber != block.AtomicNumber)
                {
                    EndGame(false);
                }
            }

            // All blocks settled.
            if (_frozenBlocks.Count >= GeneratorHelper.TotalAvailableBlocks)
            {
                EndGame(true);
            }
        }

        /// <summary>
        ///     Refresh all <see cref="Block" />s in <see cref="_activeTetrimino" /> and <see cref="_frozenBlocks" />.
        /// </summary>
        /// <remarks>
        ///     Dim all blocks and then re-fire them.
        /// </remarks>
        public void UpdateAllBlocks()
        {
            UpdateActiveTetrimino(true);
            UpdateActiveTetrimino(false);
            foreach (Block block in _frozenBlocks)
            {
                OnBlockChanged(block, true);
                OnBlockChanged(block, false);
            }
        }

        /// <summary>
        ///     Internal method which moves the <see cref="Tetrimino.Blocks" />
        ///     in <see cref="_activeTetrimino" /> to <see cref="_frozenBlocks" />.
        /// </summary>
        private void FreezeActiveTetrimino()
        {
            PeriotrisConst.GameUpdateIntervalSeconds -= PeriotrisConst.TimeDecreaseDeltaSeconds;
            foreach (Block block in _activeTetrimino.Blocks)
            {
                _frozenBlocks.Add(block);
            }
        }

        /// <summary>
        ///     Internal method which checks whether a <see cref="Block" /> would collide
        ///     with other <see cref="Block" />s in <see cref="_frozenBlocks" /> or
        ///     with the borders of the game field.
        /// </summary>
        /// <returns>Whether a block will collide or not</returns>
        private bool CheckBlockCollision(Block block)
        {
            // Left or right border collision
            if (block.Position.X < 0 || block.Position.X >= PeriotrisConst.PlayAreaWidth)
            {
                return true;
            }
            // Bottom border collision
            if (block.Position.Y >= PeriotrisConst.PlayAreaHeight)
            {
                return true;
            }
            // Block-block collision
            return _frozenBlocks.Any(
                frozenBlock => frozenBlock.Position == block.Position);
        }

        /// <summary>
        ///     Internal method which pops a new <see cref="Tetrimino" /> from the given stack and replaces
        ///     <see cref="_activeTetrimino" /> with the newly-spawned one.
        /// </summary>
        /// <remarks>
        ///     Note that this method does NOT freeze current ActiveTetrimino. Please freeze
        ///     it first before calling this method.
        /// </remarks>
        private void SpawnNextTetrimino()
        {
            if (_pendingTetriminos.Count > 0)
            {
                _activeTetrimino = _pendingTetriminos.Pop();
                UpdateActiveTetrimino(false);
            }
        }

        /// <summary>
        ///     Internal method used to trigger <see cref="BlockChanged" /> event on
        ///     every <see cref="Block" /> in <see cref="_activeTetrimino" />.
        /// </summary>
        private void UpdateActiveTetrimino(bool disappeared)
        {
            if (_activeTetrimino != null)
            {
                foreach (Block block in _activeTetrimino.Blocks)
                {
                    OnBlockChanged(block, disappeared);
                }
            }
        }

        /// <summary>
        ///     An event fired when a <see cref="Block" /> needs to be updated.
        /// </summary>
        public event EventHandler<BlockChangedEventArgs> BlockChanged;

        private void OnBlockChanged(Block block, bool disappeared)
        {
            EventHandler<BlockChangedEventArgs> blockChanged = BlockChanged;
            blockChanged?.Invoke(this, new BlockChangedEventArgs(block, disappeared));
        }

        /// <summary>
        ///     An event fired when the game ends.
        /// </summary>
        public event EventHandler GameEnd;

        private void OnGameEnd()
        {
            EventHandler gameEnded = GameEnd;
            gameEnded?.Invoke(this, new EventArgs());
        }
    }
}