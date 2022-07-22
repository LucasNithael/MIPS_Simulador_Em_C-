using System;
using System.IO;
using System.Collections.Generic;


//     [ OpCode  rs rt rd shamt functio ]
//     add rd rs rt

public class Program {
  public static void Main(string[] args) {
    AbrirTxt("teste.txt");
  }
  public static string Function(string s){
    string function = "";
    s = s.ToLower();
    if(s=="add")
      function = "100000";
    if(s=="sub")
      function = "100010";
    if(s=="and")
      function = "100100";
    if(s=="or")
      function = "100101";
    if(s=="xor")
      function = "100110";
    if(s=="nor")
      function = "100111";
    if(s=="slt")
      function = "101010";

    return function;
  }
  
  public static string Rd(string a){
    string rd = a.Remove(0, 1);
    rd = Conversor(rd);
    return rd;
  }
  
  public static string Rt(string a){
    if(a.IndexOf("$")==-1) return "00000";
    a = a.Remove(0, 1);
    string rt = Conversor(a);
    return rt;
  }

  public static string Shamt(string a){
    if(a.IndexOf("$")!=-1) return "00000";
    string shamt = Conversor(a);
    return shamt;
  }

  public static string Rs(string a){
    string rs = a.Remove(0, 1);
    rs = Conversor(rs);
    return rs;
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
  public static void AbrirTxt(string arquivo){
    StreamReader f = new StreamReader(arquivo);
    List<string> codes = new List<string>();
    string s = f.ReadLine();
    while (s != null) {
      string[] v = s.Split(' ');
      codes.Add(Rs(v[2])+" "+Rt(v[3])+" "+Rd(v[1])+" "+Shamt(v[3])+" "+Function(v[0]));
      s = f.ReadLine();
    }
    Console.WriteLine("  op     rs    rt    rs  shamp  funct");
    foreach(object i in codes)
      Console.WriteLine("000000 "+i);
    f.Close();
    
    StreamWriter x = new StreamWriter("codes.txt");
    foreach(object i in codes)
      x.WriteLine("000000 "+i);
    x.Close();
  }
}

    