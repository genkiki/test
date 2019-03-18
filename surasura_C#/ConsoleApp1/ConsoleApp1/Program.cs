using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World.");

            // @をつけるとキーワードも変数にできる
            int @out = 0;

            // JavaScriptとかで使えるやつ
            var kata_suiron = "勝手に型を決めてくれる";

            // 実行時に型を決めてくれる
            // TODO:varとの違いは？
            dynamic douteki_kataduke = "dynamic!";

            // TODO:わかんない＞＜
            // int null_kyoyou? = null;

            Console.WriteLine("エスケープシーケンス：");
            Console.WriteLine("改行：\\n　\n");
            Console.WriteLine("タブ：\\t　\t");
            Console.WriteLine("単一引用符：\\'　\'");
            Console.WriteLine("二重引用符：\\"　+"\""+ "　\"");
            Console.WriteLine("16進数：\\uXXXX　\u0001");

            // 逐後的文字列リテラル
            var tikugoteki_mojiretu = @"\がそのまま表示される \n 
改行できる";
            Console.WriteLine(tikugoteki_mojiretu);

            var x = 2;
            var y = 3;

            // 普通
            Console.WriteLine("{0} + {1} = {2}", x, y, x+y);

            // 省略
            string s = $"{x} + {y} = {x + y}";
            Console.WriteLine(s);

            int age = 18;
            Console.WriteLine($"{(age < 18 ? "未成年":"成人")}");

            // {x},{y}
            // 2つ重ねると{}を表示できる
            Console.WriteLine($"{{{x},{y}}}");

            var one = 1;
            var two = 2;
            var three = 3;

            //$@の合わせ技
            var str = $@"1, ""one"" {one}
2, ""two"" {two} \n
3, ""three"" {three}";
            Console.WriteLine(str);

            var nonNullStr = (str != null) ? str : "null dayo-";
            // null合体演算子 strがnullなら"null dayo-"が代入される
            var null_gattai = str ?? "null dayo-";

        }
    }
}
