using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using NutricareApp.Data;
using NutricareApp.Entities;
using NutricareApp.Web.Controllers;
using NutricareApp.Web.Models;

namespace NutricareApp.NUnit
{
    public class AppointmentTestNUnit
    {
        private readonly DbContextOptionsBuilder<DbContextNutricareApp> _builder = new DbContextOptionsBuilder<DbContextNutricareApp>();
        private readonly DbContextOptions<DbContextNutricareApp> _options;
        private readonly List<Appointment> _appointments;

    }
}

/*
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Practicando.Data;
using Practicando.Entities;
using Practicando.Web.Controllers;
using Practicando.Web.Models;
using Xunit;
//using System.Threading.Tasks;

namespace Practicando.Testing
{
    public class BookmarksControllerTest
    {
        private readonly DbContextOptionsBuilder<DbContextPracticando> _builder = new DbContextOptionsBuilder<DbContextPracticando>();
        private readonly DbContextOptions<DbContextPracticando> _options;
        private readonly List<Bookmark> _bookmarks;

        public BookmarksControllerTest()
        {
            _builder.UseInMemoryDatabase("Test");
            _options = _builder.Options;
            _bookmarks = new List<Bookmark>
            { 
                new Bookmark {BookmarkId = 1, Title = "Title 1", Latitude = "Latitud 1", Longitude = "Longitud 1"},
                new Bookmark {BookmarkId = 2, Title = "Title 2", Latitude = "Latitud 2", Longitude = "Longitud 2"},
                new Bookmark {BookmarkId = 3, Title = "Title 3", Latitude = "Latitud 3", Longitude = "Longitud 3"},
                new Bookmark {BookmarkId = 4, Title = "Title 4", Latitude = "Latitud 4", Longitude = "Longitud 4"}
            };
        }

        [Test]
        public async Task GetBookmarksAsyncReturnAIEnumarableOfBookmark()
        {
            using (var _context = new DbContextPracticando(_options))
            {
                _context.Bookmarks.AddRange(_bookmarks);
                _context.SaveChanges();
                var controller = new BookmarksController(_context);

                var result = await controller.GetBookmarks();

                Assert.True(typeof(IEnumerable<BookmarkModel>).IsInstanceOfType(result));
                Assert.AreEqual(4, result.Count());
            }
        }

        [Test]
        public async Task GetBookmarkByAdAsyncReturnABookmark()
        {
            using (var _context = new DbContextPracticando(_options))
            {
                CreateBookmarkModel createBookmarkModel = new CreateBookmarkModel
                {
                    Title = "test",
                    Latitude = "latitude1",
                    Longitude = "longitude"
                };
                //_context.Bookmarks.AddRange(_bookmarks);
                //_context.SaveChanges();
                var controller = new BookmarksController(_context);

                var result = await controller.GetBookmarkById(1);

                Assert.True(typeof(BookmarkModel).IsInstanceOfType(result));
            }
        }

    }
}
 
 */