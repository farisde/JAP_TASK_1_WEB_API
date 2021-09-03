using System.Collections.Generic;

namespace JAP_TASK_1_WEB_API.Models
{
    public class CastMember
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Movie> StarredMovies { get; set; }
    }
}