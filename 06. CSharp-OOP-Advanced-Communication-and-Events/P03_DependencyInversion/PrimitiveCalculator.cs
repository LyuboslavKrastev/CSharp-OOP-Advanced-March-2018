using P03_DependencyInversion.Strategies;
using System.Collections.Generic;

namespace P03_DependencyInversion
{
    public class PrimitiveCalculator
    {
        private IStrategy strategy;

        private readonly Dictionary<char, IStrategy> strategies;

        public PrimitiveCalculator()
        {
            this.strategies = new Dictionary<char, IStrategy>()
                {
                    {'+', new AdditionStrategy()},
                    {'-', new SubtractionStrategy()},
                    {'*', new MultiplyStrategy()},
                    {'/', new DivideStrategy()},
                };

            this.strategy = this.strategies['+'];
        }

        public void changeStrategy(char @operator)
        {
            this.strategy = this.strategies[@operator];
        }

        public int performCalculation(int firstOperand, int secondOperand)
        {
            return this.strategy.Calculate(firstOperand, secondOperand);
        }
    }
}
