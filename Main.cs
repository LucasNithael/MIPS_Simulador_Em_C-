using System;
using System.IO;
using System.Collections.Generic;


//     [ OpCode  rs rt rd shamt functio ]
//     add rd rs rt


public class Program {
  public static void Main(string[] args) {
    AbrirTxt("teste.txt");
  }
  
  public static string Codificar(string s){
    string[] aux = s.Split(" ");
    string opcode = "000000";
    string shamt = "00000";
    string rs = "00000";
    if(aux[0].ToLower()=="add"){
        rs = Formar(aux[2]);
        string rt = Formar(aux[3]);
        string rd = Formar(aux[1]);
        string function = "100000";
        return opcode+rs+rt+rd+shamt+function;
      }
      if(aux[0].ToLower()=="sub")
        function = "100010";
      if(aux[0].ToLower()=="and")
        function = "100100";
      if(aux[0].ToLower()=="or")
        function = "100101";
      if(aux[0].ToLower()=="xor")
        function = "100110";
      if(aux[0].ToLower()=="nor")
        function = "100111";
      if(aux[0].ToLower()=="slt")
        function = "101010";

    return function;
  }
  
 
  public static string Formar(string a){
    string rt = " ";
    if(a.IndexOf("$")==-1){
      rt = Conversor(a);
      return rt;
    }
    a = a.Remove(0, 1);
    rt = Conversor(a);
    return rt;
  }
  
  public static string Conversor(string x){
    Stack<int> p = new Stack<int>();
    int num = int.Parse(x);
    int n;
    for(int i=0 ; i<5; i++){
      n=num%2;
      p.Push(n);
      num/=2;
    }
    string s = "";
    for(int i=0; i<5; i++)
      s += p.Pop().ToString();
    return s; 
  }
  public static List<string> AbrirTxt(string arquivo){
    StreamReader f = new StreamReader(arquivo);
    List<string> codes = new List<string>();
    string s = f.ReadLine();
    while (s != null) {
      codes.Add(Codificar(s));
      s = f.ReadLine();
    }
    f.Close(); 
    return codes;
  }
  
}




    