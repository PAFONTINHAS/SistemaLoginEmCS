using System;
using System.IO;


class Program
{
    static void Main()
    {
           
            Console.WriteLine("Já possui conta? \n\n 1.Logar \n\nPrimeiro Acesso? \n\n 2.Cadastrar\n");

            int opcao = int.Parse(Console.ReadLine());

            escolha(opcao);
    }

    static void escolha( int opcao)
    {
        switch (opcao)
        {
            case 1:
                Logar();
                break;

            case 2:
                Cadastrar();
                break;
               
        }
    }

    static void Logar()
    {   
        Console.Write("Insira o email: ");
        string email = Console.ReadLine();

        Console.Write("Insira a senha : ");
        string senha = Console.ReadLine();

        ValidarLogin(email, senha);
    


    }

     static void ValidarLogin(string emailUsuario, string senha)
    {
        string VerificarAquivos = @"C:\\Users\\Aluno\\Downloads\\usuarios.txt";

        if (File.Exists(VerificarAquivos))
        {
            string[] linhas = File.ReadAllLines(VerificarAquivos);
            
            foreach(string linha in linhas)
            {
                string[] partes = linha.Split('\n',':');
                string Usuario = partes[0];
                string SenhaUsuario = partes[1];

                if(emailUsuario == Usuario && senha == SenhaUsuario)
                {
                    Console.WriteLine("Login efetuado com sucesso");
                    Sistema(Usuario, SenhaUsuario);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Email ou senha incorretos");
                    Logar();
                }
            }
            
     
        }
    }

    static void Cadastrar()
    {
        Console.Write("\nInsira o seu melhor email: ");
        string email = Console.ReadLine(); 
        
        //while (!email.Contains(" @gmail.com") || !email.Contains(" @hotmail.com"))
        //{
        //    Console.Write("insira um email válido: ");
        //    email = Console.ReadLine();
        //}

        Console.Write("\nInsira a sua melhor senha: ");
        string senha = Console.ReadLine();

        while( senha.Length < 8)
        {
            Console.Write("A senha deve possuir, no mínimo, 8 caracteres: ");
            senha = Console.ReadLine();
        }
      

        if(email.Contains("@gmail.com") || email.Contains("@hotmail.com") && senha.Length > 8)
        {
            string login = email + ":" + senha;
            string arquivoUsuarios = @"C:\\Users\\Aluno\\Downloads\\usuarios.txt";

            if (!File.Exists(arquivoUsuarios))
            {
                File.Create(arquivoUsuarios);
                File.WriteAllText(arquivoUsuarios, login);
            }
            else
            {
                using (StreamWriter writer = File.AppendText(arquivoUsuarios))

                writer.WriteLine("\n" + login);
            }

            Console.WriteLine("\nUsuario cadastrado com sucesso");
            Main();
        }
        else
        {
            Console.WriteLine("email precisa terminar com @gmail.com ou @hotmail.com");
            Cadastrar();
        }
        
    }

    static void Sistema(string Usuario, string SenhaUsuario)
    {
        Console.WriteLine("Bem vindo " + Usuario);
    }
}

        

