using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Практика_7
{
    public class Pacient : INotifyPropertyChanged
    {
        private string? id;
        private string name;
        private string last_name;
        private string middle_name;
        private string birthday;
        private string lastappointment;
        private string lastdoctor;
        private string diagnosis;
        private string recomendations;

        public string Name
        {
            get => name;
            set { name = value; OnPropertyChanged(); }
        }

        public string Last_Name
        {
            get => last_name;
            set { last_name = value; OnPropertyChanged(); }
        }
        public string Middle_Name
        {
            get => middle_name;
            set { middle_name = value; OnPropertyChanged(); }
        }
        public string BirthDay
        {
            get => birthday;
            set { birthday = value; OnPropertyChanged(); }
        }
        public string Last_Appointment
        {
            get => lastappointment;
            set { lastappointment = value; OnPropertyChanged(); }
        }
        public string Last_Doctor
        {
            get => lastdoctor;
            set { lastdoctor = value; OnPropertyChanged(); }
        }
        public string Diagnosis
        {
            get => diagnosis;
            set { diagnosis = value; OnPropertyChanged(); }
        }
        public string Recomendations
        {
            get => recomendations;
            set { recomendations = value; OnPropertyChanged(); }
        }

        [JsonIgnore]
        public string? Id
        {
            get => id;
            set { id = value; OnPropertyChanged(); }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
