using System;

namespace MemeLord.Logic.Dto
{
    // stworzony dla potrzeb demonstracyjnych, może być dowolnie zmieniany, komentarz do usunięcia w przyszłości

    public class PostDto
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public DateTime CreationDate { get; set; }
        public int Rating { get; set; }
        public DateTime? DeletionDate { get; set; }
    }
}