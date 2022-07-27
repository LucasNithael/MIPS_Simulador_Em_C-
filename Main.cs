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
      if(aux[0].ToLower()=="sub"){
        rs = Formar(aux[2]);
        string rt = Formar(aux[3]);
        string rd = Formar(aux[1]);
        string function = "100010";
        return opcode+rs+rt+rd+shamt+function;
      }
      if(aux[0].ToLower()=="and"){
        rs = Formar(aux[2]);
        string rt = Formar(aux[3]);
        string rd = Formar(aux[1]);
        string function = "100100";
        return opcode+rs+rt+rd+shamt+function;
      }
      if(aux[0].ToLower()=="or"){
        rs = Formar(aux[2]);
        string rt = Formar(aux[3]);
        string rd = Formar(aux[1]);
        string function = "100100";
        return opcode+rs+rt+rd+shamt+function;
      }
      if(aux[0].ToLower()=="xor"){
        string rt = Formar(aux[3]);
        string rd = Formar(aux[1]);
        shamt = Formar(aux[2]);
        string function = "100110";
        return opcode+rs+rt+rd+shamt+function;
      }
      if(aux[0].ToLower()=="nor"){
        string rt = Formar(aux[3]);
        string rd = Formar(aux[1]);
        shamt = Formar(aux[2]);
         string function = "100111";
        return opcode+rs+rt+rd+shamt+function;
      }
       
      if(aux[0].ToLower()=="slt"){
        string rt = Formar(aux[3]);
        string rd = Formar(aux[1]);
        shamt = Formar(aux[2]);
        string function = "101010";
        return opcode+rs+rt+rd+shamt+function;
      }
    return " ";
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
    foreach(object i in codes)
      Console.WriteLine(i);
    return codes;
  }
  
}




    