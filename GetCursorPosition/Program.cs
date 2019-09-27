using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace GetCursorPosition
{
    /// <summary>
    /// Classe principal.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Obtem a posição do cursor na tela.
        /// Saiba mais em: https://www.pinvoke.net/default.aspx/user32.getcursorpos
        /// </summary>
        /// <param name="lpPoint">Recebe os valores de posicionamento.</param>
        /// <returns>Sucesso de retorno.</returns>
        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out Point lpPoint);

        /// <summary>
        /// Ponto de entrada da execução do programa.
        /// </summary>
        private static void Main()
        {
            Console.WriteLine("Type any key to catch cursor position or ESC to exit.");
            do
            {
                Console.WriteLine($"Keyboard X:{Console.CursorLeft} Y:{Console.CursorTop}");
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    GetCursorPos(out var mouse);
                    Console.WriteLine($"Mouse X:{mouse.X} Y:{mouse.Y}");
                }
                else
                {
                    Console.WriteLine("Mouse cursor works only on Windows.");
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}