using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using GUI_PrimeFactor_2.MVVM.Model;
using System.Windows;
using System;

namespace GUI_PrimeFactor_2.MVVM.ViewModel
{
    public class PrimeFactorViewModel : INotifyPropertyChanged
    {
        private readonly PrimeFactorModel _model;
        private string _inputNumber;
        private ObservableCollection<int> _primeFactors;
        private string _primeFactorsString;
        private string _algorithmName;

        public PrimeFactorViewModel(PrimeFactorModel model)
        {
            _model = model;
            PrimeFactors = new ObservableCollection<int>();
            CalculateCommand = new RelayCommand(CalculatePrimeFactors);
        }

        public string InputNumber
        {
            get => _inputNumber;
            set
            {
                _inputNumber = value;
                OnPropertyChanged();
            }
        }

        // ObservableCollection holds the prime factors but won't be displayed directly anymore
        public ObservableCollection<int> PrimeFactors
        {
            get => _primeFactors;
            private set
            {
                _primeFactors = value;
                OnPropertyChanged();
            }
        }

        // New property to format the prime factors as a comma-separated string
        public string PrimeFactorsString
        {
            get => _primeFactorsString;
            private set
            {
                _primeFactorsString = value;
                OnPropertyChanged();
            }
        }

        public string AlgorithmName
        {
            get => _algorithmName;
            private set
            {
                _algorithmName = value;
                OnPropertyChanged();
            }
        }

        public ICommand CalculateCommand { get; }

        // Method that performs the prime factorization and updates the UI with the result
        private void CalculatePrimeFactors()
        {
            try
            {
                // Validate the input to ensure it's a number greater than 1
                if (int.TryParse(InputNumber, out int number) && number > 1)
                {
                    // Call the model to get prime factors
                    var factors = _model.GetPrimeFactors(number);
                    PrimeFactors.Clear();
                    foreach (var factor in factors)
                    {
                        PrimeFactors.Add(factor);
                    }

                    // Update the formatted string of prime factors and bind the algorithm name
                    PrimeFactorsString = $"{_model.GetAlgorithmName()}: " + string.Join(", ", PrimeFactors);
                    AlgorithmName = _model.GetAlgorithmName();
                }
                else if (InputNumber.GetType() != typeof(int))
                {
                    throw new TypeAccessException("ERROR: Invalid input type. Input must be an integer.");
                }
                else
                {
                    PrimeFactors.Clear();
                    PrimeFactorsString = "Invalid Input";
                    throw new InvalidOperationException("ERROR: Unknown error.");
                }
            }
            catch (Exception ex)
            {
                PrimeFactors.Clear();
                PrimeFactorsString = "Error";
                AlgorithmName = "Error";

                // Show the error message in a popup message box
                MessageBox.Show($"An error occurred while calculating prime factors: {ex.Message}",
                                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Helper method to trigger PropertyChanged events for UI updates
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}