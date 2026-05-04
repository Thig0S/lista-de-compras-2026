using System.Collections;
using ListaDeCompras.ConsoleApp.Compartilhado;

namespace ListaDeCompras.ConsoleApp.ModuloCategoria;

public class RepositorioCategoria : RepositorioBase
{
    public bool VerificarDuplicado(string nome)
    {
        ArrayList? listaCategorias = SelecionarTodos();

        foreach (Categoria c in listaCategorias)
        {
            if (c.Nome == nome)
                return true;
        }
        return false;
    }
};

