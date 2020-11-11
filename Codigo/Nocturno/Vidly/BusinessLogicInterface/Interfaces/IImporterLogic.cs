using System.Collections.Generic;
using BusinessLogicInterface.Utils;

namespace BusinessLogicInterface
{
    public interface IImporterLogic
    {
        List<string> GetNames();
        void Import(ImporterModel import);
    }
}