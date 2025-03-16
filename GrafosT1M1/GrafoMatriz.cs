using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GrafosT1M1
{
    internal class GrafoMatriz
    {
        private bool _ponderado;
        private bool _direcionado;
        private List<string> _vertives;

        public List<string> Vertices
        {
            get { return _vertives; }
            set { _vertives = value; }
        }

        private List<List<float>> _grafo;

        public List<List<float>> Grafo
        {
            get { return _grafo; }
            set { _grafo = value; }
        }

        public GrafoMatriz(bool ponderado, bool direcionado) 
        {
            this._ponderado = ponderado;
            this._direcionado = direcionado;
            _vertives = new List<string>();
            _grafo = new List<List<float>>();
        }

        public bool InserirVertice(string label)
        {
            // Não insere caso label já existir
            if(Vertices.Any(x => x.Equals(label)))
            {
                return false;
            }
            Vertices.Add(label);

            int index = Vertices.IndexOf(label);

            Grafo.ForEach(x => x.Add(0));
            Grafo.Add(new List<float>());
            for (int i = 0; i <= index; i++) Grafo[index].Add(0);

            return true;
        }

        public bool RemoverVertice(int indice)
        {

            Vertices.RemoveAt(indice);
            Grafo.RemoveAt(indice);
            Grafo.ForEach(x => x.RemoveAt(indice));

            return true;
        }

        public string LabelVerice(int index)
        {
            return Vertices[index];
        }

        void ImprimeGrafo() // Em processo
        { 

            // Define o espaçamento entre colunas
            int maxS = Vertices.MaxBy(x => x.Length).Length + 2; 
            Console.Clear();

            // Gera primeira linha com labels
            GeraEspaco(maxS);
            for (int i = 0; i < Vertices.Count; i++)
            {
                Console.Write(Vertices[i]);
                GeraEspaco(maxS - Vertices[i].Length);
            }

            for (int i = 0; i < Vertices.Count; i++)
            {
                Console.Write(Vertices[i]);
                GeraEspaco(maxS - Vertices[i].Length);

                // Imprime coluna
                for (int j = 0; j < Vertices.Count; j++)
                {
                    Console.Write(Grafo[i][j]);
                    GeraEspaco(maxS - Grafo[i][j].ToString().Length);
                }
                Console.Write("\n\n");
            }

            Console.Write("Precione Enter para continuar...");
            Console.ReadLine();
        }

        private void GeraEspaco(int size)
        {
            for (int i = 0; i < size; i++)
            {
                Console.Write(" ");
            }

        }

        public bool InserirAresta(int origem, int destino, float peso = 1)
        {
            if (ExisteAresta(origem, destino) || peso < 1) return false;

            float val = !_ponderado && peso != 1 ? 1 : peso;

            Grafo[origem][destino] = val;

            if (!_direcionado) Grafo[destino][origem] = val;

            return true;
        }

        public bool RemoverAresta(int origem, int destino)
        {
            if (!ExisteAresta(origem, destino)) return false;

            Grafo[origem][destino] = 0;

            if (!_direcionado) Grafo[destino][origem] = 0;

            return true;
        }

        public bool ExisteAresta(int origem, int destino)
        {
            return Grafo[origem][destino] == 0 ? false : true;
        }

        public float PesoAresta(int origem, int destino)
        {
            return Grafo[origem][destino];
        }

        public List<int> RetornarVizinhos(int vertice)
        {
            List<int> vizinhos = new List<int>();
            for(int i = 0; i < Grafo[vertice].Count; i++)
            {
                if (Grafo[vertice][i] != 0) vizinhos.Add(i);
            }

            return vizinhos;
        }

    }
}
