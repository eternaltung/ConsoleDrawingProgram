using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingProgram.Command;
using DrawingProgram.Model;

namespace DrawingProgram
{
	class Program
	{
		static void Main(string[] args)
		{
			Canvas canvas = null;
			ShowDescription();
			while (true)
			{
				try
				{
					var input = Console.ReadLine().Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToList();
					var command = CommandFactory.CreateCommandInstance(input, canvas);
					var param = input.Skip(1).ToList();
					command.CommandValidation(param);
					canvas = command.ExecuteCommand();
					Console.WriteLine(canvas.ToString());
				}
				catch (ArgumentNullException ex)
				{
					Console.WriteLine(ex.ParamName);
				}
				catch (ArgumentException ex)
				{
					Console.WriteLine(ex.Message);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.ToString());
				}
			}
		}

		private static void ShowDescription()
		{
			Console.WriteLine(@"Command 		Description
C w h           Should create a new canvas of width w and height h.
L x1 y1 x2 y2   Should create a new line from (x1,y1) to (x2,y2). Currently only
                horizontal or vertical lines are supported. Horizontal and vertical lines
                will be drawn using the 'x' character.
R x1 y1 x2 y2   Should create a new rectangle, whose upper left corner is (x1,y1) and
                lower right corner is (x2,y2). Horizontal and vertical lines will be drawn
                using the 'x' character.
B x y c         Should fill the entire area connected to (x,y) with 'colour' c. The
				behaviour of this is the same as that of the 'bucket fill' tool in paint
				programs.
Q               Should quit the program.");
		}
	}
}
