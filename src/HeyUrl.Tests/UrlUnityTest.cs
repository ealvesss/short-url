using HeyUrl.Domain;
using HeyUrl.Domain.Entities;
using HeyUrl.Domain.Helper.Interface;
using HeyUrl_Challenge.Domain.Services.Interfaces;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using System;
using FluentAssertions;
using System.Threading.Tasks;

namespace tests
{
    public class UrlUnityTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task should_get_all_data()
        {
            var repository = new Mock<IUrlRepository>();
            repository.Setup(x => x.GetAll())
                      .ReturnsAsync(new List<UrlEntity>(){
                          new UrlEntity(){
                              Id = 1,
                              Clicks = 0,
                              CreatedAt = DateTime.Now,
                              OriginalUrl = "http://www.google.com",
                              ShortUrl = "ABCDE"  
                          }
                      });

            UrlService service = new UrlService(repository.Object, Mock.Of<IUrlShortHelper>());

            var result = await service.GetAll();

            result.Should().NotBeNull();
            result.Should().HaveCount(1);
        }

        [Test]
        public async Task should_create_short_url()
        {   
            var entity = new UrlEntity() { 
                Clicks = 1,
                CreatedAt = DateTime.Now,
                Id = 1,
                OriginalUrl = "http://google.com",
                ShortUrl = "ABCDE"
            };

            var repository = new Mock<IUrlRepository>();
            repository.Setup(x => x.PersistShortUrl(entity))
                      .ReturnsAsync(true);

            UrlService service = new UrlService(repository.Object, Mock.Of<IUrlShortHelper>());

            var result = await service.Create(entity);
        }
    }
}