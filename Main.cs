using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Program {
  public static void Main(string[] args) {
    //AbrirTxt("teste.txt");
    Registrador("teste.txt");
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
    if(aux[0].ToLower()=="addi"){
      opcode = "001000";
      string imm = DecimalBinario2(aux[3]); 
      string x = opcode+Formar(aux[2])+Formar(aux[1])+imm;
      return BinarioHexadecimal(x);
    }
    if(aux[0].ToLower()=="andi"){
      opcode = "001100";
      string imm = DecimalBinario2(aux[3]); 
      string x = opcode+Formar(aux[2])+Formar(aux[1])+imm;
      return BinarioHexadecimal(x);
    }
    if(aux[0].ToLower()=="ori"){
      opcode = "001101";
      string imm = DecimalBinario2(aux[3]); 
      string x = opcode+Formar(aux[2])+Formar(aux[1])+imm;
      return BinarioHexadecimal(x);
    }
    if(aux[0].ToLower()=="slti"){
      opcode = "001010";
      string imm = DecimalBinario2(aux[3]); 
      string x = opcode+Formar(aux[2])+Formar(aux[1])+imm;
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
  public static string DecimalBinario2(string x){
    Stack<int> p = new Stack<int>();
    int num = int.Parse(x);
    int n;
    for(int i=0 ; i<16; i++){
      n=num%2;
      p.Push(n);
      num/=2;
    }
    string s = "";
    for(int i=0; i<16; i++)
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
    return "0x"+hex;
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
  public static void Registrador(string arquivo){
    StreamReader f = new StreamReader(arquivo);
    int[] regs = new int[32];
    List<string> codes = new List<string>();
    string s = f.ReadLine();
    while (s != null) {
      string[] x = s.Split(" ");
      int a = int.Parse(x[1].Replace("$", ""));
      int b = int.Parse(x[2].Replace("$", ""));
      int c = int.Parse(x[3].Replace("$", ""));
      if(x[0]=="add"){
        regs[a] = regs[b]+regs[c];
        Console.WriteLine($"${a} = ${b} + ${c} = {regs[a]}");
      }
      if(x[0]=="sub"){
        regs[a] = regs[b]-regs[c];
        Console.WriteLine($"${a} = ${b} - ${c} = {regs[a]}");
      }
      if(x[0]=="and"){
        regs[a] = regs[b] & regs[c];
        Console.WriteLine($"${a} = ${b} and ${c} = {regs[a]}");
      }
      if(x[0]=="or"){
        regs[a] = regs[b] | regs[c];
        Console.WriteLine($"${a} = ${b} or ${c} = {regs[a]}");
      }
      if(x[0]=="xor"){
        regs[a] = regs[b] ^ regs[c];
        Console.WriteLine($"${a} = ${b} xor ${c} = {regs[a]}");
      }
      if(x[0]=="nor"){
        regs[a] = ~(regs[b] | regs[c]);
        Console.WriteLine($"${a} = ${b} nor ${c} = {regs[a]}");
      }
      if(x[0]=="slt"){
        if(regs[b]<regs[c]) regs[a] = 1;
        else regs[a] = 0;
        Console.WriteLine($"${a} = ${b} slt ${c} = {regs[a]}");
      }
      if(x[0]=="addi"){
        int imd = int.Parse(Convert.ToString(x[3]));
        regs[a] = regs[b] + imd;
        Console.WriteLine($"${a} = ${b} + {imd} = {regs[a]}");
      }
      if(x[0]=="subi"){
        int imd = int.Parse(Convert.ToString(x[3]));
        regs[a] = regs[b] - imd;
        Console.WriteLine($"${a} = ${b} - {imd} = {regs[a]}");
      }
      if(x[0]=="andi"){
        int imd = int.Parse(Convert.ToString(x[3]));
        regs[a] = regs[b] & imd;
        Console.WriteLine($"${a} = ${b} andi {imd} = {regs[a]}");
      }
      if(x[0]=="ori"){
        int imd = int.Parse(Convert.ToString(x[3]));
        regs[a] = regs[b] | imd;
        Console.WriteLine($"${a} = ${b} ori {imd} = {regs[a]}");
      }
      if(x[0]=="slti"){
        int imd = int.Parse(Convert.ToString(x[3]));
        if(regs[b]<imd) regs[a] = 1;
        else regs[a] = 0;
        Console.WriteLine($"${a} = ${b} slti {imd} = {regs[a]}");
      }
      
      s = f.ReadLine();
    }
    f.Close();
    StreamWriter j = new StreamWriter("Registradores.txt");
    for(int i=0; i<32; i++)
      j.WriteLine($"${i}: {regs[i]}");
    j.Close();
  }
  
}



/*
Instrucões cadastradas:

add
sub
and 
or 
slt
xor 
nor 
andi 
ori 
slti 

*/
    