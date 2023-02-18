using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27_AOP.DesignPattern
{
    public class DecoratorPattern
    {
        public static void TestDecorator()
        {
            IProcessor processor = new Processor();

            processor.Process();


            Console.WriteLine("----------------------");

            var decorator = new ProcessDecorator(processor);

            decorator.Process();
        }
    }

    public interface IProcessor
    {
        void Process();
    }

    public class Processor : IProcessor
    {
        public void Process()
        {
            Console.WriteLine($"正在进行业务流程");
        }
    }

    public class ProcessDecorator : IProcessor
    {
        private IProcessor Processor;

        public ProcessDecorator(IProcessor processor)
        {
            this.Processor = processor;
        }

        public void Process()
        {
            BeforeProcess();
            Processor.Process();
            AfterProcess();
        }

        private void BeforeProcess()
        {
            Console.WriteLine("业务流程前的鉴权验证");
        }

        private void AfterProcess()
        {
            Console.WriteLine("业务流程后的日志记录与其他回调");
        }
    }
}
