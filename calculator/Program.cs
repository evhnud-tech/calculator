using System;

namespace MCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            calculator.Run();
        }
    }

    public class Calculator
    {
        private double _currentValue;
        private bool _isRunning;

        public Calculator()
        {
            _currentValue = 0;
            _isRunning = true;
        }

        public void Run()
        {
            Console.WriteLine("Калькулятор запущен. Введите 'exit' для выхода.");
            Console.WriteLine($"Текущее значение: {_currentValue}");

            while (_isRunning)
            {
                ProcessInput();
            }

            Console.WriteLine("Работа калькулятора завершена.");
        }

        private void ProcessInput()
        {
            Console.Write("Введите операцию (+, -, *, /, sqrt, pow, 1/x, clear, exit) или число: ");
            string input = Console.ReadLine()?.Trim().ToLower() ?? "";

            if (input == "exit")
            {
                _isRunning = false;
                return;
            }

            if (double.TryParse(input, out double number))
            {
                _currentValue = number;
                Console.WriteLine($"Текущее значение: {_currentValue}");
                return;
            }

            ProcessOperation(input);
        }

        private void ProcessOperation(string operation)
        {
            switch (operation)
            {
                case "+":
                    PerformAddition();
                    break;
                case "-":
                    PerformSubtraction();
                    break;
                case "*":
                    PerformMultiplication();
                    break;
                case "/":
                    PerformDivision();
                    break;
                case "sqrt":
                    PerformSquareRoot();
                    break;
                case "pow":
                    PerformPower();
                    break;
                case "1/x":
                    PerformReciprocal();
                    break;
                case "clear":
                    _currentValue = 0;
                    Console.WriteLine($"Текущее значение: {_currentValue}");
                    break;
                default:
                    Console.WriteLine("Неизвестная операция");
                    break;
            }
        }

        private void PerformAddition()
        {
            Console.Write("Введите второе слагаемое: ");
            if (TryGetNumber(out double number))
            {
                _currentValue += number;
                Console.WriteLine($"Результат: {_currentValue}");
            }
        }

        private void PerformSubtraction()
        {
            Console.Write("Введите вычитаемое: ");
            if (TryGetNumber(out double number))
            {
                _currentValue -= number;
                Console.WriteLine($"Результат: {_currentValue}");
            }
        }

        private void PerformMultiplication()
        {
            Console.Write("Введите множитель: ");
            if (TryGetNumber(out double number))
            {
                _currentValue *= number;
                Console.WriteLine($"Результат: {_currentValue}");
            }
        }

        private void PerformDivision()
        {
            Console.Write("Введите делитель: ");
            if (TryGetNumber(out double number))
            {
                if (number == 0)
                {
                    Console.WriteLine("Ошибка: деление на ноль");
                    return;
                }
                _currentValue /= number;
                Console.WriteLine($"Результат: {_currentValue}");
            }
        }

        private void PerformSquareRoot()
        {
            if (_currentValue < 0)
            {
                Console.WriteLine("Ошибка: нельзя извлечь корень из отрицательного числа");
                return;
            }
            _currentValue = Math.Sqrt(_currentValue);
            Console.WriteLine($"Результат: {_currentValue}");
        }

        private void PerformPower()
        {
            Console.Write("Введите степень: ");
            if (TryGetNumber(out double exponent))
            {
                _currentValue = Math.Pow(_currentValue, exponent);
                Console.WriteLine($"Результат: {_currentValue}");
            }
        }

        private void PerformReciprocal()
        {
            if (_currentValue == 0)
            {
                Console.WriteLine("Ошибка: деление на ноль");
                return;
            }
            _currentValue = 1 / _currentValue;
            Console.WriteLine($"Результат: {_currentValue}");
        }

        private bool TryGetNumber(out double number)
        {
            string input = Console.ReadLine()?.Trim() ?? "";
            if (double.TryParse(input, out number))
            {
                return true;
            }

            Console.WriteLine("Ошибка: введите корректное число");
            return false;
        }
    }
}