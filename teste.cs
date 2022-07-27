using System;

class Program{
  public static void Main(){
    string nome = "1000";
    string novo = " ";
    for(int i=0; i<3; i++)
      novo = novo + nome[i];
    int num = int.Parse(novo);
  Console.Write(num+9);    
  }
  
}