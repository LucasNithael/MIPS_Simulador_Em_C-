using System;
using System.Collections.Generic;

/*[ OpCode  rs rt rd shamt functio ]*/
public class Program {
  public static void Main(string[] args) {
    string[] v = Console.ReadLine().Split(" ");
    Console.WriteLine(Function(v[0])+" "+Rd(v[1])+" "+Rs(v[2])+" "+Rt(v[3]));
    //Console.WriteLine("Lucas".IndexOf("$"));
    
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
    string rt; 
    if(a.IndexOf("$")!=-1) a = a.Remove(0, 1);
    rt = Conversor(a);
    return rt;
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
}
    