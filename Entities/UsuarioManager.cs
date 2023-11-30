using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PassWords.Entities
{
    public class UsuarioManager
    {
        Dictionary<string, string> usuarios = new Dictionary<string, string>();
        string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ" + "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLower() + "!#$%&*@" + "0123456789";
        string senha = string.Empty;
        int quantidadeCaracter = 0;

        string userAdm = "adm";
        int passAdm = 123;
        public void ExecutarTarefa(){

            int opcao = -1;
            System.Console.WriteLine("Bem vindo ao gerador de senhas");
            


            while(opcao != 0){
                System.Console.WriteLine("----------------------------------- ");
                System.Console.WriteLine("Selecione uma opção ");
                System.Console.WriteLine("1. Gerar senha");
                System.Console.WriteLine("2. Alterar senha ");
                System.Console.WriteLine("3. Alterar email ");
                System.Console.WriteLine("4. Ver senhas geradas (admin) ");
                System.Console.WriteLine("0. Encerrar programa ");
                System.Console.Write("Opcao desejada: ");
                opcao = int.Parse(Console.ReadLine());
                System.Console.WriteLine("----------------------------------- ");

                switch (opcao)
                {
                    case 1:
                        GerarSenha();
                    break;

                    case 2:
                        AlterarSenha();
                    break;

                    case 3:
                        AlterarEmail();
                    break;

                    case 4:
                        ListarSenhas();
                    break;
                }
            }
        }

        private void GerarSenha(){

            System.Console.Write("Informe seu email: ");
            string email = Console.ReadLine();

            if(!usuarios.ContainsKey(email)){
                System.Console.Write("Informe a quantidade de caracter: ");
                quantidadeCaracter = int.Parse(Console.ReadLine());

                for(int i = 0; i < quantidadeCaracter; i++){
                    char caracterAleatorio = ObterCaracter(caracteres);
                    senha += caracterAleatorio;
                }
                System.Console.WriteLine("Senha gerada: " + senha);
                usuarios.Add(email,senha);
            }else{
                System.Console.WriteLine("Email já cadastrado");
            }

        }

        private void AlterarSenha(){
            System.Console.Write("Informe seu email: ");
            string email = Console.ReadLine();

            System.Console.Write("Informe a ultima senha gerada: ");
            string senha = Console.ReadLine();
            string novaSenha = string.Empty;
            if(!usuarios.ContainsKey(email)){
                System.Console.WriteLine("Email não encontrado");

            }else if(usuarios.ContainsKey(email) && usuarios.ContainsValue(senha)){
                System.Console.Write("Informe a quantidade de caracter: ");
                int quantidadeCaracter = int.Parse(Console.ReadLine());

                for(int i = 0; i < quantidadeCaracter; i++){
                    char caracterAleatorio = ObterCaracter(caracteres);
                    novaSenha += caracterAleatorio;
                }
                System.Console.WriteLine("Senha gerada: " + novaSenha);
                usuarios[email] = novaSenha;
            }
        }

        private void AlterarEmail(){
            System.Console.Write("Informe o email que deseja alterar: ");
            string email = Console.ReadLine();

            System.Console.Write("Informe sua senha: ");
            string senha = Console.ReadLine();

            string novoEmail = string.Empty;
            if(!usuarios.ContainsKey(email)){
                System.Console.WriteLine("Email não encontrado");

            }else if(usuarios.ContainsKey(email) && usuarios.ContainsValue(senha)){
                System.Console.Write("Informe o novo email: ");
                novoEmail = Console.ReadLine();

                usuarios.Remove(email);
                usuarios.Add(novoEmail,senha);
            }
        }

        private void ListarSenhas(){
            System.Console.Write("Informe a usuario do adm: ");
            string loginAdm = Console.ReadLine();
            System.Console.Write("Informe a senha do adm: ");
            int loginSenhaAdm = int.Parse(Console.ReadLine());

            if(loginAdm == userAdm && loginSenhaAdm == passAdm){
                foreach(var item in usuarios){
                System.Console.WriteLine("Usuario: " + item.Key);
                System.Console.WriteLine("Usuario: " + item.Value);
                }
            }else{
                System.Console.WriteLine("Acesso não permitido");
            }
            
        }

         static char ObterCaracter(string chave){
                  Random caracter = new Random();

                  int indice = caracter.Next(0, chave.Length);

                  return chave[indice];
            }      
    }
}