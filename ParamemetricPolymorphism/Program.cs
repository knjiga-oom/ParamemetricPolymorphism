namespace ParamemetricPolymorphism
{
    class TypeModifier<T>
    {
        public TypeModifier(T value)
        {
            Value = value;
        }
        // generira se novi tip ovisno o prosljeđenoj funkciji:
        public TypeModifier<U> Modify<U>(Func<T, U> func)
        {
            return new TypeModifier<U>(func(Value));
        }

        public override string ToString() => Value?.ToString() ?? string.Empty;

        public readonly T Value;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var a = new TypeModifier<int>(5);
            Console.WriteLine(a);

            // ovo će stvoriti objekt tipa TypeModifier<double>:
            var b = a.Modify(v => v * 0.5);
            Console.WriteLine(b);

            // ovo će stvoriti objekt tipa TypeModifier<System.DaysOfWeek>:
            var c = a.Modify(v => Enum.ToObject(typeof(DayOfWeek), v));
            Console.WriteLine(c);
        }
    }
}
