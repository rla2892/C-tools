using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressBar
{
    public class ProgressBar
    {
        private int _lastOutputLength;
        private readonly int _maximumWidth;

        public ProgressBar(int maximumWidth)
        {
            _maximumWidth = maximumWidth;
            Show(" [ ");
        }


        public void Update(double percent)
        {
            // Remove the last state           
            string clear = string.Empty.PadRight(_lastOutputLength, '\b');

            Show(clear);

            // Generate new state           
            int width = (int)(percent / 100 * _maximumWidth);
            int fill = _maximumWidth - width;
            string output = string.Format("{0}{1} ] {2}%", string.Empty.PadLeft(width, '='), string.Empty.PadLeft(fill, ' '), percent.ToString("0.0"));
            Show(output);
            _lastOutputLength = output.Length;
        }

        private void Show(string value)
        {
            Console.Write(value);
        }
    }
}

//사용 방법
//var progress = new ProgressBar(10);
//var (int i = 0; i < 101; i++)
//{
//  progress.Update(i);
//  System.Threading.Thread.Sleep(50);
//}
//Console.WriteLine();
