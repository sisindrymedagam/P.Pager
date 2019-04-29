using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace P.Pager.Tests
{
    public class PagerAsyncTests
    {
        [Fact]
        public async Task StartPageTestAsync()
        {
            var list = Enumerable.Range(1, 200).ToList();
            var expectedList = Enumerable.Range(1, 20).ToList(); // get list from 1 to 20
            var firstPage = await list.ToPagerListAsync(1, 20); // first page from 1 to 20, page size = 20
            Assert.Equal(expectedList, firstPage);//Test Passed
        }

        [Fact]
        public async Task MiddlePageTestAsync()
        {
            var list = Enumerable.Range(1, 200).ToList();
            var expectedList = Enumerable.Range(21, 20).ToList(); // get list from 21 to 40
            var secondPage = await list.ToPagerListAsync(2, 20); // second page from 21 to 40, page size = 20
            Assert.Equal(expectedList, secondPage);//Test Passed
        }

        [Fact]
        public async Task LastPageTest()
        {
            var list = Enumerable.Range(1, 200).ToList();
            var expectedList = Enumerable.Range(21, 20).ToList(); // get list from 21 to 40
            var lastPage = await list.ToPagerListAsync(10, 20); // second page is last page
            Assert.NotSame(expectedList, lastPage);//Test Passed
        }

        [Fact]
        public async Task InvalidPageTest()
        {
            var list = Enumerable.Range(1, 200).ToList();
            var expectedList = Enumerable.Range(181, 200).ToList(); // get list from 21 to 40
            var validPage = await list.ToPagerListAsync(12, 20); // Here totalPageCount is 10 but takes Index as 12
            Assert.NotSame(expectedList, validPage);//Test Passed
        }


        [Fact]
        public async Task NextPageCheck()
        {
            var list = Enumerable.Range(1, 200).ToList();
            var expectedList = Enumerable.Range(21, 20).ToList(); // get list from 21 to 40
            var page = await list.ToPagerListAsync(1, 20); // second page from 21 to 40, page size = 20
            Assert.True(page.HasNextPage);//Test Passed
        }
    }
}
