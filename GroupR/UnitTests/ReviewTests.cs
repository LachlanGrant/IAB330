using NUnit.Framework;
using System;
using GroupR.Models;
using GroupR.Services;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace UnitTests
{
    [TestFixture()]
    public class ReviewTests
    {
        [Test()]
        public void TestReviewConstructor()
        {
            ReviewUser user = new ReviewUser();
            user.username = "lachlangrant";

            Review Item = new Review
            {
                friendliness = 2,
                workEthic = 3,
                workQuality = 4,
                name = "Example Student",
                studentNumber = "n123456789",
                subject = "IAB330",
                user = user
            };

            Assert.AreEqual(2, Item.friendliness, 2);
            Assert.AreEqual(3, Item.workEthic, 3);
            Assert.AreEqual(4, Item.workQuality, 4);
            Assert.AreEqual("Example Student", Item.name);
            Assert.AreEqual("n123456789", Item.studentNumber);
            Assert.AreEqual("IAB330", Item.subject);
            Assert.AreEqual("lachlangrant", Item.user.username);
        }

        [Test()]
        public void TestReviewToJSON()
        {
            Review Item = new Review
            {
                friendliness = 2,
                workEthic = 3,
                workQuality = 4,
                name = "Example Student",
                studentNumber = "n123456789",
                subject = "IAB330"
            };
            Assert.AreEqual(ReviewDataStore.ReviewToJSON(Item, "lachlangrant"), "{\"name\":\"Example Student\",\"workEthic\":3,\"workQuality\":4,\"friendliness\":2,\"studentNumber\":\"n123456789\",\"subject\":\"IAB330\",\"username\":\"lachlangrant\"}");
        }

        [Test()]
        public void TestJSONtoReviews()
        {
            String sampleJSON = "{\"success\":true,\"reviews\":[{\"_id\":\"5d85e949c09f990031643cea\",\"name\":\"Person\",\"friendliness\":1,\"workEthic\":3,\"workQuality\":1,\"studentNumber\":\"1234\",\"subject\":\"IAB330\",\"__v\":0},{\"_id\":\"5d85ebfcc09f990031643ceb\",\"name\":\"DifferentPerson\",\"friendliness\":1,\"workEthic\":2,\"workQuality\":1,\"studentNumber\":\"10233\",\"subject\":\"CAB303\",\"__v\":0},{\"_id\":\"5d883955c09f990031643cec\",\"name\":\"JohnDoe\",\"friendliness\":1,\"workEthic\":4,\"workQuality\":1,\"studentNumber\":\"n10120884\",\"subject\":\"IAB305\",\"__v\":0},{\"_id\":\"5d88406fc09f990031643ced\",\"name\":\"Reviewwith234\",\"friendliness\":2,\"workEthic\":3,\"workQuality\":4,\"studentNumber\":\"234\",\"subject\":\"234\",\"__v\":0},{\"_id\":\"5d8843bcc09f990031643cee\",\"name\":\"Review545\",\"friendliness\":5,\"workEthic\":4,\"workQuality\":5,\"studentNumber\":\"n9961239\",\"subject\":\"IFB101\",\"__v\":0},{\"_id\":\"5d8b702dc09f990031643cef\",\"name\":\"senna\",\"friendliness\":5,\"workEthic\":5,\"workQuality\":5,\"studentNumber\":\"4444444\",\"subject\":\"f101\",\"__v\":0},{\"_id\":\"5d8f08a4ed140d0020c79cfa\",\"name\":\"1\",\"friendliness\":5,\"workEthic\":2,\"workQuality\":3,\"studentNumber\":\"1\",\"subject\":\"1\",\"__v\":0},{\"_id\":\"5d8f18aaed140d0020c79cfc\",\"name\":\"JaneDoe\",\"friendliness\":4,\"workEthic\":4,\"workQuality\":4,\"studentNumber\":\"n10425336\",\"subject\":\"IFB101\",\"__v\":0},{\"_id\":\"5d8f18aaed140d0020c79cfd\",\"name\":\"JaneDoe\",\"friendliness\":4,\"workEthic\":4,\"workQuality\":4,\"studentNumber\":\"n10425336\",\"subject\":\"IFB101\",\"__v\":0},{\"_id\":\"5d8f19a8ed140d0020c79cfe\",\"name\":\"doubletest\",\"friendliness\":1,\"workEthic\":1,\"workQuality\":1,\"studentNumber\":\"test\",\"subject\":\"test\",\"__v\":0},{\"_id\":\"5d8f19a8ed140d0020c79cff\",\"name\":\"doubletest\",\"friendliness\":1,\"workEthic\":1,\"workQuality\":1,\"studentNumber\":\"test\",\"subject\":\"test\",\"__v\":0},{\"_id\":\"5d8f19a8ed140d0020c79d00\",\"name\":\"doubletest\",\"friendliness\":1,\"workEthic\":1,\"workQuality\":1,\"studentNumber\":\"test\",\"subject\":\"test\",\"__v\":0},{\"_id\":\"5d907a78bb75a6001f9768fe\",\"name\":\"JohnDean\",\"friendliness\":4,\"workEthic\":5,\"workQuality\":5,\"studentNumber\":\"n9945867\",\"subject\":\"IFB103\",\"__v\":0},{\"_id\":\"5d9e86bdc46bdb003185544c\",\"name\":\"456\",\"friendliness\":4,\"workEthic\":4,\"workQuality\":4,\"studentNumber\":\"456\",\"subject\":\"456\",\"__v\":0},{\"_id\":\"5d9e86bdc46bdb003185544d\",\"name\":\"456\",\"friendliness\":4,\"workEthic\":4,\"workQuality\":4,\"studentNumber\":\"456\",\"subject\":\"456\",\"__v\":0},{\"_id\":\"5d9e86ebc46bdb003185544e\",\"name\":\"1\",\"friendliness\":4,\"workEthic\":5,\"workQuality\":3,\"studentNumber\":\"1\",\"subject\":\"1\",\"__v\":0},{\"_id\":\"5d9e86ecc46bdb003185544f\",\"name\":\"1\",\"friendliness\":4,\"workEthic\":5,\"workQuality\":3,\"studentNumber\":\"1\",\"subject\":\"1\",\"__v\":0},{\"_id\":\"5d9e890dc46bdb0031855450\",\"name\":\"q123\",\"friendliness\":3,\"workEthic\":4,\"workQuality\":3,\"studentNumber\":\"q123q\",\"subject\":\"q123\",\"__v\":0}]}";

            ReviewResponse processedResponse = ReviewDataStore.JSONtoReviews(sampleJSON);

            Assert.IsTrue(processedResponse.success);
            Assert.AreEqual("Person", processedResponse.reviews[0].name);
            Assert.AreEqual("10233", processedResponse.reviews[1].studentNumber);
            Assert.AreEqual(1, processedResponse.reviews[2].friendliness);
            Assert.AreEqual(3, processedResponse.reviews[3].workEthic);
            Assert.AreEqual(5, processedResponse.reviews[4].workQuality);
            Assert.AreEqual("f101", processedResponse.reviews[5].subject);
        }

        [Test()]
        public async Task TestAPItoReviews()
        {
            ReviewDataStore ds = new ReviewDataStore();

            IEnumerable<Review> getTask = await ds.GetItemsAsync();

            List<Review> Reviews = new List<Review>();

            foreach (var item in getTask)
            {
                Reviews.Add(item);
            }

            Assert.AreEqual("Person", Reviews[0].name);
            Assert.AreEqual("N123456789", Reviews[0].studentNumber);
        }

        [Test()]
        public async Task TestReviewSearchAsync()
        {
            ReviewDataStore ds = new ReviewDataStore();

            IEnumerable<Review> searchTask = await ds.SearchItems("Person");

            List<Review> Reviews = new List<Review>();

            foreach (var item in searchTask)
            {
                Reviews.Add(item);
            }

            Assert.AreEqual("Person", Reviews[0].name);
        }
    }
}
