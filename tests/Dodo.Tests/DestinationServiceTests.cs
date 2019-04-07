using Dodo.Destination;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Dodo.Tests
{
    [TestClass]
    public class DestinationServiceTests
    {
        private readonly DestinationService _defaultDestinationService;
        public DestinationServiceTests()
        {
            _defaultDestinationService = new DestinationService();
        }

        [TestMethod]
        public void Sort_GetException_InputNull()
        {
            Dictionary<string, string> given = null;

            Assert.ThrowsException<ArgumentNullException>(() => 
                    _defaultDestinationService.Sort(given));
        }

        [TestMethod]
        public void Sort_Get1Block_Input1Block()
        {
            var blocks = new Dictionary<string, string>() { {"A","B"} };
            var result = blocks;

            var actual = _defaultDestinationService.Sort(blocks);

            CollectionAssert.AreEqual(result, actual);
        }

        [TestMethod]
        public void Sort_GetSortedBlocks_Input3Block()
        {
            var given = new Dictionary<string, string>()
            {
                { "B", "C" },
                { "C", "D" },
                { "A", "B" }
            };

            var result = new Dictionary<string, string>()
            {
                { "A", "B" },
                { "B", "C" },
                { "C", "D" }
            }; 

            var actual = _defaultDestinationService.Sort(given);
            CollectionAssert.AreEqual(result, actual);
        }

        [TestMethod]
        public void Sort_GetException_Input3BlockWithTheSameDestination()
        {
            var given = new Dictionary<string, string>()
            {
                { "A", "B" },
                { "B", "C" },
                { "C", "B" }
            };

            Assert.ThrowsException<ArgumentException>(() => 
                    _defaultDestinationService.Sort(given));
        }

        [TestMethod]
        public void Sort_GetException_Input2UncorrectBlocks()
        {
            // Не совпадают пункты отправления и назначения
            var given = new Dictionary<string, string>()
            {
                { "A", "B" },
                { "C", "D" }
            };

            Assert.ThrowsException<KeyNotFoundException>(() =>
                    _defaultDestinationService.Sort(given));
        }
    }
}
