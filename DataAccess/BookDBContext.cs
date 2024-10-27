using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBiblioteca.DataAccess;
    public class BookDBContext : DbContext
    {
        public DbSet<Book> Libros {  get; set; }
        public DbSet<User> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("BookStore");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasData(
            new Book(1,"Cien Años de Soledad", "Gabriel García Márquez", "978-3-16-148410-0", 10),
            new Book(2,"1984", "George Orwell", "978-0-452-28423-4", 7),
            new Book(3,"Don Quijote de la Mancha", "Miguel de Cervantes", "978-0-553-21311-7", 5),
            new Book(4,"Orgullo y Prejuicio", "Jane Austen", "978-0-19-283355-4", 8),
            new Book(5,"El Principito", "Antoine de Saint-Exupéry", "978-2-07-040850-4", 15),
            new Book(6,"Matar a un ruiseñor", "Harper Lee", "978-0-06-112008-4", 6),
            new Book(7,"La Odisea", "Homero", "978-0-14-026886-7", 4),
            new Book(8,"La Divina Comedia", "Dante Alighieri", "978-0-19-500412-7", 9),
            new Book(9,"Los Miserables", "Victor Hugo", "978-0-14-044430-8", 3),
            new Book(10,"Crimen y Castigo", "Fyodor Dostoevsky", "978-0-14-044913-6", 12)
            );

        modelBuilder.Entity<User>().HasData(
            new User(1, "Juan Pérez", 1001),
            new User(2, "María González", 1002),
            new User(3, "Carlos Ramírez", 1003),
            new User(4, "Ana López", 1004),
            new User(5, "Luis Torres", 1005),
            new User(6, "Laura Sánchez", 1006),
            new User(7, "Pedro Castillo", 1007),
            new User(8, "Rosa Fernández", 1008),
            new User(9, "Miguel Herrera", 1009),
            new User(10, "Sofía Morales", 1010)
            );
    }

}

public record Book(int Id, string Titulo, string Autor, string ISBN, int CantidadCopias);
public record User(int Id, string Nombre, int Password);
