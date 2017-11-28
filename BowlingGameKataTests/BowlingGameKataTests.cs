using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingGameKata;

namespace BowlingGameKataTests
{
    [TestClass]
    public class BowlingGameKataTests
    {
        private Game game;
        [TestInitialize]
        public void CreateGame()
        {
            game = new Game();
        }

        [TestMethod]
        public void WhenGutterGame_ScoreIs0()
        {
            DoManyRolls(20, 0);
            Assert.AreEqual(0, game.GetScore());
        }

        [TestMethod]
        public void WhenScore1EachRoll_ScoreIs20()
        {
            DoManyRolls(20, 1);
            Assert.AreEqual(20, game.GetScore());
        }

        [TestMethod]
        public void WhenSpare_NextRollIsAddedAsBonus()
        {
            game.Roll(9);
            game.Roll(1);
            game.Roll(1);
            Assert.AreEqual(12, game.GetScore());
        }

        [TestMethod]
        public void WhenStrike_NextTwoRollsAreAddedAsBonus()
        {
            game.Roll(10);
            game.Roll(1);
            game.Roll(1);
            Assert.AreEqual(14, game.GetScore());
        }

        [TestMethod]
        public void WhenStrikeOnLastFrame_GetTwoExtraBowls()
        {
            DoManyRolls(18, 1);
            game.Roll(10);
            game.Roll(5);
            game.Roll(5);
            Assert.AreEqual(38, game.GetScore());
        }

        [TestMethod]
        public void WhenSpareOnLastFrame_GetOneExtraBowl()
        {
            DoManyRolls(18, 1);
            game.Roll(5);
            game.Roll(5);
            game.Roll(5);
            Assert.AreEqual(33, game.GetScore());
        }


        [TestMethod]
        public void PerfectGame()
        {
            DoManyRolls(12 , 10);
            Assert.AreEqual(300, game.GetScore());
        }

        [TestMethod]
        public void FinalFrameCantHaveMoreThan3Bowls()
        {
            DoManyRolls(18, 1);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            Assert.AreEqual(10, game.FramesPlayed);
            Assert.IsTrue(game.RollsInCurrentFrame <= 3);
        }

        [DataTestMethod]
        [DataRow(new[] {4,5,5,5,3,6,10,4,3,1,1,0,6,0,10,9,8,1,3}, 103)]
        [DataRow(new[] {5,3,7,2,10,3,2,7,3,2,1,2,8,1,0,1,1,5,2}, 73)]
        [DataRow(new[] {10,6,4,3,5,3,4,8,2,5,1,0,2,5,5,3,2,7,2}, 98)]
        [DataRow(new[] {1,2,3,4,5,1,6,1,7,1,8,1,9,1,10,9,1,4,3}, 101)]
        public void DataTests(int[] rolls, int expected)
        {
            DoManyRolls(rolls);
            Assert.AreEqual(expected, game.GetScore());
        }

        private void DoManyRolls(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                game.Roll(pins);
            }
        }

        private void DoManyRolls(IEnumerable<int> pins)
        {
            foreach (var t in pins)
            {
                game.Roll(t);
            }
        }

    }
}
