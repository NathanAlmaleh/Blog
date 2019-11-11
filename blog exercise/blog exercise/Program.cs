using System;

namespace blog_exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            //creating a blog  and a post and two comments
            Blogs nathan = new Blogs ("nathan");
            Post p1 = new Post("sunday post");
            Comment c1 = new Comment("sunday","I love Sunday");
            Comment c3 = new Comment("sunday", "I bad Sunday");
            
            //add the new post to the blog 
            nathan.CreateNewPost(p1);
            p1.Add_new_comment(c1);
            //locking the post for no more comment
            p1.lockPost();
            p1.Add_new_comment(c3);
        

            //another blog with different owner name
            Blogs adam = new Blogs("adam");
            Post p2 = new Post("MY FIRST POST");
            Comment c2 = new Comment("monday", "monday is a working day ");
            //adding the post with comment
            p2.Add_new_comment(c2);
            adam.CreateNewPost(p2);
            //looking for post with the title "sunday"
            adam.allCommentsFromAuthor("monday");

            Console.ReadKey();
        }
    }
}
