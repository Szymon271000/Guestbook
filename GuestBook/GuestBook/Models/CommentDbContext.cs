﻿using Microsoft.EntityFrameworkCore;

namespace GuestBook.Models
{
    public class CommentDbContext: DbContext
    {
        public CommentDbContext(DbContextOptions<CommentDbContext> options):base(options)
        {}

        public DbSet<Comment> Comments { get; set; }
    }
}
