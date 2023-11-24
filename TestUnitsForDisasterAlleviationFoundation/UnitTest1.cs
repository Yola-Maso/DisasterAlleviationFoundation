using System.Threading.Tasks;
using DisasterAlleviationFoundation.Data;
using DisasterAlleviationFoundation.Models;
using DisasterAlleviationFoundation.Pages.Allocation;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Assert = Xunit.Assert;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace TestUnitsForDisasterAlleviationFoundation
{
    public class UnitTest1
    {
        private UserContext GetInMemoryDatabaseContext()
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<UserContext>(options => options.UseInMemoryDatabase("TestDatabase"))
                .BuildServiceProvider();

            return serviceProvider.GetRequiredService<UserContext>();
        }

        [Fact]
        public async Task MoneyAllocationModel_OnPostAsync_ValidData_RedirectsToIndex()
        {
            // Arrange
            var context = GetInMemoryDatabaseContext();

            var disaster = new Disaster { DisasterID = 1 };
            var monetaryDonation = new MonetaryDonations { MonetaryID = 1, Amount = 100 };
            context.Disaster.Add(disaster);
            context.MonetaryDonations.Add(monetaryDonation);
            context.SaveChanges();

            var moneyAllocationModel = new MoneyAllocationModel(context)
            {
                MoneyAllocation = new MoneyAllocation { DisasterID = 1, MonetaryID = 1 }
            };

            // Manually set up PageContext and HttpContext
            var pageContext = new PageContext
            {
                HttpContext = new DefaultHttpContext(),
                ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
            };

            moneyAllocationModel.PageContext = pageContext;

            // Act
            var result = await moneyAllocationModel.OnPostAsync();

            // Assert
            Assert.IsType<RedirectToPageResult>(result);
            var redirectResult = Assert.IsType<RedirectToPageResult>(result);
            Assert.Equal("./Index", redirectResult.PageName);
        }

        // Similar modifications for other test methods...

        [Fact]
        public async Task MoneyAllocationModel_OnPostAsync_InvalidDisasterID_ReturnsPageResult()
        {
            // Arrange
            var context = GetInMemoryDatabaseContext();

            var monetaryDonation = new MonetaryDonations { MonetaryID = 1, Amount = 100 };
            context.MonetaryDonations.Add(monetaryDonation);
            context.SaveChanges();

            var moneyAllocationModel = new MoneyAllocationModel(context)
            {
                MoneyAllocation = new MoneyAllocation { DisasterID = 1, MonetaryID = 1 }
            };

            // Act
            var result = await moneyAllocationModel.OnPostAsync();

            // Assert
            Assert.IsType<PageResult>(result);
            var pageResult = Assert.IsType<PageResult>(result);
            Assert.Equal(1, pageResult.ViewData.ModelState.ErrorCount);
            Assert.Equal("Invalid DisasterID", pageResult.ViewData.ModelState["MoneyAllocation.DisasterID"].Errors[0].ErrorMessage);
        }

        [Fact]
        public async Task MoneyAllocationModel_OnPostAsync_InvalidMonetaryID_ReturnsPageResult()
        {
            // Arrange
            var context = GetInMemoryDatabaseContext();

            var disaster = new Disaster { DisasterID = 1 };
            context.Disaster.Add(disaster);
            context.SaveChanges();

            var moneyAllocationModel = new MoneyAllocationModel(context)
            {
                MoneyAllocation = new MoneyAllocation { DisasterID = 1, MonetaryID = 1 }
            };

            // Act
            var result = await moneyAllocationModel.OnPostAsync();

            // Assert
            Assert.IsType<PageResult>(result);
            var pageResult = Assert.IsType<PageResult>(result);
            Assert.Equal(1, pageResult.ViewData.ModelState.ErrorCount);
            Assert.Equal("Invalid MonetaryID", pageResult.ViewData.ModelState["MoneyAllocation.MonetaryID"].Errors[0].ErrorMessage);
        }
        [Fact]
        public async Task GoodsAllocationModel_OnPostAsync_ValidData_RedirectsToIndex()
        {
            // Arrange
            var context = GetInMemoryDatabaseContext();

            var disaster = new Disaster { DisasterID = 1 };
            var goodsDonation = new GoodsDonations { GoodID = 1, NumOfItems = 10 };
            context.Disaster.Add(disaster);
            context.GoodsDonations.Add(goodsDonation);
            context.SaveChanges();

            var goodsAllocationModel = new GoodsAllocationModel(context)
            {
                GoodsAllocation = new GoodsAllocation { DisasterID = 1, GoodID = 1 }
            };

            // Manually set up PageContext and HttpContext
            var pageContext = new PageContext
            {
                HttpContext = new DefaultHttpContext(),
                ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
            };

            goodsAllocationModel.PageContext = pageContext;

            // Act
            var result = await goodsAllocationModel.OnPostAsync();

            // Assert
            Assert.IsType<RedirectToPageResult>(result);
            var redirectResult = Assert.IsType<RedirectToPageResult>(result);
            Assert.Equal("./Index", redirectResult.PageName);
        }

        [Fact]
        public async Task GoodsAllocationModel_OnPostAsync_InvalidDisasterID_ReturnsPageResult()
        {
            // Arrange
            var context = GetInMemoryDatabaseContext();

            var goodsDonation = new GoodsDonations { GoodID = 1, NumOfItems = 10 };
            context.GoodsDonations.Add(goodsDonation);
            context.SaveChanges();

            var goodsAllocationModel = new GoodsAllocationModel(context)
            {
                GoodsAllocation = new GoodsAllocation { DisasterID = 1, GoodID = 1 }
            };

            // Act
            var result = await goodsAllocationModel.OnPostAsync();

            // Assert
            Assert.IsType<PageResult>(result);
            var pageResult = Assert.IsType<PageResult>(result);
            Assert.Equal(1, pageResult.ViewData.ModelState.ErrorCount);
            Assert.Equal("Disaster with the specified ID does not exist.", pageResult.ViewData.ModelState[string.Empty].Errors[0].ErrorMessage);
        }

        [Fact]
        public async Task GoodsAllocationModel_OnPostAsync_InvalidGoodID_ReturnsPageResult()
        {
            // Arrange
            var context = GetInMemoryDatabaseContext();

            var disaster = new Disaster { DisasterID = 1 };
            context.Disaster.Add(disaster);
            context.SaveChanges();

            var goodsAllocationModel = new GoodsAllocationModel(context)
            {
                GoodsAllocation = new GoodsAllocation { DisasterID = 1, GoodID = 1 }
            };

            // Act
            var result = await goodsAllocationModel.OnPostAsync();

            // Assert
            Assert.IsType<PageResult>(result);
            var pageResult = Assert.IsType<PageResult>(result);
            Assert.Equal(1, pageResult.ViewData.ModelState.ErrorCount);
            Assert.Equal("Goods donation with the specified ID does not exist.", pageResult.ViewData.ModelState[string.Empty].Errors[0].ErrorMessage);
        }

    }
}
