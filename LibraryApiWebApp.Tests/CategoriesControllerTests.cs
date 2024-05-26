using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApiWebApp.Controllers;
using LibraryApiWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace LibraryApiWebApp.Tests.Controllers
{
    public class CategoriesControllerTests : IDisposable
    {
        private readonly LibrariAPIContext _context;
        private readonly CategoriesController _controller;
        public CategoriesControllerTests()
        {
            var options = new DbContextOptionsBuilder<LibrariAPIContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _context = new LibrariAPIContext(options);
            _controller = new CategoriesController(_context);
        }
        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Fact]
        public async Task GetCategories_Returns_All_Categories()
        {
            await _context.Categories.AddRangeAsync(
                new Category { Id = 1, name = "Action", description = "Action Movies" },
                new Category { Id = 2, name = "Comedy", description = "Comedy Movies" }
            );
            await _context.SaveChangesAsync();
            var result = await _controller.GetCategories();
            var actionResult = Assert.IsType<ActionResult<IEnumerable<Category>>>(result);
            var categories = Assert.IsAssignableFrom<IEnumerable<Category>>(actionResult.Value);
            Assert.Equal(2, categories.Count());
        }

        [Fact]
        public async Task GetCategory_Returns_Specific_Category()
        {
            var category = new Category { Id = 1, name = "Action", description = "Action Movies" };
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            var result = await _controller.GetCategory(1);
            var actionResult = Assert.IsType<ActionResult<Category>>(result);
            var returnedCategory = Assert.IsType<Category>(actionResult.Value);
            Assert.Equal(category.Id, returnedCategory.Id);
            Assert.Equal(category.name, returnedCategory.name);
        }

        [Fact]
        public async Task PostCategory_Adds_New_Category()
        {
            var categoryToAdd = new Category { name = "Drama", description = "Drama Movies" };
            var result = await _controller.PostCategory(categoryToAdd);
            var actionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var createdCategory = Assert.IsType<Category>(actionResult.Value);
            Assert.Equal(categoryToAdd.name, createdCategory.name);
            var addedCategory = await _context.Categories.FindAsync(createdCategory.Id);
            Assert.NotNull(addedCategory);
        }

        [Fact]
        public async Task PutCategory_Updates_Category()
        {
            var category = new Category { Id = 1, name = "Action", description = "Action Movies" };
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            category.description = "Updated Action Movies";
            var result = await _controller.PutCategory(1, category);
            Assert.IsType<NoContentResult>(result);
            var updatedCategory = await _context.Categories.FindAsync(category.Id);
            Assert.Equal(category.description, updatedCategory.description);
        }

        [Fact]
        public async Task DeleteCategory_Removes_Category()
        {
            var category = new Category { Id = 1, name = "Action", description = "Action Movies" };
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            var result = await _controller.DeleteCategory(1);
            Assert.IsType<NoContentResult>(result);
            var deletedCategory = await _context.Categories.FindAsync(1);
            Assert.Null(deletedCategory);
        }
    }
}