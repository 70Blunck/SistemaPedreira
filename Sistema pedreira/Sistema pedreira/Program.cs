﻿using System;                       //Pedro Henrique de Paula e Caio Wingler
using System.Collections.Generic;

class Bloco             //Class para representar um bloco cadastrado
{
    public string Codigo { get; set; }
    public string NumeroBloco { get; set; }
    public double Medidas { get; set; }
    public string Descricao { get; set; }
    public string TipoMaterial { get; set; }
    public decimal ValorCompra { get; set; }
    public decimal ValorVenda { get; set; }
    public string Pedreira { get; set; }
}

class Program
{
    static List<Bloco> blocos = new List<Bloco>();

    static void Main(string[] args)         
    {
        bool sair = false;
        while (sair == false)         //While para criar o menu menu   
        {                               
            Console.Clear();
            Console.WriteLine(">>> Gestão de Blocos <<<");
            Console.WriteLine("1 – Cadastrar Bloco");
            Console.WriteLine("2 – Listar Blocos");
            Console.WriteLine("3 – Buscar Bloco por código");
            Console.WriteLine("4 – Listar Blocos por pedreira");
            Console.WriteLine("5 - SAIR");

            Console.Write("Digite a opção desejada: ");
            string opcao = Console.ReadLine();

            switch (opcao)              //switch para executar as opções do menu
            {
                case "1":
                    CadastrarBloco();
                    break;
                case "2":
                    ListarBlocos();
                    break;
                case "3":
                    BuscarBlocoPorCodigo();
                    break;
                case "4":
                    ListarBlocosPorPedreira();
                    break;
                case "5":
                    Console.WriteLine("Tchau");
                    sair = true;
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    static void CadastrarBloco()            //Função para cadastrar um bloco
    {
        Console.WriteLine(">>> Cadastrar Bloco <<<");
        Bloco bloco = new Bloco();           //criando o array de bloco

        Console.Write("Código: ");
        bloco.Codigo = Console.ReadLine();

        Console.Write("Número do Bloco: ");
        bloco.NumeroBloco = Console.ReadLine();

        Console.Write("Medidas (metros cúbicos): ");
        if (double.TryParse(Console.ReadLine(), out double medidas))    //se o valor for valido para as medidas, receba medidas
        {
            bloco.Medidas = medidas;
        }
        else                                                            //senão escreva que é invalido
        {
            Console.WriteLine("Valor inválido para as medidas.");
            return;
        }

        Console.Write("Descrição: ");
        bloco.Descricao = Console.ReadLine();

        Console.Write("Tipo de Material (mármore ou granito): ");
        bloco.TipoMaterial = Console.ReadLine();

        Console.Write("Valor de Compra: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal valorCompra))   //se o valor for valido para valor da compra, receba o valor da compra
        {
            bloco.ValorCompra = valorCompra;
        }
        else                                                                 //senão escreva que o valor é invalido para compra
        {
            Console.WriteLine("Valor inválido para o valor de compra.");
            return;
        }

        Console.Write("Valor de Venda: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal valorVenda))   //se o valor for valido para valor da venda, receba valor da venda
        {
            bloco.ValorVenda = valorVenda;
        }
        else                                                                //senão escreva que é invalido
        {
            Console.WriteLine("Valor inválido para o valor de venda.");
            return;
        }

        Console.Write("Pedreira: ");
        bloco.Pedreira = Console.ReadLine();

        blocos.Add(bloco);
        Console.WriteLine("Bloco cadastrado com sucesso!");
        Console.WriteLine("Pressione qualquer tecla para continuar");
        Console.ReadKey();
    }

    static void ListarBlocos()                  //Função para listar os blocos
    {
        Console.WriteLine(">>> Listar Blocos <<<");
        foreach (var bloco in blocos)           //Foreach para listar os blocos cadastrados
        {
            Console.WriteLine($"Código: {bloco.Codigo}");
            Console.WriteLine($"Número do Bloco: {bloco.NumeroBloco}");
            Console.WriteLine($"Medidas (metros cúbicos): {bloco.Medidas}");
            Console.WriteLine($"Descrição: {bloco.Descricao}");
            Console.WriteLine($"Tipo de Material: {bloco.TipoMaterial}");
            Console.WriteLine($"Valor de Compra: {bloco.ValorCompra}");
            Console.WriteLine($"Valor de Venda: {bloco.ValorVenda}");
            Console.WriteLine($"Pedreira: {bloco.Pedreira}");
            Console.WriteLine();
        }
        Console.WriteLine("Pressione qualquer tecla para continuar");
        Console.ReadKey();
    }

    static void BuscarBlocoPorCodigo()                 //Função para buscar um bloco pelo código
    {
        Console.WriteLine(">>> Buscar Bloco por Código <<<");
        Console.Write("Digite o código do bloco: ");
        string codigo = Console.ReadLine();

        var blocoEncontrado = blocos.Find(bloco => bloco.Codigo == codigo);

        if (blocoEncontrado != null)                    //Se existir blocos cadastrados com o codigo, liste os blocos
        {
            Console.WriteLine($"Código: {blocoEncontrado.Codigo}");
            Console.WriteLine($"Número do Bloco: {blocoEncontrado.NumeroBloco}");
            Console.WriteLine($"Medidas (metros cúbicos): {blocoEncontrado.Medidas}");
            Console.WriteLine($"Descrição: {blocoEncontrado.Descricao}");
            Console.WriteLine($"Tipo de Material: {blocoEncontrado.TipoMaterial}");
            Console.WriteLine($"Valor de Compra: {blocoEncontrado.ValorCompra}");
            Console.WriteLine($"Valor de Venda: {blocoEncontrado.ValorVenda}");
            Console.WriteLine($"Pedreira: {blocoEncontrado.Pedreira}");
        }
        else                                           //Se não existir, escreva que não existe 
        {
            Console.WriteLine("Bloco não encontrado.");
        }
        Console.WriteLine("Pressione qualquer tecla para continuar");
        Console.ReadKey();
    }

    static void ListarBlocosPorPedreira()               //Função para listar um bloco pela pedreira
    {
        Console.WriteLine(">>> Listar Blocos por Pedreira <<<");
        Console.Write("Digite o nome da pedreira: ");
        string pedreira = Console.ReadLine();

        var blocosPedreira = blocos.FindAll(bloco => bloco.Pedreira == pedreira);

        if (blocosPedreira.Count > 0)                  //Se existir blocos cadastrados na pedreira escolhida, liste os blocos
        {
            Console.WriteLine($"Blocos da pedreira '{pedreira}':");
            foreach (var bloco in blocosPedreira)
            {
                Console.WriteLine($"Código: {bloco.Codigo}");
                Console.WriteLine($"Número do Bloco: {bloco.NumeroBloco}");
                Console.WriteLine($"Medidas (metros cúbicos): {bloco.Medidas}");
                Console.WriteLine($"Descrição: {bloco.Descricao}");
                Console.WriteLine($"Tipo de Material: {bloco.TipoMaterial}");
                Console.WriteLine($"Valor de Compra: {bloco.ValorCompra}");
                Console.WriteLine($"Valor de Venda: {bloco.ValorVenda}");
                Console.WriteLine($"Pedreira: {bloco.Pedreira}");
                Console.WriteLine();
            }
        }
        else                                        //Se não existir, escreva que não existe blocos cadastrados na pedreira
        {
            Console.WriteLine($"Nenhum bloco encontrado para a pedreira '{pedreira}'.");
        }
        Console.WriteLine("Pressione qualquer tecla para continuar");
        Console.ReadKey();
    }
}