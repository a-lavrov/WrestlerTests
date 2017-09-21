using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WrestlerTests.APITests.APIs;
using Wrestler.Utils;

namespace WrestlerTests.APITests.Tests
{
    public class BaseAPITests
    {
        private Lazy<WrestlerAPI> _wrestler = new Lazy<WrestlerAPI>(() => new WrestlerAPI());
        protected WrestlerAPI Wrestler => _wrestler.Value;
        protected string PathToFiles => ConfigSettingsReader.PathToFilesForUpload;

    }
}
