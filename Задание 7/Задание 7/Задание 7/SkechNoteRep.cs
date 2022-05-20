using System;
using System.Collections.Generic;
using System.Text;

namespace DateBook
{
    struct SkechNoteRep
    {
        /// <summary>
        /// Данные Заметки
        /// </summary>
        public SkechNote[] SkechNotes;
       

        public string[] SortNote (string [] Arr)
        {
            Array.Sort(Arr);
            return Arr;
        }

        public SkechNote this[int index]
        {
            get { return SkechNotes[index]; }
            set { SkechNotes[index] = value; }
        }

      
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="Args">Заметка</param>
        public SkechNoteRep(params SkechNote[] Args)
        {
            SkechNotes = Args;
        }
        //public string SortNote (int NumField)
        //{
        //    Array.Sort(SkechNotes[NumField]);
        //}
        


    }
    //struct SkechNoteIC : IComparable
    //{
    //    string nameNote;
    //    string dateNote;
    //    string note;
    //    public SkechNoteIC(string nameNote, string dateNote, string note)
    //    {
    //        this.nameNote = nameNote;
    //        this.dateNote = dateNote;
    //        this.note = note;
    //    }

        //public override string ToString()
        //{
        //    return string.Format(nameNote);
        //}

        //public int CompareTo(object wkr)
        //{
        //    return string.Compare(this.nameNote, ((SkechNoteIC)wkr).nameNote);
        //}
    
}
