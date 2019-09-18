namespace orm
{
    class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return "[GenreId:" + GenreId + ", Name:" + Name + "]";
        }
    }
}