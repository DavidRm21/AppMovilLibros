using ProyectoBiblioteca.DataAccess;
using ProyectoBiblioteca.ViewModel;

namespace ProyectoBiblioteca
{
    public partial class MainPage : ContentPage
    {
        List<BookViewModel> listBook;

        public MainPage()
        {
            InitializeComponent();
            var dbContex = new BookDBContext();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            listBook = new List<BookViewModel>() 
            {
                new () { Titulo = "Cien Años de Soledad", Autor = "Gabriel García Márquez", ISBN = "978-3-16-148410-0", CantidadCopias = 10 },
                new () { Titulo = "1984", Autor = "George Orwell", ISBN = "978-0-452-28423-4", CantidadCopias = 7 },
                new () { Titulo = "Don Quijote de la Mancha", Autor = "Miguel de Cervantes", ISBN = "978-0-553-21311-7", CantidadCopias = 12 },
                new () { Titulo = "Orgullo y Prejuicio", Autor = "Jane Austen", ISBN = "978-0-19-283355-4", CantidadCopias = 8 },
                new () { Titulo = "El Principito", Autor = "Antoine de Saint-Exupéry", ISBN = "978-2-07-040850-4", CantidadCopias = 20 },
                new () { Titulo = "Matar a un ruiseñor", Autor = "Harper Lee", ISBN = "978-0-06-112008-4", CantidadCopias = 15 },
                new () { Titulo = "La Odisea", Autor = "Homero", ISBN = "978-0-14-026886-7", CantidadCopias = 10 },
                new () { Titulo = "La Divina Comedia", Autor = "Dante Alighieri", ISBN = "978-0-19-500412-7", CantidadCopias = 9 },
                new () { Titulo = "Los Miserables", Autor = "Victor Hugo", ISBN = "978-0-14-044430-8", CantidadCopias = 3 },
                new () { Titulo = "Crimen y Castigo", Autor = "Fyodor Dostoevsky", ISBN = "978-0-14-044913-6", CantidadCopias = 8 }
            };

            bookListView.ItemsSource = listBook;
        }

        private async void OnClickedPrestar(object sender, EventArgs e)
        {
            var button = sender as Button;
            var selectedBook = button?.BindingContext as BookViewModel;
            if (selectedBook != null)
            {
                if (selectedBook.CantidadCopias <= 0)
                {
                    await Navigation.PushModalAsync(new WarningPage());
                }
                else
                {
                    selectedBook.Prestar();
                    await DisplayAlert("Prestamo Exitoso", $"Se ha prestado el libro \"{selectedBook.Titulo}\".", "OK");
                }
            }
            Console.WriteLine("OnClickedPrestar");
        }

        private async void OnClickedDevolver(object sender, EventArgs e)
        {
            var button = sender as Button;
            var selectedBook = button?.BindingContext as BookViewModel;

            if (selectedBook != null)
            {
                selectedBook.Devolver();
                await DisplayAlert("Devolución Exitosa", $"Se ha devuelto el libro \"{selectedBook.Titulo}\".", "OK");
            }
            Console.WriteLine("OnClickedDevolver");
        }


    }

}
