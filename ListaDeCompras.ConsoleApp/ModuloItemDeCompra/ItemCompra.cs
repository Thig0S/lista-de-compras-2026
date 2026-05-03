using System;
using ListaDeCompras.ConsoleApp.ModuloProdutos;

namespace ListaDeCompras.ConsoleApp.ItemDeCompra;

public class ItemCompra
{
    public ItemCompra(Produto produto, int quantidadeProduto)
    {
        Produto = produto;
        QuantidadeProduto = quantidadeProduto;
    }

    public Produto Produto { get; set; }
    public int QuantidadeProduto { get; set; }
}
