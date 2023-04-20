using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPCDAApp.Tools.FilesOperation
{
	public class OpenFile
	{
		public async Task<string> Open()
		{
			var file = await FilePicker.PickAsync(new PickOptions
			{
				PickerTitle = "Select a file",

			});
			if (file != null)

				return file.FullPath;
			else
				return null;
		}

		public async Task Read(string machineName)
		{
			string pathName = await this.Open();
			var res = new OPCDA.DAServices.Servicses();
			await res.SaveNodeServiceAsync(machineName, pathName);
		}
	}
}
