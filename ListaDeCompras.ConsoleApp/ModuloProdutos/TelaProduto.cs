using System;
using System.Collections;
using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.ModuloCategoria;

namespace ListaDeCompras.ConsoleApp.ModuloProdutos;

public class TelaProduto : TelaBase
{
    private RepositorioCategoria repositorioCategoria;
    public TelaProduto(string nomeEntidade, RepositorioBase repositorio, RepositorioCategoria repositorioCategoria) : base(nomeEntidade, repositorio)
    {
        this.repositorioCategoria = repositorioCategoria;
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
            ExibirCabecalho("Visualização de Produtos");


        ArrayList produtos = repositorio.SelecionarTodos();

        if (produtos.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Não existe nenhum registro.");
            Console.ResetColor();
            Console.WriteLine("---------------------------------");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();
            return;
        }

        Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -10} | {3, -15} | {4, -5}",
            "Id", "Nome", "Categoria", "Unidade de Medida", "Preco"
        );

        foreach (Produto c in produtos)
        {
            Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -10} | {3, -15} | {4, -5}",
            c.Id, c.Nome, c.Categoria.Nome, c.UnidadeMedida.ToString(), "R$: " + c.Preco
        );
        }
        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();
        }
    }

    protected override EntidadeBase ObterDadosCadastrais()
    {
        System.Console.Write("Digite o Nome do Produto: ");
        string? nome = Console.ReadLine();
        System.Console.WriteLine("--------------------");

        ArrayList listaCategorias = repositorioCategoria.SelecionarTodos();

        Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -10}",
            "Id", "Nome", "Cor"
        );

        foreach (Categoria c in listaCategorias)
        {
            string corSelecionada = c.Cor;

            if (corSelecionada == "Vermelho")
                Console.ForegroundColor = ConsoleColor.Red;

            else if (corSelecionada == "Verde")
                Console.ForegroundColor = ConsoleColor.Green;

            else if (corSelecionada == "Azul")
                Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine(
                "{0, -7} | {1, -20} | {2, -10}",
                c.Id, c.Nome, c.Cor
            );
        }
        System.Console.WriteLine("-------------------");
        Console.ResetColor();

        string idSelecionado;
        do
        {
            System.Console.Write("Digite o ID da categoria para o Produto: ");
            idSelecionado = Console.ReadLine();

            if (!String.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
                break;

            System.Console.WriteLine("Digite um ID valido!");
        } while (true);
        EntidadeBase categoriaSelecionada = repositorioCategoria.SelecionarPorId(idSelecionado);
        string unidade;
        do
        {
            System.Console.WriteLine("---------------------");
            System.Console.WriteLine("Digite o tipo de Unidade do produto: ");
            System.Console.WriteLine("---------------------");
            System.Console.WriteLine("1 - Kg");
            System.Console.WriteLine("2 - Unidade");
            System.Console.WriteLine("3 - Litro");
            System.Console.WriteLine("4 - Caixa");
            System.Console.Write("> ");
            unidade = Console.ReadLine();

            if (unidade == "1" || unidade == "2" || unidade == "3" || unidade == "4")
                break;

            System.Console.WriteLine("--------------------");
            System.Console.WriteLine("Digite uma das opções!");
        } while (true);
        UnidadeMedida u = UnidadeMedida.Kg;

        switch (unidade)
        {
            case "1":
                u = UnidadeMedida.Kg;
                break;
            case "2":
                u = UnidadeMedida.Unidade;
                break;
            case "3":
                u = UnidadeMedida.Litro;
                break;
            case "4":
                u = UnidadeMedida.Caixa;
                break;
        }

        System.Console.Write("Digite o preco do produto R$: ");
        decimal preco = Convert.ToDecimal(Console.ReadLine());

        return new Produto(nome, (Categoria)categoriaSelecionada, u, preco);
    }
}
