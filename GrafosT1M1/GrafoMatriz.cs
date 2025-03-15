using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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

        private List<List<int>> _grafos;

        public List<List<int>> Grafos
        {
            get { return _grafos; }
            set { _grafos = value; }
        }

        public GrafoMatriz(bool ponderado, bool direcionado) 
        {
            this._ponderado = ponderado;
            this._direcionado = direcionado;
            _vertives = new List<string>();
            _grafos = new List<List<int>>();
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

            Grafos.ForEach(x => x.Add(0));
            Grafos.Add(new List<int>());
            for (int i = 0; i <= index; i++) Grafos[index].Add(0);

            return true;
        }

        public bool RemoverVertice(int indice)
        {

            Vertices.RemoveAt(indice);
            Grafos.RemoveAt(indice);
            Grafos.ForEach(x => x.RemoveAt(indice));

            return true;
        }

        public string LabelVerice(int index)
        {
            return Vertices[index];
        }

        void ImprimeGrafo() // Em processo
        { 
            int maxS = Vertices.MaxBy(x => x.Length).Length + 2; 
            Console.Clear();

            for (int i = 0; i < maxS; i++)
            {
                Console.Write(" ");
            }

            for (int i = 0; i < Vertices.Count; i++)
            {
                Console.Write(Vertices[i]);
                for (int j = 0; j < maxS - Vertices[i].Length; j++)
                {
                    Console.Write(" ");
                }
            }

            for (int i = 0; i < Vertices.Count; i++)
            {
                Console.Write(Vertices[i]);
                for (int k = 0; k < maxS - Vertices[i].Length; k++)
                {
                    Console.Write(" ");
                }

                for (int j = 0; j < Vertices.Count; j++)
                {
                    Console.Write(Grafos[i][j]);
                    for (int k = 0; k < maxS - Grafos[i][j].ToString().Length; j++)
                    {
                        Console.Write(" ");
                    }
                }
                Console.Write("\n");
            }
            

        }
        
    }
}
