using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit;
using NUnit.Framework;
using FluentAssertions;

using unirest_net;
using unirest_net.http;
using unirest_net.request;

using System.Net.Http;

namespace unicorn_net_tests.request
{
    [TestFixture]
    class HttpRequestWithBodyTests
    {
        [Test]
        public static void HttpRequest_Should_Construct()
        {
            Action Get = () => new HttpRequestWithBody(HttpMethod.Get, "http://localhost");
            Action Post = () => new HttpRequestWithBody(HttpMethod.Post, "http://localhost");
            Action Delete = () => new HttpRequestWithBody(HttpMethod.Delete, "http://localhost");
            Action Patch = () => new HttpRequestWithBody(new HttpMethod("PATCH"), "http://localhost");
            Action Put = () => new HttpRequestWithBody(HttpMethod.Put, "http://localhost");

            Get.ShouldNotThrow();
            Post.ShouldNotThrow();
            Delete.ShouldNotThrow();
            Patch.ShouldNotThrow();
            Put.ShouldNotThrow();
        }

        [Test]
        public static void HttpRequestWithBody_Should_Not_Construct_With_Invalid_URL()
        {
            Action get = () => new HttpRequestWithBody(HttpMethod.Get, "http:///invalid");
            Action Post = () => new HttpRequestWithBody(HttpMethod.Post, "http:///invalid");
            Action delete = () => new HttpRequestWithBody(HttpMethod.Delete, "http:///invalid");
            Action patch = () => new HttpRequestWithBody(new HttpMethod("PATCH"), "http:///invalid");
            Action put = () => new HttpRequestWithBody(HttpMethod.Put, "http:///invalid");

            get.ShouldThrow<ArgumentException>();
            Post.ShouldThrow<ArgumentException>();
            delete.ShouldThrow<ArgumentException>();
            patch.ShouldThrow<ArgumentException>();
            put.ShouldThrow<ArgumentException>();
        }

        [Test]
        public static void HttpRequestWithBody_Should_Not_Construct_With_None_HTTP_URL()
        {
            Action get = () => new HttpRequestWithBody(HttpMethod.Get, "ftp://localhost");
            Action Post = () => new HttpRequestWithBody(HttpMethod.Post, "mailto:localhost");
            Action delete = () => new HttpRequestWithBody(HttpMethod.Delete, "news://localhost");
            Action patch = () => new HttpRequestWithBody(new HttpMethod("PATCH"), "about:blank");
            Action put = () => new HttpRequestWithBody(HttpMethod.Put, "about:settings");

            get.ShouldThrow<ArgumentException>();
            Post.ShouldThrow<ArgumentException>();
            delete.ShouldThrow<ArgumentException>();
            patch.ShouldThrow<ArgumentException>();
            put.ShouldThrow<ArgumentException>();
        }

        [Test]
        public static void HttpRequestWithBody_Should_Construct_With_Correct_Verb()
        {
            var Get = new HttpRequestWithBody(HttpMethod.Get, "http://localhost");
            var Post = new HttpRequestWithBody(HttpMethod.Post, "http://localhost");
            var Delete = new HttpRequestWithBody(HttpMethod.Delete, "http://localhost");
            var Patch = new HttpRequestWithBody(new HttpMethod("PATCH"), "http://localhost");
            var Put = new HttpRequestWithBody(HttpMethod.Put, "http://localhost");

            Get.HttpMethod.Should().Be(HttpMethod.Get);
            Post.HttpMethod.Should().Be(HttpMethod.Post);
            Delete.HttpMethod.Should().Be(HttpMethod.Delete);
            Patch.HttpMethod.Should().Be(new HttpMethod("PATCH"));
            Put.HttpMethod.Should().Be(HttpMethod.Put);
        }

        [Test]
        public static void HttpRequestWithBody_Should_Construct_With_Correct_URL()
        {
            var Get = new HttpRequestWithBody(HttpMethod.Get, "http://localhost");
            var Post = new HttpRequestWithBody(HttpMethod.Post, "http://localhost");
            var Delete = new HttpRequestWithBody(HttpMethod.Delete, "http://localhost");
            var Patch = new HttpRequestWithBody(new HttpMethod("PATCH"), "http://localhost");
            var Put = new HttpRequestWithBody(HttpMethod.Put, "http://localhost");

            Get.URL.OriginalString.Should().Be("http://localhost");
            Post.URL.OriginalString.Should().Be("http://localhost");
            Delete.URL.OriginalString.Should().Be("http://localhost");
            Patch.URL.OriginalString.Should().Be("http://localhost");
            Put.URL.OriginalString.Should().Be("http://localhost");
        }

        [Test]
        public static void HttpRequestWithBody_Should_Construct_With_Headers()
        {
            var Get = new HttpRequestWithBody(HttpMethod.Get, "http://localhost");
            var Post = new HttpRequestWithBody(HttpMethod.Post, "http://localhost");
            var Delete = new HttpRequestWithBody(HttpMethod.Delete, "http://localhost");
            var Patch = new HttpRequestWithBody(new HttpMethod("PATCH"), "http://localhost");
            var Put = new HttpRequestWithBody(HttpMethod.Put, "http://localhost");

            Get.Headers.Should().NotBeNull();
            Post.URL.OriginalString.Should().NotBeNull();
            Delete.URL.OriginalString.Should().NotBeNull();
            Patch.URL.OriginalString.Should().NotBeNull();
            Put.URL.OriginalString.Should().NotBeNull();
        }

        [Test]
        public static void HttpRequestWithBody_Should_Add_Headers()
        {
            var Get = new HttpRequestWithBody(HttpMethod.Get, "http://localhost");
            var Post = new HttpRequestWithBody(HttpMethod.Post, "http://localhost");
            var Delete = new HttpRequestWithBody(HttpMethod.Delete, "http://localhost");
            var Patch = new HttpRequestWithBody(new HttpMethod("PATCH"), "http://localhost");
            var Put = new HttpRequestWithBody(HttpMethod.Put, "http://localhost");

            Get.header("User-Agent", "unirest-net/1.0");
            Post.header("User-Agent", "unirest-net/1.0");
            Delete.header("User-Agent", "unirest-net/1.0");
            Patch.header("User-Agent", "unirest-net/1.0");
            Put.header("User-Agent", "unirest-net/1.0");

            Get.Headers.Should().Contain("User-Agent", "unirest-net/1.0");
            Post.Headers.Should().Contain("User-Agent", "unirest-net/1.0");
            Delete.Headers.Should().Contain("User-Agent", "unirest-net/1.0");
            Patch.Headers.Should().Contain("User-Agent", "unirest-net/1.0");
            Put.Headers.Should().Contain("User-Agent", "unirest-net/1.0");
        }
    }
}
