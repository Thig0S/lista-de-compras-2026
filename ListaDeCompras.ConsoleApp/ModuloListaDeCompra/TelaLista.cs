using System;
using System.Collections;
using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.ItemDeCompra;

namespace ListaDeCompras.ConsoleApp.ModuloListaDeCompra;

public class TelaLista : TelaBase
{

    public TelaLista(string nomeEntidade, RepositorioBase repositorio) : base(nomeEntidade, repositorio)
    {

    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        Console.Clear();
        ArrayList listaDeListaskkk = repositorio.SelecionarTodos();

        Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -10}",
            "Id", "Titulo", "Data"
        );

        foreach (ListaDeCompra l in listaDeListaskkk)
        {
            Console.WriteLine(
                "{0, -7} | {1, -20} | {2, -10}",
                l.Id, l.Titulo, l.Data.ToString("dd/MM/yyyy")
        );
            if (deveExibirCabecalho)
            {
                System.Console.WriteLine(" - Produtos na lista: ");

                if (l.ItensLista.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    System.Console.WriteLine("----------------");
                    System.Console.WriteLine("Nenhum item na Lista");
                    Console.ResetColor();
                }
                else
                {
                    foreach (ItemCompra item in l.ItensLista)
                    {
                        System.Console.WriteLine($"    - Nome: {item.Produto.Nome}");
                        System.Console.WriteLine($"    - Quantidade: {item.QuantidadeProduto}");
                    }
                }
            }
            if (deveExibirCabecalho)
            {
                Console.WriteLine("---------------------------------");
                Console.Write("Digite ENTER para continuar...");
                Console.ReadLine();
            }
        }
    }

    protected override EntidadeBase ObterDadosCadastrais()
    {
        System.Console.Write("Digite o Titulo da Lista: ");
        string? titulo = Console.ReadLine();

        System.Console.Write("Digite a Data para a Lista (dd/MM/yyyy): ");
        string? entrada = Console.ReadLine();

        DateTime data = DateTime.Parse(entrada);

        return new ListaDeCompra(titulo, data);
    }
}
