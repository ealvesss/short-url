using AutoMapper;
using FluentAssertions;
using HeyUrl.Application;
using HeyUrl.Application.Dtos;
using HeyUrl.Application.Interfaces;
using HeyUrl.Domain;
using HeyUrl.Domain.Entities;
using HeyUrl.Domain.Services.Interfaces;
using HeyUrl.Helper;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tests
{
    public class UrlUnityTest
    {
        private IMapper _mockMapper;

        [SetUp]
        public void Setup()
        {
            _mockMapper = Mock.Of<IMapper>();
        }

        [Test]
        public async Task should_relationship_correct()
        {
            var urlEntity = new Url()
            {
                ShortUrl = "ABCDE",
                OriginalUrl = "http://www.google.com"
            };

            var clickEntity = new Click()
            {
                UrlId = urlEntity.Id,
                ClickedAt = DateTime.Now,
            };

            var platformEntity = new Platform()
            {
                ClickId = clickEntity.Id,
                Description = "Ubuntu; Linux i686; rv:94.0"
            };

            var browserEntity = new Browser()
            {
                PlatformId = platformEntity.Id,
                Description = "Firefox"
            };

            platformEntity.Browser = browserEntity;
            clickEntity.Platform = platformEntity;
            urlEntity.Click = new List<Click>()
            {
                clickEntity
            };

            var mockEntity = new List<Url>()
            {
                urlEntity
            };


            var repository = new Mock<IUrlRepository>();

            repository.Setup(x => x.GetAll()).ReturnsAsync(await Task.FromResult(mockEntity));

            UrlService service = new UrlService(repository.Object, Mock.Of<IDbHelper>(), Mock.Of<IUrlShortHelper>());

            var result = service.GetAll().Result.FirstOrDefault();

            result.Id.Should().Be(urlEntity.Id);
            result.Click.FirstOrDefault().UrlId.Should().Be(result.Id);
            result.Click.FirstOrDefault().Platform.ClickId.Should().Be(result.Click.FirstOrDefault().Id);
            result.Click.FirstOrDefault().Platform.Browser.PlatformId.Should().Be(result.Click.FirstOrDefault().Platform.Id);
        }

        [Test]
        public async Task should_create_short_url_with_success()
        {
            var entity = new Url()
            {
                Click = new List<Click>()
                {
                    new Click()
                    {
                        ClickedAt = DateTime.Now,
                    }
                },
                CreatedAt = DateTime.Now,
                OriginalUrl = "http://google.com",
                ShortUrl = new UrlShortHelper().ShortUrl((Int64)new Random(100).NextDouble())
            };

            var repository = new Mock<IUrlRepository>();

            repository.Setup(x => x.Create(entity));

            UrlService service = new UrlService(repository.Object, Mock.Of<IDbHelper>(), Mock.Of<IUrlShortHelper>());

            var result = await service.Create(entity);
        }

        [Test]
        public async Task should_not_create_short_url_with_empty_original_url_field()
        {
            var entity = new UrlRequestDto()
            {
                Click = null,
                OriginalUrl = "",
                ShortUrl = new UrlShortHelper().ShortUrl((Int64)new Random(100).NextDouble())
            };

            var application = new Mock<IUrlApplication>();

            application.Setup(x => x.Create(entity));

            UrlApplication service = new UrlApplication(Mock.Of<IUrlService>(), _mockMapper, Mock.Of<IUrlShortHelper>());

            var result = await service.Create(entity);

            result.Should().Be("Url should be informed!");
        }
    }
}