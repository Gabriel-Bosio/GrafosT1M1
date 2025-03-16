using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafosT1M1
{
    internal class Controle
    {
        private GrafoMatriz grafoMatriz;
        private GrafoLista grafoLista;
        
        public Controle() { }

        public void Inicio()
        {

            Console.WriteLine("Criacao do grafo: \n");
            Console.WriteLine("Grafo Direcionado? (Arestas poderao ter uma só direcao) -- (y/n)");
            bool direcionado = Console.ReadLine().Equals("y")? true : false;

            Console.WriteLine("Grafo Ponderado? (Arestas poderao ter diferentes pesos)  -- (y/n)");
            bool ponderado = Console.ReadLine().Equals("y") ? true : false;

            grafoMatriz = new GrafoMatriz(ponderado, direcionado);
            grafoLista = new GrafoLista(ponderado, direcionado);

            Manipulacao();
        }

        private void Manipulacao()
        {

        }

    }
}
