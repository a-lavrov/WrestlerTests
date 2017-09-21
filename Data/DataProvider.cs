using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WrestlerTests.Models;

namespace WrestlerTests.Data
{
    public class DataProvider
    {
        public static IEnumerable LoginTestCases
        {
            get
            {
                yield return new TestCaseData("auto", "test");
            }
        }

        public static IEnumerable CreateNewWrestler1
        {
            get
            {
                yield return new TestCaseData(new Dictionary<string, string>()
                {
                    { "Login",  "auto" },
                    { "Password", "test" },
                    { "LastName", "FakeLastName1" },
                    { "FirstName", "FakeFirstName1" },
                    { "DateOfBirth", "07.07.1907" },
                    { "MiddleName", "FakeMiddleName1" },
                    { "Region1", "Kyiv" },
                    { "Region2", "Kyivska" },
                    { "Fst1", "Kolos" },
                    { "Fst2", "SK" },
                    { "Trainer1", "FakeTrainer Trainer1" },
                    { "Trainer2", "FakeTrainer Trainer2 Name2" },
                    { "Style", "FW" },
                    { "Age", "Junior" },
                    { "Year", "2017" },
                    { "Card", "Produced" }
                });
                
            }
        }

        public static IEnumerable CreateWrestlerAPITest
        {
            get
            {
                yield return new TestCaseData(new ModelDataFillingHelper().GetFilledWrestlerModel(attachModels: null));
            }
        }

        public static IEnumerable CreateWrestlerWithTwoTextAttachmentsAPITest
        {
            get
            {
                yield return new TestCaseData(new ModelDataFillingHelper().GetFilledWrestlerModel(new List<AttachmentModel>()
                    { { new AttachmentModel() { filename = "testfile1.txt" } },
                      { new AttachmentModel() { filename = "testfile2.txt" } } }));
            }
        }

        public static IEnumerable CreateWrestlerWithAttachmentAPITest
        {
            get
            {
                yield return new TestCaseData(new ModelDataFillingHelper().GetFilledWrestlerModel(new List<AttachmentModel>()
                    { { new AttachmentModel() { filename = "testfile1.txt" } } }));
            }
        }

        public static IEnumerable CreateWrestlerWithPhotoAttachmentAPITest
        {
            get
            {
                yield return new TestCaseData(new ModelDataFillingHelper().GetFilledWrestlerModel(new List<AttachmentModel>()
                    {{ new AttachmentModel() { filename = "wrestler1.jpg" }}}));
            }
        }

        public static IEnumerable CreateNewWrestler2
        {
            get
            {
                yield return new TestCaseData(new Dictionary<string, string>()
                {
                    { "Login",  "auto" },
                    { "Password", "test" },
                    { "LastName", "FakeLastName2" },
                    { "FirstName", "FakeFirstName2" },
                    { "DateOfBirth", "20.12.1985" },
                    { "MiddleName", "FakeMiddleName2" },
                    { "Region1", "Kyiv" },
                    { "Region2", "Kyivska" },
                    { "Fst1", "Kolos" },
                    { "Fst2", "SK" },
                    { "Trainer1", "FakeTrainer Trainer1" },
                    { "Trainer2", "FakeTrainer Trainer2 Name2" },
                    { "Style", "FW" },
                    { "Age", "Junior" },
                    { "Year", "2017" },
                    { "Card", "Produced" }
                });

            }
        }

        public static IEnumerable CreateNewWrestler3
        {
            get
            {
                yield return new TestCaseData(new Dictionary<string, string>()
                {
                    { "Login",  "auto" },
                    { "Password", "test" },
                    { "LastName", "FakeLastName3" },
                    { "FirstName", "FakeFirstName3" },
                    { "DateOfBirth", "20.12.1985" },
                    { "MiddleName", "FakeMiddleName3" },
                    { "Region1", "Kyiv" },
                    { "Region2", "Kyivska" },
                    { "Fst1", "Kolos" },
                    { "Fst2", "SK" },
                    { "Trainer1", "FakeTrainer Trainer1" },
                    { "Trainer2", "FakeTrainer Trainer2 Name2" },
                    { "Style", "FW" },
                    { "Age", "Junior" },
                    { "Year", "2017" },
                    { "Card", "Produced" }
                });

            }
        }


    }
}
