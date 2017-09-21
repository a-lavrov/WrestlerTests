using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WrestlerTests.Models;

namespace WrestlerTests.Data
{
    public class ModelDataFillingHelper
    {
        private const string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        
        private Random randomStr;
        private Random randomInt;
        private Random randomDate;
        private static Object strLock, intLock, dateLock;


        public ModelDataFillingHelper()
        {
            randomStr = new Random();
            randomInt = new Random();
            randomDate = new Random();
            strLock = new Object();
            intLock = new Object();
            dateLock = new Object();
        }

        public string RandomString(int length)
        {
            lock (strLock)
            {
                return new string(Enumerable.Repeat(_chars, length)
                  .Select(s => s[randomStr.Next(s.Length)]).ToArray());
            }
        }

        public string RandomInt(int minValue, int maxValue)
        {
            lock (intLock)
            {
                return randomInt.Next(minValue, maxValue).ToString();
            }
        }

        public string GetRandomDate()
        {
            lock (dateLock)
            {
                var startDate = new DateTime(1980, 1, 1);
                int range = (DateTime.Today - startDate).Days - 5760; // 5760=~16 years

                var date = startDate.AddDays(randomDate.Next(range)).Date.ToString("dd-MM-yyyy");

                return date;
            }
        }

        public List<TrainerModel> GetFilledTrainerModel()
        {
            return new List<TrainerModel>()
            {
                new TrainerModel(){ id_trainer = "556", name = "Trainer1 T.T.", initials = "Trainer1 T.T." },
                new TrainerModel(){ id_trainer = "557", name = "Trainer2 T.T.", initials = "Trainer2 T.T."}
            };
        }

        public WrestlerModel GetFilledWrestlerModel(List<AttachmentModel> attachModels)
        {
            return new WrestlerModel
            {
                fname = "Fname" + RandomString(5),
                lname = "Lname" + RandomString(5),
                mname = "Mname" + RandomString(5),
                dob = GetRandomDate(),
                region1 = RandomInt(2, 28),
                region2 = RandomInt(2, 28),
                fst1 = RandomInt(2, 8),
                fst2 = RandomInt(2, 8),
                trainer1 = GetFilledTrainerModel()[Convert.ToByte(RandomInt(0, 1))],
                trainer2 = GetFilledTrainerModel()[Convert.ToByte(RandomInt(0, 1))],
                style = RandomInt(1, 3),
                lictype = RandomInt(1, 3),
                expires = RandomInt(2013, 2017),
                card_state = RandomInt(1, 3),
                attaches = attachModels
            };
            
        }
    }
}
