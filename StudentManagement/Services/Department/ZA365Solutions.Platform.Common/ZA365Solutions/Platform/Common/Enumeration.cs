namespace ZA365Solutions.Platform.Common
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    public abstract class Enumeration : IComparable
    {
        private readonly int _value;
        private readonly string _displayName;

        protected Enumeration()
        {
        }

        protected Enumeration(int value, string displayName)
        {
            this._value = value;
            this._displayName = displayName;
        }

        public int Value => this._value;

        public string DisplayName => this._displayName;

        public override string ToString() => this.DisplayName;

        public static IEnumerable<T> GetAll<T>() where T : Enumeration, new()
        {
            FieldInfo[] fieldInfoArray = typeof(T).GetFields(BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Public);
            for (int index = 0; index < fieldInfoArray.Length; ++index)
            {
                if (fieldInfoArray[index].GetValue((object)new T()) is T obj)
                    yield return obj;
            }
            fieldInfoArray = (FieldInfo[])null;
        }

        public override bool Equals(object obj) => obj is Enumeration enumeration && this.GetType().Equals(obj.GetType()) & this._value.Equals(enumeration.Value);

        public override int GetHashCode() => this._value.GetHashCode();

        public static int AbsoluteDifference(Enumeration firstValue, Enumeration secondValue) => Math.Abs(firstValue.Value - secondValue.Value);

        public static T FromValue<T>(int value) where T : Enumeration, new() => Enumeration.parse<T, int>(value, nameof(value), (Func<T, bool>)(item => item.Value == value));

        public static T FromDisplayName<T>(string displayName) where T : Enumeration, new() => Enumeration.parse<T, string>(displayName, "display name", (Func<T, bool>)(item => item.DisplayName == displayName));

        private static T parse<T, K>(K value, string description, Func<T, bool> predicate) where T : Enumeration, new() => Enumeration.GetAll<T>().FirstOrDefault<T>(predicate) ?? throw new ApplicationException(string.Format("'{0}' is not a valid {1} in {2}", (object)value, (object)description, (object)typeof(T)));

        public int CompareTo(object other) => this.Value.CompareTo(((Enumeration)other).Value);
    }
}

