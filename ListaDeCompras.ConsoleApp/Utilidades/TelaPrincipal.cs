using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.ItemDeCompra;
using ListaDeCompras.ConsoleApp.ModuloCategoria;
using ListaDeCompras.ConsoleApp.ModuloListaDeCompra;
using ListaDeCompras.ConsoleApp.ModuloProdutos;

namespace ListaDeCompras.ConsoleApp.Utilidades;

public class TelaPrincipal
{
    private readonly RepositorioCategoria repositorioCategoria = new RepositorioCategoria();
    private readonly RepositorioProduto repositorioProduto = new RepositorioProduto();
    private readonly RepositorioListas repositorioListas = new();
    public TelaPrincipal()
    {
        Categoria categoria = new Categoria("Limpeza", "Vermelho");
        Categoria categoria2 = new Categoria("Cerveja", "Vermelho");
        Categoria categoria3 = new Categoria("Vodka", "Vermelho");
        repositorioCategoria.Cadastrar(categoria);
        repositorioCategoria.Cadastrar(categoria2);
        repositorioCategoria.Cadastrar(categoria3);

        Produto produto = new Produto("Cerveja", categoria2, UnidadeMedida.Litro, 10.50m);
        repositorioProduto.Cadastrar(produto);

        ListaDeCompra lista = new ListaDeCompra("Churrasco Academia", new DateTime(07 / 05 / 2026));
        repositorioListas.Cadastrar(lista);
        lista.AdicionarParaLista(new ItemCompra(produto, 64));
    }

    public ITela? ApresentarMenuOpcoesPrincipal()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Lista de Compras");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Gerenciar categorias");
        Console.WriteLine("2 - Gerenciar produtos");
        Console.WriteLine("3 - Gerenciar listas de compras");
        Console.WriteLine("4 - Gerenciar itens de listas de compras");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");
        string? opcaoMenuPrincipal = Console.ReadLine()?.ToUpper();

        if (opcaoMenuPrincipal == "1")
            return new TelaCategoria(repositorioCategoria);
        if (opcaoMenuPrincipal == "2")
            return new TelaProduto("Produto", repositorioProduto, repositorioCategoria);
        if (opcaoMenuPrincipal == "3")
            return new TelaLista("Lista de Compra", repositorioListas);
        if (opcaoMenuPrincipal == "4")
            return new TelaAdicionarLista(repositorioListas, repositorioProduto);
        return null;
    }
}