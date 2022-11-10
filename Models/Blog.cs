using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFBlogPost.Models
{
    public class Blog
    {
        public int BlogId { get; set; }

        public string Name { get; set; }

        // entity framework navigation property
        public virtual List<Post> Posts { get; set; }

    }
}
