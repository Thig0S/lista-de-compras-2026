

using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.ItemDeCompra;

namespace ListaDeCompras.ConsoleApp.ModuloListaDeCompra;

public class ListaDeCompra : EntidadeBase
{
    public string Titulo { get; set; }
    public DateTime Data { get; set; }
    public List<ItemCompra> ItensLista { get; set; } = new List<ItemCompra>();

    public ListaDeCompra(string titulo, DateTime data)
    {
        Titulo = titulo;
        Data = data;
    }

    public override string[] Validar()
    {
        string erros = string.Empty;

        if (String.IsNullOrWhiteSpace(Titulo))
            erros += "Titulo não pode ser Vazio!;";
        else if (Titulo.Length < 3 || Titulo.Length > 20)
            erros += "Titulo deve conter entre 4 a 20 caracteres!;";

        return erros.Split(";", StringSplitOptions.RemoveEmptyEntries);
    }

    public override void AtualizarDados(EntidadeBase entidadeAtualizada)
    {
        ListaDeCompra listaAtualizada = (ListaDeCompra)entidadeAtualizada;

        Titulo = listaAtualizada.Titulo;
        Data = listaAtualizada.Data;
    }
}
