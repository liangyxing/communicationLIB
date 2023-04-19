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
            return file.FullPath;
        }
    }
}
