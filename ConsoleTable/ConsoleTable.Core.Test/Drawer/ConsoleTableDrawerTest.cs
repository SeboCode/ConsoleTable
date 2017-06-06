using System;
using ConsoleTable.Core.Drawer;
using ConsoleTable.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleTable.Core.Test.Drawer
{
    [TestClass]
    public class ConsoleTableDrawerTest
    {
        [TestMethod]
        public void Test_Create_Drawer_Valid()
        {
            var matrix = new[,]
            {
                {1.25, 214.5},
                {26.4, 241.5}
            };

            var drawer = new ConsoleTableDrawer(new ConsoleTable<double>(matrix));
            Assert.IsNotNull(drawer.Settings);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_Create_Drawer_Data_Null()
        {
            new ConsoleTableDrawer(null);
        }

        [TestMethod]
        public void Test_Create_Drawer_Settings_Set_Constructor()
        {
            var matrix = new[,]
            {
                {1.25, 214.5},
                {26.4, 241.5}
            };

            var settings = new ConsoleTableSettings(null, true);
            var drawer = new ConsoleTableDrawer(new ConsoleTable<double>(matrix), settings);
            Assert.AreEqual(settings, drawer.Settings);
        }

        [TestMethod]
        public void Test_Create_Drawer_Settings_Set_Setter()
        {
            var matrix = new[,]
            {
                {1.25, 214.5},
                {26.4, 241.5}
            };

            var settings = new ConsoleTableSettings(null, true);
            var drawer = new ConsoleTableDrawer(new ConsoleTable<double>(matrix));
            drawer.Settings = settings;
            Assert.AreEqual(settings, drawer.Settings);
        }

        [TestMethod]
        public void Test_Create_Drawer_Settings_Not_Null()
        {
            var matrix = new[,]
            {
                {1.25, 214.5},
                {26.4, 241.5}
            };

            var drawer = new ConsoleTableDrawer(new ConsoleTable<double>(matrix));
            var drawerExplicit = new ConsoleTableDrawer(new ConsoleTable<double>(matrix), null);
            Assert.IsNotNull(drawer.Settings);
            Assert.IsNotNull(drawerExplicit.Settings);
        }
    }
}