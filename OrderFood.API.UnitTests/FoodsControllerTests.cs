using NSubstitute;
using NUnit.Framework;
using OrderFood.BL;
using OrderFood.DL;
using OrderFood.Common.DTOs;
using OrderFood.Common.Models;

namespace OrderFood.API.UnitTests
{
    [TestFixture]
    public class FoodsControllerTests
    {
        /// <summary>
        ///      test case lấy food, case thành công
        /// </summary>
        [Test]
        [Category("Short")]
        public void GetFoodById_ExistsFood_ReturnsSuccess()
        {
            // Arrange: Fake data đầu vào
            var foodId = new Guid("4989ff24-23e7-7b82-b6d2-89b22d10517e");
            var food = new Food
            {
                FoodId = foodId,
                FoodName = "shrimp tacos",
                FoodStar = 4,
                FoodDesc = "03 pieces per serving",
                FoodStatus = "best seller",
                FoodType = "meat"
            };

            // kết quả mong đợi
            var expectedResult = new ServiceResponse<Food>();
            expectedResult.Success = true;
            expectedResult.Data = food;

            // break dependency và fake data 
            var fakeFoodDL = Substitute.For<IBaseDL<Food>>();
            fakeFoodDL.GetById(foodId).Returns(food);

            // Act
            var foodBL = new BaseBL<Food>(fakeFoodDL);
            var actualResult = foodBL.GetById(foodId);

            // Assert
            Assert.AreEqual(expectedResult.Success, actualResult.Result.Success);
            Assert.AreEqual(expectedResult.Data, actualResult.Result.Data);
        }

        /// <summary>
        ///     test case  lấy food, case thất bại
        /// </summary>
        [Test]
        public void GetFoodById_ExistsFood_ReturnsNotFound()
        {
            // Arrange: Fake data đầu vào
            var foodId = new Guid("4989ff24-23e7-7b82-b6d2-89b22d10517e");

            var expectedResult = new ServiceResponse<Food>();
            expectedResult.Success = false;
            expectedResult.Data = null;

            var fakeFoodDL = Substitute.For<IBaseDL<Food>>();

            fakeFoodDL.GetById(foodId).Returns((Food)null);

            // Act
            var foodBL = new BaseBL<Food>(fakeFoodDL);
            var actualResult = foodBL.GetById(foodId);

            //Assert
            Assert.AreEqual(expectedResult.Success, actualResult.Result.Success);
            Assert.AreEqual((Food)null, actualResult.Result.Data);
        }


        /// <summary>
        ///      test case khi thêm food thành công
        /// </summary>
        [Test]
        public void InsertFood_NotExistsFood_ReturnsSuccess()
        {
            var food = new Food
            {
                FoodId = new Guid("4989ff24-23e7-7b82-b6d2-89b22d10517e"),
                FoodName = "shrimp tacos",
                FoodStar = 4,
                FoodDesc = "03 pieces per serving",
                FoodStatus = "best seller",
                FoodType = "meat"
            };

            var expectedResult = new ServiceResponse<Food>();
            expectedResult.Success = true;
            expectedResult.Data = 1;

            var fakeFoodDL = Substitute.For<IBaseDL<Food>>();
            fakeFoodDL.Add(food).Returns(1);

            // Act
            var foodBL = new BaseBL<Food>(fakeFoodDL);
            var actualResult = foodBL.Add(food);

            // Assert
            Assert.AreEqual(expectedResult.Success, actualResult.Success);
            Assert.AreEqual(expectedResult.Data, actualResult.Data);
        }


        /// <summary>
        ///      test case khi thêm food thất bại
        /// </summary>
        [Test]
        public void InsertFood_FoodNameEmpty_ReturnsFailure()
        {
            var food = new Food
            {
                FoodId = new Guid("4989ff24-23e7-7b82-b6d2-89b22d10517e"),
                FoodName = null,
                FoodStar = 4,
                FoodDesc = "03 pieces per serving",
                FoodStatus = "best seller",
                FoodType = "meat"
            };

            var expectedResult = new ServiceResponse<Food>();
            expectedResult.Success = false;
            expectedResult.Data = 0;

            var fakeFoodDL = Substitute.For<IBaseDL<Food>>();
            fakeFoodDL.Add(food).Returns(0);

            // Act
            var foodBL = new BaseBL<Food>(fakeFoodDL);
            var actualResult = foodBL.Add(food);

            // Assert
            Assert.AreEqual(expectedResult.Success, actualResult.Success);
            Assert.AreEqual(expectedResult.Data, actualResult.Data);
        }

        /// <summary>
        ///     Test case lấy danh sách food
        /// </summary>
        [Test]
        [Category("Short")]
        public void GetFoodAll_ExistsFood_ReturnsSuccess()
        {
            // Arrange: Fake data đầu vào
            var food = new List<Food>
            {
                 new Food
            {
                FoodId = new Guid("4989ff24-23e7-7b82-b6d2-89b22d10517e"),
                FoodName = "shrimp tacos",
                FoodStar = 4,
                FoodDesc = "03 pieces per serving",
                FoodStatus = "best seller",
                FoodType = "meat"
            },
                  new Food
            {
                FoodId = new Guid("4989ff24-23e7-7b82-b6d2-39b22d10517e"),
                FoodName = "shrimp tacos",
                FoodStar = 4,
                FoodDesc = "03 pieces per serving",
                FoodStatus = "best seller",
                FoodType = "meat"
            }
        };

            // kết quả mong đợi
            var expectedResult = new ServiceResponse<Food>();
            expectedResult.Success = true;
            expectedResult.Data = food;

            // break dependency và fake data 
            var fakeFoodDL = Substitute.For<IBaseDL<Food>>();
            fakeFoodDL.GetAllRecord().Returns(food);

            // Act
            var foodBL = new BaseBL<Food>(fakeFoodDL);
            var actualResult = foodBL.GetAllRecord();

            // Assert
            Assert.AreEqual(expectedResult.Success, actualResult.Result.Success);
            Assert.AreEqual(expectedResult.Data, actualResult.Result.Data);
        }


