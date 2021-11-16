using FluentAssertions;
using HeyUrl.Domain;
using HeyUrl.Domain.Entities;
using HeyUrl.Helper;
using HeyUrl_Challenge.Domain.Services.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
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
                      .ReturnsAsync(new List<Url>(){
                          new Url(){
                              Click = new Click(){
                                  ClickedAt = DateTime.Now,
                              },
                              CreatedAt = DateTime.Now,
                              OriginalUrl = "http://www.google.com",
                              ShortUrl = new UrlShortHelper().ShortUrl((Int64) new Random(100).NextDouble())
                          }
                      });

            UrlService service = new UrlService(repository.Object,Mock.Of<IDbHelper>(), Mock.Of<IUrlShortHelper>());

            var result = await service.GetAll();

            result.Should().NotBeNull();
            result.Should().HaveCount(1);
        }

        [Test]
        public async Task should_create_short_url()
        {
            var entity = new Url()
            {
                Click = new Click()
                {
                    ClickedAt = DateTime.Now,
                },
                CreatedAt = DateTime.Now,
                OriginalUrl = "http://google.com",
                ShortUrl = new UrlShortHelper().ShortUrl((Int64)new Random(100).NextDouble())
            };

            var repository = new Mock<IUrlRepository>();
            repository.Setup(x => x.Create(entity))
                      .ReturnsAsync(true);

            UrlService service = new UrlService(repository.Object,Mock.Of<IDbHelper>(), Mock.Of<IUrlShortHelper>());

            var result = await service.Create(entity);
        }

        private int IDbHelper()
        {
            throw new NotImplementedException();
        }
    }
}