using System;
using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.ModuloCategoria;

namespace ListaDeCompras.ConsoleApp.ModuloProdutos;

public enum UnidadeMedida
{
    Kg,
    Unidade,
    Litro,
    Caixa
}

public class Produto : EntidadeBase
{
    public string Nome { get; set; }
    public Categoria Categoria { get; set; }
    public UnidadeMedida UnidadeMedida { get; set; }
    public decimal Preco { get; set; }

    public Produto(string nome, Categoria categoria, UnidadeMedida unidadeMedida = default, decimal preco = 0)
    {
        Nome = nome;
        Categoria = categoria;
        UnidadeMedida = unidadeMedida;
        Preco = preco;
    }

    public override string[] Validar()
    {
        string erros = string.Empty;

        if (String.IsNullOrWhiteSpace(Nome))
            erros += "NOME não pode ser vazio!;";

        else if (Nome.Length < 2 || Nome.Length > 100)
            erros += "Nome deve conter entre 2 a 100 caracteres!;";

        if (Categoria == null)
            erros += "Categoria não pode ser vazia!;";

        if (UnidadeMedida <= 0)
            erros += "Unidade de medida deve ser maior que zero!;";

        if (Preco <= 0)
            erros += "Preço deve ser maior que zero!;";

        return erros.Split(";", StringSplitOptions.RemoveEmptyEntries);
    }

    public override void AtualizarDados(EntidadeBase entidadeAtualizada)
    {
        Produto produtoAtualizado = (Produto)entidadeAtualizada;

        Nome = produtoAtualizado.Nome;
        Categoria = produtoAtualizado.Categoria;
        UnidadeMedida = produtoAtualizado.UnidadeMedida;
        Preco = produtoAtualizado.Preco;
    }
}