        /// <summary>
        ///     Test case lấy danh sách thất bại
        /// </summary>
        [Test]
        [Category("Short")]
        public void GetFoodAll_ExistFood_ReturnsFailure()
        {
            // Arrange: Fake data đầu vào

            // kết quả mong đợi
            var expectedResult = new ServiceResponse<Food>();
            expectedResult.Success = false;
            expectedResult.Data = null;

            // break dependency và fake data 
            var fakeFoodDL = Substitute.For<IBaseDL<Food>>();
            fakeFoodDL.GetAllRecord().Returns((new List<Food>() { null }));

            // Act
            var foodBL = new BaseBL<Food>(fakeFoodDL);
            var actualResult = foodBL.GetAllRecord();

            // Assert
            Assert.AreEqual(expectedResult.Success, actualResult.Result.Success);
            Assert.AreEqual(expectedResult.Data, actualResult.Result.Data);
        }


        /// <summary>
        ///     Update food thành công
        /// </summary>
        [Test]
        public void UpdateFood_NotExistsFood_ReturnsSuccess()
        {
            var food = new Food
            {
                FoodId = new Guid("4989ff24-23e7-7b82-b6d2-89b22d10517e"),
                FoodName = "shrimp tacos",
                FoodStar = 4,
                FoodDesc = "03 pieces per serving",
                FoodStatus = "best seller",
                FoodType = "meat"
            };

            var expectedResult = new ServiceResponse<Food>();
            expectedResult.Success = true;
            expectedResult.Data = 1;

            var fakeFoodDL = Substitute.For<IBaseDL<Food>>();
            fakeFoodDL.Update(food).Returns(1);

            // Act
            var foodBL = new BaseBL<Food>(fakeFoodDL);
            var actualResult = foodBL.Update(food);

            // Assert
            Assert.AreEqual(expectedResult.Success, actualResult.Success);
            Assert.AreEqual(expectedResult.Data, actualResult.Data);
        }


        /// <summary>
        ///     test case update thất bại
        /// </summary>
        [Test]
        public void UpdateFood_FoodNameEmpty_ReturnsFailure()
        {
            var food = new Food
            {
                FoodId = new Guid("4989ff24-23e7-7b82-b6d2-89b22d10517e"),
                FoodName = null,
                FoodStar = 4,
                FoodDesc = "03 pieces per serving",
                FoodStatus = "best seller",
                FoodType = "meat"
            };

            var expectedResult = new ServiceResponse<Food>();
            expectedResult.Success = false;
            expectedResult.Data = 0;

            var fakeFoodDL = Substitute.For<IBaseDL<Food>>();
            fakeFoodDL.Update(food).Returns(0);

            // Act
            var foodBL = new BaseBL<Food>(fakeFoodDL);
            var actualResult = foodBL.Update(food);

            // Assert
            Assert.AreEqual(expectedResult.Success, actualResult.Success);
            Assert.AreEqual(expectedResult.Data, actualResult.Data);
        }


        /// <summary>
        ///     Test case delete food thành công
        /// </summary>
        [Test]
        [Category("Short")]
        public void DeleteFoodById_ExistsFood_ReturnsSuccess()
        {
            // Arrange: Fake data đầu vào
            var foodId = new Guid("4989ff24-23e7-7b82-b6d2-89b22d10517e");


            // kết quả mong đợi
            var expectedResult = new ServiceResponse<Food>();
            expectedResult.Success = true;
            expectedResult.Data = true;

            // break dependency và fake data 
            var fakeFoodDL = Substitute.For<IBaseDL<Food>>();
            fakeFoodDL.Delete(foodId).Returns(true);

            // Act
            var foodBL = new BaseBL<Food>(fakeFoodDL);
            var actualResult = foodBL.Delete(foodId);

            // Assert
            Assert.AreEqual(expectedResult.Success, actualResult.Result.Success);
            Assert.AreEqual(expectedResult.Data, actualResult.Result.Data);
        }


        /// <summary>
        ///     Test case delete food thất bại
        /// </summary>
        [Test]
        [Category("Short")]
        public void DeleteFoodById_ExistsFood_ReturnsFailure()
        {
            // Arrange: Fake data đầu vào
            var foodId = new Guid("4989ff24-23e7-7b82-b6d2-89b22d10517e");


            // kết quả mong đợi
            var expectedResult = new ServiceResponse<Food>();
            expectedResult.Success = false;
            expectedResult.Data = false;

            // break dependency và fake data 
            var fakeFoodDL = Substitute.For<IBaseDL<Food>>();
            fakeFoodDL.Delete(foodId).Returns(false);

            // Act
            var foodBL = new BaseBL<Food>(fakeFoodDL);
            var actualResult = foodBL.Delete(foodId);

            // Assert
            Assert.AreEqual(expectedResult.Success, actualResult.Result.Success);
            Assert.AreEqual(expectedResult.Data, actualResult.Result.Data);
        }
    }
}
