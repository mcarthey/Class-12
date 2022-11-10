using EFBlogPost.Models;
using Microsoft.EntityFrameworkCore;

namespace EFBlogPost
{
    internal class Program
    {
        // Assignment Menu
        //1. Display Blogs
        //2. Add Blog
        //3. Display Posts
        //4. Add Post

        static void Main(string[] args)
        {
            Console.WriteLine("Make a choice");
            Console.WriteLine("1. Display Blogs");
            Console.WriteLine("2. Add Blog");
            Console.WriteLine("3. Display Posts");
            Console.WriteLine("4. Add Post");
            var userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    // 1. Read Blogs from database
                    using (var db = new BlogContext())
                    {
                        Console.WriteLine("Here is the list of blogs");

                        foreach (var b in db.Blogs)
                        {
                            Console.WriteLine($"Blog: {b.BlogId}: {b.Name}");
                        }
                    }
                    break;
                case "2":
                    // 2. Add Blog to Database
                    Console.WriteLine("Enter your Blog name");
                    var blogName = Console.ReadLine();

                    // Create new Blog
                    var blog = new Blog();
                    blog.Name = blogName;

                    // Save blog object to database
                    using (var db = new BlogContext())
                    {
                        db.Blogs.Add(blog);
                        db.SaveChanges();
                    }
                    break;
                case "3":
                    // 3. List Posts for Blog 
                    Console.WriteLine("Select the blog id");
                    var blogId = Convert.ToInt32(Console.ReadLine());

                    Blog? blog2 = null;
                    using (var db = new BlogContext())
                    {
                        // only change for Eager Loading is to add the ".Include(x=>x.Posts)" 
                        blog2 = db.Blogs.Include(x=>x.Posts).FirstOrDefault(x => x.BlogId == blogId);

                        System.Console.WriteLine($"Posts for Blog {blog2.Name}");
                    }
                    
                    foreach (var post in blog2.Posts)
                    {
                        System.Console.WriteLine($"\tPost {post.PostId} {post.Title}");
                    }
                    break;
                case "4":
                    // 4. Add Post to database
                    Console.WriteLine("Select the blog id");
                    var blogId2 = Convert.ToInt32(Console.ReadLine());

                    System.Console.WriteLine("Enter your Post title");
                    var postTitle = Console.ReadLine();

                    var post2 = new Post();
                    post2.Title = postTitle;
                    post2.Content = postTitle;
                    post2.BlogId = blogId2;

                    try
                    {
                        using (var db = new BlogContext())
                        {
                            db.Posts.Add(post2);
                            db.SaveChanges();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine(ex.InnerException);
                    }
                    break;
                default:
                    break;
            }







        }
    }
}