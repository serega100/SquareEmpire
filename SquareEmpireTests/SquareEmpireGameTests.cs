using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Drawing;
using System.Linq;
using NUnit.Framework;
using SquareEmpire.model.generator;

namespace SquareEmpireTests
{
    public class SquareEmpireGameTests
    {
        // TODO: Test game generator

        [TestCase(2, 1)]
        public void ShouldNotSelectCell(int cellX, int cellY)
        {
            var generator = new TestGameGenerator();
            var game = generator.GenerateGame();
            var cellLocation = new Point(cellX, cellY);
            Assert.Throws<ArgumentException>(() => game.SelectCell(cellLocation));
        }

        [TestCase(0, 5, new[] {0, 4}, new[] {1, 4}, new[] {0, 6}, new[] {1, 6})]
        public void ShouldSelectCell(int cellX, int cellY, params int[][] movePointPairs)
        {
            var generator = new TestGameGenerator();
            var game = generator.GenerateGame();
            var cellLocation = new Point(cellX, cellY);
            game.SelectCell(cellLocation);
            Assert.NotNull(game.AvailableMoveLocations);

            var movePoints = movePointPairs
                .Select(pair => new Point(pair[0], pair[1]))
                .ToImmutableList();

            Assert.AreEqual(game.AvailableMoveLocations, movePoints);
        }
    }
}