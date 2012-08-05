using System;
using System.Linq;

namespace EFDynamicModel
{
    class Program
    {
        const string LookupTable1 = "lookup1"; // 4 items
        const string LookupTable2 = "lookup2"; // 2 items

        static void Main()
        {
            Console.WriteLine("Scenario 1:");
            Scenario1();

            Console.WriteLine(Environment.NewLine + "Scenario 2:");
            Scenario2();
        }

        /// <summary>
        /// This scenario returns incorrect results. DbCompiledModel is built once and it's cached
        /// second context is still going to reference model created with first context.
        /// </summary>
        public static void Scenario1()
        {
            using (var context = new LookupContextV1(LookupTable1))
            {
                Console.Write(LookupTable1 + " count: ");
                Console.WriteLine(context.Items.Count());
            }

            using (var context = new LookupContextV1(LookupTable2))
            {
                Console.Write(LookupTable2 + " count: ");
                Console.WriteLine(context.Items.Count());
            }            
        }

        /// <summary>
        /// There is a way to overcome above issue - we need to build DbCompiledModel ourselves and pass
        /// it to DbContext. Creating compiled model is expensive operation so probably this is not 
        /// suitable for large/complex models.
        /// </summary>
        public static void Scenario2()
        {
            var m = new LookupModel();

            var model = m.Compile(LookupTable1);
            using (var context = new LookupContextV2(model))
            {
                Console.Write(LookupTable1 + " count: ");
                Console.WriteLine(context.Items.Count());
            }

            model = m.Compile(LookupTable2);
            using (var context = new LookupContextV2(model))
            {
                Console.Write(LookupTable2 + " count: ");
                Console.WriteLine(context.Items.Count());
            }            
        }

    }
}
