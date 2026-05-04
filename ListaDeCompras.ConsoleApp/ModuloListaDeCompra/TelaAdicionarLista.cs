using System;
using System.Collections;
using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.ItemDeCompra;
using ListaDeCompras.ConsoleApp.ModuloProdutos;

namespace ListaDeCompras.ConsoleApp.ModuloListaDeCompra;

public class TelaAdicionarLista : ITela
{
    private RepositorioListas repositorioListas;
    private RepositorioProduto repositorioProduto;

    public TelaAdicionarLista(RepositorioListas repositorioListas, RepositorioProduto repositorioProduto)
    {
        this.repositorioListas = repositorioListas;
        this.repositorioProduto = repositorioProduto;
    }

    public void CadastrarProduto()
    {
        Console.Clear();

        ArrayList listaDeListaskkk = repositorioListas.SelecionarTodos();

        Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -10}",
            "Id", "Titulo", "Data"
        );

        foreach (ListaDeCompra l in listaDeListaskkk)
        {
            Console.WriteLine(
                "{0, -7} | {1, -20} | {2, -10}",
                l.Id, l.Titulo, l.Data.ToString("dd/MM/yyyy"));
        }
        string idSelecionado;
        do
        {
            Console.Write("Digite o ID da lista que deseja incluir Produtos (ou S para sair): ");
            idSelecionado = Console.ReadLine() ?? string.Empty;

            if (idSelecionado == "S")
                return;

            if (idSelecionado.Length == 7)
                break;
        } while (true);

        ListaDeCompra listaSelecionada = (ListaDeCompra)repositorioListas.SelecionarPorId(idSelecionado);

        ArrayList listaProdutos = repositorioProduto.SelecionarTodos();

        Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -10} | {3, -15} | {4, -5}",
            "Id", "Nome", "Categoria", "Unidade de Medida", "Preco"
        );

        foreach (Produto c in listaProdutos)
        {
            Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -10} | {3, -15} | {4, -5}",
            c.Id, c.Nome, c.Categoria.Nome, c.UnidadeMedida.ToString(), "R$: " + c.Preco
        );
        }
        do
        {
            Console.Write("Digite o ID do PRODUTO que deseja ADICIONAR a Lista (ou S para sair): ");
            idSelecionado = Console.ReadLine() ?? string.Empty;

            if (idSelecionado == "S")
                return;

            if (idSelecionado.Length == 7)
                break;
        } while (true);
        Produto produtoSelecionado = (Produto)repositorioProduto.SelecionarPorId(idSelecionado);
        System.Console.Write("Digite a quantidade do Produto: ");
        int quantidade = Convert.ToInt32(Console.ReadLine());

        ItemCompra novoItem = new ItemCompra(produtoSelecionado, quantidade);

        listaSelecionada.AdicionarParaLista(novoItem);

        Console.Clear();

        System.Console.WriteLine($"Item {produtoSelecionado.Nome} adicionado a lista: {listaSelecionada.Titulo} com sucesso!");
        System.Console.WriteLine("Pressione ENTER para continuar");
        Console.ReadLine();
    }
    public void ExcluirProduto()
    {
        Console.Clear();
        ArrayList listaDeListaskkk = repositorioListas.SelecionarTodos();

        Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -10}",
            "Id", "Titulo", "Data"
        );

        foreach (ListaDeCompra l in listaDeListaskkk)
        {
            Console.WriteLine(
                "{0, -7} | {1, -20} | {2, -10}",
                l.Id, l.Titulo, l.Data.ToString("dd/MM/yyyy"));
        }
        string idSelecionado;
        System.Console.WriteLine("");
        do
        {
            Console.Write("Digite o ID da lista que deseja EXCLUIR um produto (ou S para sair): ");
            idSelecionado = Console.ReadLine() ?? string.Empty;

            if (idSelecionado == "S")
                return;

            if (idSelecionado.Length == 7)
                break;
        } while (true);

        ListaDeCompra listaSelecionada = (ListaDeCompra)repositorioListas.SelecionarPorId(idSelecionado);

        foreach (ItemCompra item in listaSelecionada.ItensLista)
        {
            System.Console.WriteLine($"    - ID: {item.Id}, Nome: {item.Produto.Nome}, Quantidade: Quantidade: {item.QuantidadeProduto}");
        }
        System.Console.WriteLine("");
        string idSelecionadoProduto;
        do
        {
            Console.Write("Digite o ID do PRODUTO que deseja EXCLUIR a Lista (ou S para sair): ");
            idSelecionadoProduto = Console.ReadLine() ?? string.Empty;

            if (idSelecionadoProduto == "S")
                return;

            if (idSelecionadoProduto.Length == 7)
                break;
        } while (true);

        ItemCompra? itemSelecionado = listaSelecionada.SelecionarPorIdItemLista(idSelecionadoProduto);

        if (itemSelecionado == null)
        {
            System.Console.WriteLine("----------------");
            System.Console.WriteLine($"Produto com o ID: {idSelecionadoProduto} não encontrado na lista: {listaSelecionada.Titulo}");
            System.Console.WriteLine("Pressione ENTER para continuar");
            Console.ReadLine();
            return;
        }
        listaSelecionada.ExcluirProdutoLista(itemSelecionado);

        System.Console.WriteLine("----------------");
        System.Console.WriteLine($"Produto com o ID: {idSelecionado} excluido com sucesso!");
        System.Console.WriteLine("Pressione ENTER para continuar");
        Console.ReadLine();
    }
    public string? ObterOpcaoMenu()
    {
        {

            Console.Clear();
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Gestão de Itens Lista");
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"1 - Adicionar Itens Lista");
            Console.WriteLine($"2 - Excluir Itens Lista");
            Console.WriteLine("S - Voltar para o início");
            Console.WriteLine("---------------------------------");
            Console.Write("> ");
            string? opcaoMenu = Console.ReadLine()?.ToUpper();

            return opcaoMenu;
        }
    }


}