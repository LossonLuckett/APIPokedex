using GetPoke;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using PokeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeLibTests
{
    [TestClass]
    public class MainWindowTest
    {

        [TestMethod]
        public async Task PokeProcessor_IfStringIntSearch_ShouldReturnPokeModelObject()
        {
            PokeProcessor p = new PokeProcessor();


            MainWindow instance = new MainWindow(p);

            await instance.LoadPoke();

            return;
        }

    }
}
