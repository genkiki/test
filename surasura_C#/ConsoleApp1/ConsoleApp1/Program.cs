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

            //Person person = new Person();
            Person person = null;
            var name = (person != null) ? person.Name : null;

            // null条件演算子 personがnullでも、落ちずにnullを返す。
            var null_jouken = person?.Name;
            Console.WriteLine(null_jouken);

            // null合体演算子 and null条件演算子
            var null_gattai_jouken = person?.Name ?? "null null dayo-";
            Console.WriteLine(null_gattai_jouken);
            
            // nameof演算子 変数やクラスの名前が変わったときに
            // コンパイルエラーで検知できる
            Console.WriteLine($"{ nameof(x)} = {x}");

            // checked,uncheckedでオーバーフローの検出
            try
            {
                unchecked
                {
                    // こっちではエラーにならない
                    Console.WriteLine("uncheckedステートメント");
                    sbyte a = 64;
                    sbyte b = 65;
                    sbyte c = (sbyte)(a + b);
                }

                checked
                {
                    // こっちではエラーになる
                    Console.WriteLine("checkedステートメント");
                    sbyte a = 64;
                    sbyte b = 65;
                    sbyte c = (sbyte)(a + b);
                }
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }


            try
            {
                // こっちではエラーにならない
                Console.WriteLine("unchecked式");
                int seed = 10;
                seed = unchecked(seed * 1664525 + 1013904223);
                
                // こっちではエラーになる
                Console.WriteLine("checked式");
                seed = checked(seed * 1664525 + 1013904223);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // 型推論と配列宣言
            var array1 = new int[] {1, 2, 3 };
            var array2 = new[] { 1, 2, 3 };
            int[] array3 = { 1, 2, 3 };
            // 下記はコンパイルエラー
            //var[] array4 = { 1, 2, 3 };

            // ジャグ配列(ギザギザ)
            // 配列ごとに長さが違う
            int[][] jag_array = new int[][]
            {
                new int[] { 1, 2, 3 },
                new int[] { 4, 5 },
            };

            // ジャグ配列(ギザギザ)の型推論
            var jag_array_katasuiron = new[]
            {
                new[] { 1, 2, 3 },
                new[] { 4, 5 }
            };
            
            Console.WriteLine(jag_array_katasuiron[0][2]);

            // 多次元配列(四角)
            // 同じ長さの配列
            int[,] tajigen_array =
            {
                { 1, 2, 3},
                { 4, 5, 6},
            };

            // 多次元配列(四角)の型推論
            var tajigen_array_katasuiron = new[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
            };
            
            Console.WriteLine(jag_array_katasuiron[0][2]);

            // 匿名型
            var tokumei = new { Level = 10, Title = "tokumei" };
            Console.WriteLine($"{tokumei.Level}：{tokumei.Title}");


            var tokumei1 = new { Level = 10, Title = "tokumei1" };
            var tokumei2 = new { Level = 15, Title = "tokumei2" };
            var tokumei3 = new { Level = "20", Title = "tokumei3" };

            // tokumei1とtokumei2は同じ型
            var tokumei_array = new[] { tokumei1, tokumei2};
            Console.WriteLine(tokumei_array[0].Level);

            // tokumei1とtokumei3は違う型 コンパイルエラー
            // var tokumei_tigau_array = new[] { tokumei1, tokumei3 };

            // 型が不明のためコンパイルエラー
            // var tokumei_null = new { Name = null };
            
            // 型がstringと明記されているため通る
            string tokumei_name = null;
            var tokumei_null = new { Name = tokumei_name };
        }
    }

    class Person
    {
        public string Name;
    }
}
