using System;
using System.Collections.Generic;
using System.Linq;

namespace Dodo.Destination
{
    public class DestinationService
    {
        /// <summary>
        /// Сортировать маршрут
        /// </summary>
        /// <param name="blocks">Набор содержащий пункты отпраления и назначения</param>
        /// <returns>Упорядоченная последовательность блоков</returns>
        /// <exception>asd</exception>
        public Dictionary<string, string> Sort(Dictionary<string, string> blocks)
        {
            if (blocks == null || blocks.Count == 0)
                throw new ArgumentNullException(paramName: nameof(blocks));

            var destination = new Dictionary<string, string>(blocks.Count);

            var reverseBlocks = blocks.ToDictionary(k => k.Value, v => v.Key); // O(n)
            var firstPoint = blocks.FirstOrDefault(p => !reverseBlocks.ContainsKey(p.Key)); //O(n)

            destination.Add(firstPoint.Key, firstPoint.Value);

            var lastValue = firstPoint.Value;

            for (int i = 1; i < blocks.Count; i++)
            {
                destination.Add(lastValue, blocks[lastValue]);
                lastValue = blocks[lastValue];
            } // O(n) - 1

            // Сложность алгоритма O(3(n+h)),  h-сложность вычисления хэш функции. 

            return destination;
        }
    }
}
