using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WrestlerTests.Data;
using WrestlerTests.Models;
using Wrestler.Utils;
using System.IO;
using WrestlerTests.Utils;

namespace WrestlerTests.APITests.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Children)]
    public class WrestlerAPITests : BaseAPITests
    {
        [Test, TestCaseSource(typeof(DataProvider), "CreateWrestlerAPITest")]
        public void CreateWrestlerTest(WrestlerModel model)
        {
            var id = Wrestler.Create(model);
            
            // compare models
            var modelCurrent = Wrestler.Read(id);
            model.CompareModels(modelCurrent);
        }

        [Test, TestCaseSource(typeof(DataProvider), "CreateWrestlerWithAttachmentAPITest")]
        public void CreateWrestlerUploadAndDeleteAttachmentTest(WrestlerModel model)
        {
            var id = Wrestler.Create(model);

            var attachModel = Wrestler.UploadAttachment(id, PathToFiles + model.attaches[0].filename);
            var result = Wrestler.DeleteAttachment(attachModel.id).result;
            Assert.AreEqual(true, Boolean.Parse(result));
        }

        [Test, TestCaseSource(typeof(DataProvider), "CreateWrestlerWithTwoTextAttachmentsAPITest")]
        public void CreateWrestlerWithTwoTextAttachmentsTest(WrestlerModel model)
        {
            var id = Wrestler.Create(model);
            
            for (int i = 0; i < model.attaches.Count; i++)
            {
                var attachModel = Wrestler.UploadAttachment(id, PathToFiles + model.attaches[i].filename);

                //compare attachment model

            }

            
        }

        [Test, TestCaseSource(typeof(DataProvider), "CreateWrestlerWithPhotoAttachmentAPITest")]
        public void CreateWrestlerWithPhotoAttachmentAPITest(WrestlerModel model)
        {
            var id = Wrestler.Create(model);
                        
            var attachModel = Wrestler.UploadPhoto(id, PathToFiles + model.attaches[0].filename);

            //compare models
            var modelCurrent = Wrestler.Read(id);
            model.CompareModels(modelCurrent);
        }

               


        [Test]
        public void FetchWrestler()
        {
            var model = Wrestler.Fetch("9250");
            
            //compare models
        }

        [Test]
        public void FetchWrestler1()
        {
            var model = Wrestler.Fetch("9250");

            //compare models
        }
        [Test]
        public void FetchWrestler2()
        {
            var model = Wrestler.Fetch("9250");

            //compare models
        }
        [Test]
        public void FetchWrestler3()
        {
            var model = Wrestler.Fetch("9250");

            //compare models
        }
        [Test]
        public void FetchWrestler4()
        {
            var model = Wrestler.Fetch("9250");

            //compare models
        }
        [Test]
        public void FetchWrestler5()
        {
            var model = Wrestler.Fetch("9250");

            //compare models
        }
        [Test]
        public void FetchWrestler6()
        {
            var model = Wrestler.Fetch("9250");

            //compare models
        }
        [Test]
        public void FetchWrestler7()
        {
            var model = Wrestler.Fetch("9250");

            //compare models
        }
        [Test]
        public void FetchWrestler8()
        {
            var model = Wrestler.Fetch("9250");

            //compare models
        }
        [Test]
        public void FetchWrestler9()
        {
            var model = Wrestler.Fetch("9250");

            //compare models
        }
        [Test]
        public void ReadWrestler()
        {
            var model = Wrestler.Read("9250");
            
            //compare models
        }

        [Test]
        public void DeleteWrestler()
        {
            Wrestler.Delete("9255");


        }

        [Test]
        public void DeleteSeveralWrestlers()
        {
            Wrestler.Delete(new List<string>() { "9252", "9254", "9253", "9251" });
            
            
        }



    }
}
