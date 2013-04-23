using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit;
using NUnit.Framework;
using FluentAssertions;

using unicorn_net;
using unicorn_net.http;
using unicorn_net.request;

namespace unicorn_net_tests.request
{
    [TestFixture]
    class HttpRequestTests
    {
        [Test]
        public static void HttpRequest_Should_Construct()
        {
            Action get = () => new HttpRequest(HttpMethod.GET, "http://localhost");
            Action post = () => new HttpRequest(HttpMethod.POST, "http://localhost");
            Action delete = () => new HttpRequest(HttpMethod.DELETE, "http://localhost");
            Action patch = () => new HttpRequest(HttpMethod.PATCH, "http://localhost");
            Action put = () => new HttpRequest(HttpMethod.PUT, "http://localhost");

            get.ShouldNotThrow();
            post.ShouldNotThrow();
            delete.ShouldNotThrow();
            patch.ShouldNotThrow();
            put.ShouldNotThrow();
        }

        [Test]
        public static void HttpRequest_Should_Not_Construct_With_Invalid_URL()
        {
            Action get = () => new HttpRequest(HttpMethod.GET, "http:///invalid");
            Action post = () => new HttpRequest(HttpMethod.POST, "http:///invalid");
            Action delete = () => new HttpRequest(HttpMethod.DELETE, "http:///invalid");
            Action patch = () => new HttpRequest(HttpMethod.PATCH, "http:///invalid");
            Action put = () => new HttpRequest(HttpMethod.PUT, "http:///invalid");

            get.ShouldThrow<ArgumentException>();
            post.ShouldThrow<ArgumentException>();
            delete.ShouldThrow<ArgumentException>();
            patch.ShouldThrow<ArgumentException>();
            put.ShouldThrow<ArgumentException>();
        }

        [Test]
        public static void HttpRequest_Should_Not_Construct_With_None_HTTP_URL()
        {
            Action get = () => new HttpRequest(HttpMethod.GET, "ftp://localhost");
            Action post = () => new HttpRequest(HttpMethod.POST, "mailto:localhost");
            Action delete = () => new HttpRequest(HttpMethod.DELETE, "news://localhost");
            Action patch = () => new HttpRequest(HttpMethod.PATCH, "about:blank");
            Action put = () => new HttpRequest(HttpMethod.PUT, "about:settings");

            get.ShouldThrow<ArgumentException>();
            post.ShouldThrow<ArgumentException>();
            delete.ShouldThrow<ArgumentException>();
            patch.ShouldThrow<ArgumentException>();
            put.ShouldThrow<ArgumentException>();  
        }

        [Test]
        public static void HttpRequest_Should_Construct_With_Correct_Verb()
        {
            var get = new HttpRequest(HttpMethod.GET, "http://localhost");
            var post = new HttpRequest(HttpMethod.POST, "http://localhost");
            var delete = new HttpRequest(HttpMethod.DELETE, "http://localhost");
            var patch = new HttpRequest(HttpMethod.PATCH, "http://localhost");
            var put = new HttpRequest(HttpMethod.PUT, "http://localhost");

            get.HttpMethod.Should().Be(HttpMethod.GET);
            post.HttpMethod.Should().Be(HttpMethod.POST);
            delete.HttpMethod.Should().Be(HttpMethod.DELETE);
            patch.HttpMethod.Should().Be(HttpMethod.PATCH);
            put.HttpMethod.Should().Be(HttpMethod.PUT);
        }

        [Test]
        public static void HttpRequest_Should_Construct_With_Correct_URL()
        {
            var get = new HttpRequest(HttpMethod.GET, "http://localhost");
            var post = new HttpRequest(HttpMethod.POST, "http://localhost");
            var delete = new HttpRequest(HttpMethod.DELETE, "http://localhost");
            var patch = new HttpRequest(HttpMethod.PATCH, "http://localhost");
            var put = new HttpRequest(HttpMethod.PUT, "http://localhost");

            get.URL.OriginalString.Should().Be("http://localhost");
            post.URL.OriginalString.Should().Be("http://localhost");
            delete.URL.OriginalString.Should().Be("http://localhost");
            patch.URL.OriginalString.Should().Be("http://localhost");
            put.URL.OriginalString.Should().Be("http://localhost");
        }

        [Test]
        public static void HttpRequest_Should_Construct_With_Headers()
        {
            var get = new HttpRequest(HttpMethod.GET, "http://localhost");
            var post = new HttpRequest(HttpMethod.POST, "http://localhost");
            var delete = new HttpRequest(HttpMethod.DELETE, "http://localhost");
            var patch = new HttpRequest(HttpMethod.PATCH, "http://localhost");
            var put = new HttpRequest(HttpMethod.PUT, "http://localhost");

            get.Headers.Should().NotBeNull();
            post.URL.OriginalString.Should().NotBeNull();
            delete.URL.OriginalString.Should().NotBeNull();
            patch.URL.OriginalString.Should().NotBeNull();
            put.URL.OriginalString.Should().NotBeNull();
        }

        [Test]
        public static void HttpRequest_Should_Add_Headers()
        {
            var get = new HttpRequest(HttpMethod.GET, "http://localhost");
            var post = new HttpRequest(HttpMethod.POST, "http://localhost");
            var delete = new HttpRequest(HttpMethod.DELETE, "http://localhost");
            var patch = new HttpRequest(HttpMethod.PATCH, "http://localhost");
            var put = new HttpRequest(HttpMethod.PUT, "http://localhost");

            get.header("User-Agent", "unicorn-net/1.0");
            post.header("User-Agent", "unicorn-net/1.0");
            delete.header("User-Agent", "unicorn-net/1.0");
            patch.header("User-Agent", "unicorn-net/1.0");
            put.header("User-Agent", "unicorn-net/1.0");

            get.Headers.Should().Contain("User-Agent", "unicorn-net/1.0");
            post.Headers.Should().Contain("User-Agent", "unicorn-net/1.0");
            delete.Headers.Should().Contain("User-Agent", "unicorn-net/1.0");
            patch.Headers.Should().Contain("User-Agent", "unicorn-net/1.0");
            put.Headers.Should().Contain("User-Agent", "unicorn-net/1.0");
        }
    }
}
