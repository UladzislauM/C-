using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateBook
{
    struct Methods
    {
        /// <summary>
        /// Добавляет Массив с Заметкой в файл.
        /// </summary>
        /// <param name="Puth">Путь к файлу</param>
        /// <param name="Lines">Массив</param>
        public void AddToFile (string Puth, string[] Lines)
        {
            File.Delete(Puth);
            using (StreamWriter stream = new StreamWriter(Puth+".csv", true, Encoding.UTF8))
            {
                string[] LineWr ;
                for (int i = 0; i < Lines.Length; i++)
                {
                    if (Lines[i] != null && Lines[i] != "")
                    {
                        LineWr = Lines[i].Split(';');
                        stream.WriteLine($"{LineWr[0]};{LineWr[1]};{LineWr[2]};");
                    }

                }
            }
        }
     
        /// <summary>
        /// Считывает данные из файла и преобразует в строки Одномерного Массива
        /// </summary>
        /// <param name="Puth">Путь к файлу</param>
        /// <returns></returns>
        public string[] WriteFile(string Puth)
        {

            string[] Lines = File.ReadAllLines(Puth, Encoding.UTF8);
            return Lines;
        }

       /// <summary>
       /// Сортировка Заметки по выбранному полю
       /// </summary>
       /// <param name="numField">Номер поля для сортировки</param>
       /// <param name="lines">Массив с замкеткой</param>
       /// <param name="Puth">Путь к файлу с заметкой</param>
        public string[] SortNoteByField (string[] LiNes, int numField, string Puth)
        {
            List<SkechNote> listNote = new List<SkechNote>();
            string[] lineWr;
            for (int i = 0; i < LiNes.Length; i++)
            {
                if (LiNes[i] != null || LiNes[i] != "")
                {
                    lineWr = LiNes[i].Split(';');
                    listNote.Add(new SkechNote($"{lineWr[0]}", $"{lineWr[1]}", $"{lineWr[2]}"));
                }
            }
            int NumOfLenth = 0;
            if (numField == 0)
            {
                var sortedNotes = from u in listNote
                                  orderby u.NameNote
                                  select u;
                    foreach (SkechNote u in sortedNotes)
                    {
                    
                    LiNes[NumOfLenth] = u.PrintNote();
                    NumOfLenth++;
                    
                    }
                
            }
            if (numField == 1)
            {
                var sortedNotes = from u in listNote
                                  orderby u.DateNote
                                  select u;
                    foreach (SkechNote u in sortedNotes)
                    {
                    LiNes[NumOfLenth] = u.PrintNote();
                    NumOfLenth++;
                    
                }
                
            }
            if (numField == 2)
            {
                var sortedNotes = from u in listNote
                                  orderby u.Note
                                  select u;
                    foreach (SkechNote u in sortedNotes)
                    {
                    LiNes[NumOfLenth] = u.PrintNote();
                    NumOfLenth++;
                    
                }
                
            }
            return LiNes;
            //var sortedNotes = listNote.OrderBy(u => u.NameNote);



        }

    }
}
