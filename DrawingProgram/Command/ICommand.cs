using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingProgram.Model;

namespace DrawingProgram.Command
{
	public interface ICommand
	{
		void CommandValidation(List<string> cmd);

		Canvas ExecuteCommand();
	}
}
