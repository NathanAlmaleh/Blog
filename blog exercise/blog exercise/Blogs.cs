using System;
using System.Collections.Generic;
using System.Text;

namespace blog_exercise
{
    //Singletone class for saving the new blogs to the linked list
    public class AllBlogs
    {
        private static AllBlogs instance= null;
        private LinkedList<Blogs> my_list_Blogs;
        //constructor private
        private AllBlogs()
        {
            my_list_Blogs = new LinkedList<Blogs>();
        }
        //get the instance for the Allblogs
        public static  AllBlogs getAllblogs()
        {
            if (instance == null) instance = new AllBlogs();

            return instance;
                
        }
        //adding to the list a new blogger
        public void AddBlog(Blogs bl)
        {
            this.my_list_Blogs.AddLast(bl);
        }
        //get the list of all the blogger
        public LinkedList<Blogs> getBlogList()
        {
            return this.my_list_Blogs; 
        }

    }
    //Blogs class how is descripe 
   public class Blogs
    {
        //Owner of the blog and linked list for all his posts
        private String OWNER;
        private LinkedList<Post> my_list_posts;
        Guid id ;


        //constructor for blog with recieving the author name 
        public Blogs (String owner)
        {
            this.OWNER = owner;
            this.id = Guid.NewGuid();
            this.my_list_posts = new LinkedList<Post>();
            AllBlogs.getAllblogs().AddBlog(this);
        }
        //function to add a new post to the blog 
        public void CreateNewPost(Post newPost)
        {
            my_list_posts.AddLast(newPost);
        }
        //function for each blogger that can find all the comments made by a specific author
        public void allCommentsFromAuthor(String author)
        {
            //get the singletone linked list 
            AllBlogs  SERVERBLOG = AllBlogs.getAllblogs();
            LinkedList<Blogs> my_list_Blogs = SERVERBLOG.getBlogList();
            
            //loop for each blogger inside his post and look for comments with the same title as recieved in the function "author"
            if(my_list_Blogs != null)
            {
                foreach (Blogs blogs in my_list_Blogs)
                {
                    if (blogs.my_list_posts != null)
                    {
                        foreach (Post posts in blogs.my_list_posts)
                        {
                           if (posts.my_list_comment != null)
                           {
                             foreach (Comment comment in posts.my_list_comment)
                             {
                              if (author.Equals(comment.AUTHOR)) Console.WriteLine(comment.BODY_TEXT);
                             }
                           }
                        }
                    }
                }
            }
        }
    }

    //post class 
    public class Post
    {
        //Flag is for locking the post for no more comments
        //each post has a linked list for adding comments to it 
        bool FLAG = false;
        Guid id;
        String TITLE;
        DateTime DATE;
        public LinkedList<Comment> my_list_comment;

        //constructtor for the post 
        public Post(String Title_post)
        {
            this.id = Guid.NewGuid();
            this.TITLE = Title_post;
            this.DATE = DateTime.Today;
            this.my_list_comment = new LinkedList<Comment>();
        }
        //function that adds a comment if the post hasnt been locked 
        public void Add_new_comment(Comment newComment)
        {
            if (!FLAG)
            {
                my_list_comment.AddLast(newComment);
            }
            else
            {
                Console.WriteLine("Cannt add comments to post becaue its locked !! ");
            }
        }
        //locking the post for no more comments 
        public void lockPost()
        {
            this.FLAG = true;
        }

        
    }
    //comment class
    public class Comment
    {
        //each comment has an autor date and a sting for the comment 
        Guid id;
        public String AUTHOR;
        DateTime DATE;
        public  String BODY_TEXT;
        
        //constructor
        public Comment(string author, string body_text)
        {
            this.id = Guid.NewGuid();
            this.AUTHOR = author;
            this.BODY_TEXT = body_text;
            this.DATE = DateTime.Today;
        }
    }
}
