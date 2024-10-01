//João Pedro Valderrama dos Santos - 23140
//Maria Eduarda Martins Costa - 23580

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class ListaSimples<Dado>
             where Dado : IComparable<Dado>
{
    NoLista<Dado> primeiro, ultimo, anterior, atual;
    int quantosNos;
    bool primeiroAcessoDoPercurso;

    public ListaSimples()
    {
        primeiro = ultimo = anterior = atual = null;
        quantosNos = 0;
        primeiroAcessoDoPercurso = false;
    }

    public void PercorrerLista()
    {
        atual = primeiro;
        while (atual != null)
        {
            Console.WriteLine(atual.Info);
            atual = atual.Prox;
        }
    }

    //Método criado para pegar o elemento de acordo com seu índice
    public Dado PegarElementoPeloIndice(int indice)
    {
        if (EstaVazia)
            return default(Dado);
        IniciarPercursoSequencial();
        int contador = 0;
        while (PodePercorrer())
        {
            if (contador == indice)
                return atual.Info;
            PercorrerUmElementoLista();
            contador++;
        }
        return default(Dado);
    }

    //Método criado para percorrer a lista de um em um
    public void PercorrerUmElementoLista()
    {
        atual = atual.Prox;
    }
    public bool EstaVazia
    {
        get => primeiro == null;
    }
    public NoLista<Dado> Primeiro
    {
        get => primeiro;
    }
    public NoLista<Dado> Ultimo
    {
        get => ultimo;
    }
    public int QuantosNos
    {
        get => quantosNos;
    }

    public NoLista<Dado> Atual
    {
        get => atual;
    }

    public void InserirAntesDoInicio(Dado novoDado)
    {
        var novoNo = new NoLista<Dado>(novoDado);

        if (EstaVazia)
            ultimo = novoNo;

        novoNo.Prox = primeiro;
        primeiro = novoNo;
        quantosNos++;
    }

    public void InserirAposFim(Dado novoDado)
    {
        var novoNo = new NoLista<Dado>(novoDado);

        if (EstaVazia)
            primeiro = novoNo;
        else
            ultimo.Prox = novoNo;

        ultimo = novoNo;
        quantosNos++;
    }

    public void Listar(ListBox lsb)
    {
        lsb.Items.Clear();
        atual = primeiro;
        while (atual != null)
        {
            lsb.Items.Add(atual.Info);
            atual = atual.Prox;
        }
    }

    public void IniciarPercursoSequencial()
    {
        atual = primeiro;
    }

    public bool PodePercorrer()
    {
        return atual != null;
    }

    public bool Existe(Dado dado)
    {
        if (EstaVazia)
            return false;
        IniciarPercursoSequencial();
        while (PodePercorrer())
        {
            if(dado.CompareTo(atual.Info) == 0)
                return true;
            PercorrerUmElementoLista();
        }
        return false;
    }

    //Método criado para remover um dado dado
    public void Remover(Dado dado)
    {
        if (EstaVazia)
            return;

        IniciarPercursoSequencial();
        while (PodePercorrer())
        {
            // Use Equals para comparação de objetos
            if (atual.Info.Equals(dado))
            {
                // Se há somente um elemento na lista...
                if (anterior == null && quantosNos == 1) 
                {
                    primeiro = atual = ultimo = null;
                }
                // Se o elemento a ser removido é o primeiro da lista...
                else if (anterior == null)
                {
                    primeiro = atual.Prox;
                }
                else
                {
                    anterior.Prox = atual.Prox;
                }

                quantosNos--;
                break;
            }

            // Move anterior para atual e vai para o próximo elemento
            anterior = atual;
            PercorrerUmElementoLista(); 
        }
    }



}
