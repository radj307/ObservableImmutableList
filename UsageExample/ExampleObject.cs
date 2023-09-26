using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace UsageExample
{
    /// <summary>
    /// An example object that implements the INotifyPropertyChanged interface.
    /// </summary>
    public class ExampleObject : INotifyPropertyChanged
    {
        #region Constructors
        public ExampleObject(string name, int id)
        {
            _name = name;
            _id = id;
        }
        /// <summary>
        /// Creates a new instance with random property values.
        /// </summary>
        /// <param name="randomGenerator">A <see cref="Random"/> instance to use for generating random values.</param>
        public ExampleObject(Random randomGenerator)
        {
            _name = string.Empty;
            for (int i = 0, max = randomGenerator.Next(4, 16); i < max; ++i)
            {
                Name += randomGenerator.Next(0, 2) == 0
                    ? (char)randomGenerator.Next('A', 'Z')
                    : (char)randomGenerator.Next('a', 'z');
            }
            _id = randomGenerator.Next();
        }
        #endregion Constructors

        #region Events
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new(propertyName));
        #endregion Events

        #region Properties
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                NotifyPropertyChanged();
            }
        }
        private string _name;
        public int ID
        {
            get => _id;
            set
            {
                _id = value;
                NotifyPropertyChanged();
            }
        }
        private int _id;
        #endregion Properties
    }
}
