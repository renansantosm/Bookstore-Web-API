using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookstore.Migrations
{
    /// <inheritdoc />
    public partial class seedBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Books(Title, Description, Author, Price, Stock, GenreId)" +
                "Values('A Guerra dos Tronos : As Crônicas de Gelo e Fogo','Primeiro livro da série','George R. R. Martin', 40, 100, 1)");

            mb.Sql("Insert into Books(Title, Description, Author, Price, Stock, GenreId)" +
                "Values('O cavaleiro dos Sete Reinos','Narra as aventuras do cavaleiro Dunk ','George R. R. Martin', 38, 80, 1)");

            mb.Sql("Insert into Books(Title, Description, Author, Price, Stock, GenreId)" +
                "Values('Última parada','De autore de Vermelho, branco e sangue azul','Casey McQuiston', 20, 80, 1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("delete from Books");
        }
    }
}
