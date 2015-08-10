using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 *  CallOrderSample c;
 *  c = new CallOrderSample();
 * 呼び出される順序
 * TempClass default constructor(instance).
 * CallOrderSample static constructor.
 * TempClass paramed constructor(instance).
 * CallOrderSample default constructor(instance).
 * 
 * 呼び出し順
 * staticなパラメータ⇒自クラスのstatic⇒自クラスのパラメータ⇒自クラスのコンストラクタ
 * ※newしないとひとつも呼ばれない。
 * 
 * 3回呼ぶと
 * TempClass default constructor(instance).
 * CallOrderSample static constructor.
 * TempClass paramed constructor(instance).
 * CallOrderSample default constructor(instance). ⇒ 1回目
 * TempClass paramed constructor(instance).
 * CallOrderSample default constructor(instance). ⇒ 2回目
 * TempClass paramed constructor(instance).
 * CallOrderSample default constructor(instance). ⇒ 3回目
 * ※ staticは初回しか呼ばれない。
 * 
 * TempClass t = CallOrderSample.staticMemner;
 * を呼んでみると、
 * TempClass default constructor(instance).
 * CallOrderSample static constructor.
 * クラスのロード部分の処理？
 */
namespace Sample
{
    class TempClass
    {
        public TempClass()
        {
            Console.WriteLine("TempClass default constructor(instance).");
        }
        public TempClass(int i)
        {
            Console.WriteLine("TempClass paramed constructor(instance).");
        }
    }
    
    class CallOrderSample
    {
        public CallOrderSample()
        {
            Console.WriteLine("CallOrderSample default constructor(instance).");
        }
        public CallOrderSample(int i)
        {
            Console.WriteLine("CallOrderSample paramed constructor(instance).");
        }

        static CallOrderSample() {
            Console.WriteLine("CallOrderSample static constructor.");
        }
        public static TempClass staticMemner = new TempClass();
        public TempClass instanceMember = new TempClass(1);
    }
}
