﻿using BlogApp.Data.Concrete.EfCore;
using BlogApp.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogApp.Data.Concrete
{
    public static class SeedData
    {
        public static void Seed(IApplicationBuilder app)
        {
            BlogContext context = app.ApplicationServices.GetRequiredService<BlogContext>();

            context.Database.Migrate();

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category() { Name = "Category 1"},
                    new Category() { Name = "Category 2"},
                    new Category() { Name = "Category 3"}
                );
                context.SaveChanges();
            }


            if (!context.Blogs.Any())
            {
                context.Blogs.AddRange(
                    new Blog() { Title= "Blog Title 1", Description="Blog Description 1", Body="Blog Body 1", Image="1.jpg", Date=DateTime.Now.AddDays(-5), isApproved=true, IsHome = false, IsSlider = false, CategoryId =10},
                    new Blog() { Title = "Blog Title 2", Description = "Blog Description 2", Body = "Blog Body 2", Image = "2.jpg", Date = DateTime.Now.AddDays(-3), isApproved = true, IsHome = false, IsSlider = false, CategoryId = 12 },
                    new Blog() { Title = "Blog Title 3", Description = "Blog Description 3", Body = "Blog Body 3", Image = "3.jpg", Date = DateTime.Now.AddDays(-8), isApproved = true, IsHome = false, IsSlider = false, CategoryId = 12 },
                    new Blog() { Title = "Blog Title 4", Description = "Blog Description 4", Body = "Blog Body 4", Image = "4.jpg", Date = DateTime.Now.AddDays(-1), isApproved = true, IsHome=false, IsSlider=false, CategoryId = 11 }
                );

                context.SaveChanges();
            }

        }
    }
}
