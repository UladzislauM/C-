using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateBook
{/// <summary>
/// Структура для массива
/// </summary>
    struct SkechNoteArr
    {
        /// <summary>
        /// Массив заметки
        /// </summary>
        public string[] NoteArr { get; set; }
        
   /// <summary>
   /// Определение строк Массива с заметкой
   /// </summary>
   /// <param name="NoteArr"></param>
        public SkechNoteArr (string[] NoteArr)
        {
            this.NoteArr = NoteArr;
        }

        /// <summary>
        /// Изменяет размер массива NoteArr
        /// </summary>
        public void NoteArrResize()
        {
            string[] noteArr = this.NoteArr;
            Array.Resize(ref noteArr, +1);

        }
    }

    /// <summary>
    /// переменные для Записной книжки
    /// </summary>
    public struct SkechNote

    {
        /// <summary>
        /// Поле для ввода данных
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Имя заметки
        /// </summary>
        public string NameNote { get; set; }

        /// <summary>
        /// Дата
        /// </summary>
        public string DateNote { get; set; }




        /// <summary>
        /// Определение строк Заметки
        /// </summary>
        /// <param name="NameNote">Имя Заметки</param>
        /// <param name="Note">Дата Заметки</param>
        /// <param name="DateNote">Заметка</param>
        public SkechNote(string NameNote, string DateNote, string Note)
        {
            this.NameNote = NameNote;
            this.DateNote = DateNote;
            this.Note = Note;
        }

      

        /// <summary>
        /// Вывод нв экран
        /// </summary>
        /// <returns></returns>
        public string PrintNote()
        {
            return $"{NameNote}; {DateNote}; {Note}";
        }

       
    }

}
