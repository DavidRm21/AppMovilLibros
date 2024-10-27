using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBiblioteca.ViewModel;
    public class BookViewModel : INotifyPropertyChanged
    {
        private int _CantidadCopias;
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public int CantidadCopias {
            get => _CantidadCopias;
            set
            {
                if (_CantidadCopias != value)
                {
                    _CantidadCopias = value;
                    OnPropertyChanged(nameof(CantidadCopias));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    public BookViewModel(string titulo, string autor, string iSBN, int cantidadCopias)
        {
            Titulo = titulo;
            Autor = autor;
            ISBN = iSBN;
            CantidadCopias = cantidadCopias;
        }

        public BookViewModel() {}

        public bool Prestar()
        {
            if (CantidadCopias > 0)
            {
                CantidadCopias--;
                return true;
            }
            Console.WriteLine($"No hay copias disponibles para el libro: {Titulo}");
            return false;
        }

        public void Devolver()
        {
            CantidadCopias++;
        }

        public void MostrarInformacion()
        {
            Console.WriteLine($"Título: {Titulo}, Autor: {Autor}, ISBN: {ISBN}, Copias disponibles: {CantidadCopias}");
        }
}
