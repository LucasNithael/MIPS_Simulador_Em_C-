using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Program {
  public static void Main(string[] args) {
    
    String[] r = new String[32];
    for(int i=0; i<32; i++)
      r[i] = "$"+i; 
    int index = 4;
    r[index] = "$"+index+0;
    foreach(object i in r)
      Console.WriteLine(i);
    //AbrirTxt("teste.txt");
  }  
  public static string Codificar(string s){
    string[] aux = s.Split(" ");
    string opcode = "000000", shamt = "00000";
    if(aux[0].ToLower()=="add"){
      string function = "100000";  
      string x = opcode+Formar(aux[2])+Formar(aux[3])+Formar(aux[1])+shamt+function;
      return BinarioHexadecimal(x);
      }
      if(aux[0].ToLower()=="sub"){
        string function = "100010";
        string x = opcode+Formar(aux[2])+Formar(aux[3])+Formar(aux[1])+shamt+function;
        return BinarioHexadecimal(x);
      }
      if(aux[0].ToLower()=="and"){
        string function = "100100";
        string x = opcode+Formar(aux[2])+Formar(aux[3])+Formar(aux[1])+shamt+function;
        return BinarioHexadecimal(x);
      }
      if(aux[0].ToLower()=="or"){
        string function = "100101";
        string x = opcode+Formar(aux[2])+Formar(aux[3])+Formar(aux[1])+shamt+function;
        return BinarioHexadecimal(x);
      }
      if(aux[0].ToLower()=="xor"){
        string function = "100110";
        string x = opcode+Formar(aux[2])+Formar(aux[3])+Formar(aux[1])+shamt+function;
        return BinarioHexadecimal(x);
      }
      if(aux[0].ToLower()=="nor"){
        string function = "100111";
        string x = opcode+Formar(aux[2])+Formar(aux[3])+Formar(aux[1])+shamt+function;
        return BinarioHexadecimal(x);
      }
       
      if(aux[0].ToLower()=="slt"){
        string function = "101010";
        string x = opcode+Formar(aux[2])+Formar(aux[3])+Formar(aux[1])+shamt+function;
        return BinarioHexadecimal(x);
      }
    return null;
  }
  
 
  public static string Formar(string a){
    string rt = " ";
    if(a.IndexOf("$")==-1){
      rt = DecimalBinario(a);
      return rt;
    }
    a = a.Remove(0, 1);
    rt = DecimalBinario(a);
    return rt;
  }
  
  public static string DecimalBinario(string x){
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
  public static string BinarioHexadecimal(string s){
    string aux = "";
    string hex  = "";
    for(int j=0; j<8; j++){
      for(int i=0; i<4; i++){
        aux = aux + s[i];
      }
      hex = hex + BinarioHexadecimal2(aux);
      s = s.Remove(0, 4);
      aux = "";
      }
    return hex;
  }
  public static string BinarioHexadecimal2(string numeroBinario){
    int expoente = 0;
    int numero;
    int soma = 0;
    string numeroInvertido = ReverteString(numeroBinario);
    for (int i = 0; i < numeroInvertido.Length; i++){
      numero = Convert.ToInt32(numeroInvertido.Substring(i, 1));
      soma += numero * (int)Math.Pow(2, expoente);
      expoente++;
            }
    string result = Convert.ToString(soma);
    if(result=="10") result = "a";
    if(result=="11") result = "b";
    if(result=="12") result = "c";
    if(result=="13") result = "d";
    if(result=="14") result = "e";
    if(result=="15") result = "f";
    return result;
  }
  public static string ReverteString(string str){
    return new string(str.Reverse().ToArray());
  }
  
  
}




    