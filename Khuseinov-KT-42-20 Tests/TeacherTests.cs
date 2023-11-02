using Khuseinov_KT_42_20.Models;

namespace Khuseinov_KT_42_20_Tests
{
    public class TeacherTests
    {
        [Fact]
        public void isvalidTeacherFirstName_FirstName_true()
        {
            //arange

            var TestTeacher = new Teacher
            {
                FirstName = "Vlad"
            };

            //act
            var result = TestTeacher.IsvalidTeacherFirstName();

            //assert
            Assert.True(result);

        }
    }
}