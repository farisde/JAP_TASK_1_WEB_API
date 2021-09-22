using System.Collections.Generic;

namespace MovieBuff.Models
{
    public class CastMember
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Media> StarredMedia { get; set; }
    }
}