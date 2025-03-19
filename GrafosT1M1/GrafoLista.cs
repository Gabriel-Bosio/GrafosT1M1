using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafosT1M1
{
    internal class GrafoLista
    {
        private bool _ponderado;
        private bool _direcionado;
        private List<string> _vertices;

        public List<string> Vertices
        {
            get { return _vertices; }
            set { _vertices = value; }
        }

        private List<List<(int destino, float peso)>> _grafo;

        public List<List<(int destino, float peso)>> Grafo
        {
            get { return _grafo; }
            set { _grafo = value; }
        }

        public GrafoLista(bool ponderado, bool direcionado)
        {
            this._ponderado = ponderado;
            this._direcionado = direcionado;
            _vertices = new List<string>();
            _grafo = new List<List<(int destino, float peso)>>();
        }

        public bool InserirVertice(string label)
        {
            // Não insere caso label já existir
            if (Vertices.Any(x => x.Equals(label)))
            {
                return false;
            }
            Vertices.Add(label);
            Grafo.Add(new List<(int destino, float peso)>());
            return true;
        }

        public bool RemoverVertice(int indice)
        {
            if (indice < 0 || indice >= Vertices.Count)
                return false;

            Vertices.RemoveAt(indice);
            Grafo.RemoveAt(indice);

            // Remove todas as arestas que apontam para o vértice removido
            foreach (var lista in Grafo)
            {
                lista.RemoveAll(aresta => aresta.destino == indice);
            }

            // Atualiza os índices dos destinos das arestas
            for (int i = 0; i < Grafo.Count; i++)
            {
                for (int j = 0; j < Grafo[i].Count; j++)
                {
                    if (Grafo[i][j].destino > indice)
                    {
                        Grafo[i][j] = (Grafo[i][j].destino - 1, Grafo[i][j].peso);
                    }
                }
            }

            return true;
        }

        public string LabelVertice(int index)
        {
            return Vertices[index];
        }

        public void ImprimeGrafo()
        {
            Console.Clear();

            for (int i = 0; i < Vertices.Count; i++)
            {
                Console.Write(Vertices[i] + " -> ");
                foreach (var aresta in Grafo[i])
                {
                    Console.Write($"({Vertices[aresta.destino]}, {aresta.peso}) ");
                }
                Console.WriteLine();
            }
        }

        public bool InserirAresta(int origem, int destino, float peso = 1)
        {
            if (ExisteAresta(origem, destino)) return false;

            float val = !_ponderado && peso != 1 ? 1 : peso;

            Grafo[origem].Add((destino, val));

            // Se for um self-loop, não insere a aresta novamente
            if (!_direcionado && origem != destino)
            {
                Grafo[destino].Add((origem, val));
            }

            return true;
        }

        public bool RemoverAresta(int origem, int destino)
        {
            if (!ExisteAresta(origem, destino)) return false;

            Grafo[origem].RemoveAll(aresta => aresta.destino == destino);

            if (!_direcionado)
            {
                Grafo[destino].RemoveAll(aresta => aresta.destino == origem);
            }

            return true;
        }

        public bool ExisteAresta(int origem, int destino)
        {
            return Grafo[origem].Any(aresta => aresta.destino == destino);
        }

        public float PesoAresta(int origem, int destino)
        {
            var aresta = Grafo[origem].FirstOrDefault(a => a.destino == destino);
            return aresta.peso;
        }

        public List<int> RetornarVizinhos(int vertice)
        {
            return Grafo[vertice].Select(aresta => aresta.destino).ToList();
        }
    }
}
