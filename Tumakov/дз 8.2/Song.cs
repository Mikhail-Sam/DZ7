namespace Tumakov.дз_8._2
{
    public class Song
    {
        public string _name;      // Название песни
        public string _author;    // Автор песни
        public Song _prev;        // Связь с предыдущей песней в списке
        public Song()
        {
            this._name = "";
            this._author = "";
            this._prev = null;
        }
        //Метод для имени песни
        public void SetName(string name)
        {
            this._name = name;
        }

        // Метод для автора песни
        public void SetAuthor(string author)
        {
            this._author = author;
        }

        //Метод связи с предыдущей песней
        public void SetPrev(Song prev)
        {
            this._prev = prev;
        }

        //Метод вывода информации о песне
        public string Title()
        {
            return $"{this._name}, исполнитель: {this._author}";
        }

        //Метод сравнения объектов
        public override bool Equals(object obj)
        {
            if (!(obj is Song otherSong))
                return false;

            return this._name.Equals(otherSong._name) &&
                   this._author.Equals(otherSong._author);
        }

    }
}