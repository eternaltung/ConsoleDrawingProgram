using System;
using System.Collections.Generic;
using System.Linq;
using DrawingProgram.Model;

namespace DrawingProgram.Command
{
	public class QuitCommand : ICommand
	{
		public void CommandValidation(List<string> cmd)
		{
			if (cmd == null)
				throw new ArgumentNullException("missing command arguments");

			if (cmd.Any())
				throw new ArgumentException("should have no arguments");
		}

		public Canvas ExecuteCommand()
		{
			Environment.Exit(Environment.ExitCode);
			return null;
		}
	}
}
