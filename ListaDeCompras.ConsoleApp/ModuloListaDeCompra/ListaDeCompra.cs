

using ListaDeCompras.ConsoleApp.ItemDeCompra;

namespace ListaDeCompras.ConsoleApp.ModuloListaDeCompra;

public class ListaDeCompra
{
    public string Titulo { get; set; }
    public DateTime Data { get; set; }
    public List<ItemCompra> ItensLista { get; set; } = new List<ItemCompra>();

    public ListaDeCompra(string titulo, DateTime data)
    {
        Titulo = titulo;
        Data = data;
    }
}
