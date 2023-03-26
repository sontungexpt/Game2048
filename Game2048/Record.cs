using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Resources;

namespace Game2048
{
    internal class Record : IComparable<Record>
    {
        #region Feilds (Private)
        private int score;
        private string accountName;
        private string storedFileName;
        private DateTime recordDay;
        private List<Record> records;
        #endregion

        #region Constructor (Public)
        public Record()
        {
            this.score = 0;
            this.accountName = null;
            recordDay = DateTime.Now;
        }
        public Record(string storedFileName)
        {
            this.score = 0;
            this.accountName = null;
            recordDay = DateTime.Now;
            if (storedFileName != null)
            {
                string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Game2048StiluxData/";

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                this.storedFileName = folderPath +  storedFileName + ".txt";
            }
        }
        public Record(string accountName, int score, DateTime recordDay)
        {
            this.score = score;
            this.accountName = accountName;
            this.recordDay = recordDay;
        }


        #endregion

        #region Properties (Public)
        public int Score
        {
            get { return score; }
            set { score = value; }
        }
        public string AccountName
        {
            get { return accountName; }
            //set { accountName = value; }
        }
        public string StoredFileName
        {
            get { return storedFileName; }
            //set { storedFileName = value; }
        }
        public DateTime RecordDay
        {
            get { return recordDay; }
        }

        #endregion

        #region Init_Method(Public)
        public void Init(string accountName, int score, DateTime recordDay)
        {
            this.score = score;
            this.accountName = accountName;
            this.recordDay = recordDay;
        }

        #endregion

        #region Method  (Public)

        public void Read()
        {
            records = new List<Record>();
            if (storedFileName == null)
            {
                Exception exception = new Exception("Need set up the file root to store");
                throw exception;
            }
            
            FileStream fileData = new FileStream(this.storedFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            StreamReader reader = new StreamReader(fileData);
            while (reader.Peek() != -1)
            {
                string tempName = reader.ReadLine();
                int tempScore = Convert.ToInt32(reader.ReadLine());
                DateTime tempRecordDay = Convert.ToDateTime(reader.ReadLine());
                Record tempRecord = new Record(tempName, tempScore, tempRecordDay);
                records.Add(tempRecord);
            }
            records.Sort();
            records.Reverse();
            reader.Close();
            fileData.Close();
        }
        public int IsExistNameAccount()
        {
            if (records.Count == 0)
                return -1; //no data
            for (int i = 0; i < records.Count; i++)
                if (this.accountName == records[i].accountName)
                    return i;
            return -2;//can not file the name
        }
        public void FixTheRecord(int newScore)
        {
            int position = IsExistNameAccount();
            if (position >= 0 && this.records[position].score < newScore)
            {
                this.records[position].score = newScore;
            }
            records.Sort();
            records.Reverse();
        }
        public void AddRecord()
        {
            records.Add(new Record(this.accountName, this.score, this.recordDay));
            records.Sort();
            records.Reverse();
        }
        public void Store()
        {
            FileStream storedFile = new FileStream(this.storedFileName, FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite);
            StreamWriter writer = new StreamWriter(storedFile);
            if (IsExistNameAccount() >= 0)
            {
                FixTheRecord(this.score);
                foreach (var record in records)
                {
                    writer.WriteLine(record.accountName);
                    writer.WriteLine(record.score);
                    writer.WriteLine(record.recordDay);
                    writer.Flush();
                }
            }
            else
            {
                AddRecord();
                foreach (var record in records)
                {
                    writer.WriteLine(record.accountName);
                    writer.WriteLine(record.score);
                    writer.WriteLine(record.recordDay);
                    writer.Flush();
                }
            }
            writer.Close();
            storedFile.Close();
        }
        public Record[] GetHighestScores(int amount)
        {
            this.Read();
            Record[] result = new Record[amount];
            int i = 0;
            if (records.Count < 3)
            {
                foreach (var record in records)
                    result[i++] = record;
                while (i < amount)
                    result[i++] = new Record("Player", 0, DateTime.Now);
            }
            else
                while (i < amount)
                {
                    result[i] = records[i];
                    i++;
                }
            return result;
        }
        public Rectangle Show(Rectangle frameContain, int width, int height)
        {
            Rectangle frame = new Rectangle(width, height);
            frame.Init(new Coord(frameContain.Center().x - frame.WidthConsole / 2, frameContain.Center().y - frame.HeightConsole / 4));
            frame.DrawInvisibalTitled("Warning!!! Pro Player is coming", ConsoleColor.DarkYellow);
            this.Read();
            string firstRecord = GetHighestScores(3)[0].accountName + ": " + GetHighestScores(3)[0].score;
            Cursor.WriteAt(firstRecord, new Coord(frame.Center().x - firstRecord.Length / 2, frame.Center().y + frame.HeightConsole / 6 - GameSpecs.Line_Spacing), ConsoleColor.Blue);
            string secondRecord = GetHighestScores(3)[1].accountName + ": " + GetHighestScores(3)[1].score;
            Cursor.WriteAt(secondRecord, new Coord(frame.Center().x - secondRecord.Length / 2, frame.Center().y + frame.HeightConsole / 6), ConsoleColor.Blue);
            string thirdRecord = GetHighestScores(3)[2].accountName + ": " + GetHighestScores(3)[2].score;
            Cursor.WriteAt(thirdRecord, new Coord(frame.Center().x - thirdRecord.Length / 2, frame.Center().y + frame.HeightConsole / 6 + GameSpecs.Line_Spacing), ConsoleColor.Blue);
            return frame;
        }
        #endregion

        #region OverrideComparisionMethod
        public int CompareTo(Record record)
        {
            var index = score.CompareTo(record.score);
            if (index == 0)
                index = recordDay.CompareTo(record.recordDay);
            return index;
        }
        #endregion
    }
}
