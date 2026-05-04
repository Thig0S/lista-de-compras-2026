using System;
using System.Security.Cryptography;
using ListaDeCompras.ConsoleApp.ModuloProdutos;

namespace ListaDeCompras.ConsoleApp.ItemDeCompra;

public class ItemCompra
{
    public ItemCompra(Produto produto, int quantidadeProduto)
    {
        Id = Convert
                .ToHexString(RandomNumberGenerator.GetBytes(4))
                .ToLower()
                .Substring(0, 7);

        Produto = produto;
        QuantidadeProduto = quantidadeProduto;
    }
    public string Id { get; set; }
    public Produto Produto { get; set; }
    public int QuantidadeProduto { get; set; }
}
