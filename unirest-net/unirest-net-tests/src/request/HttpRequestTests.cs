//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//using NUnit;
//using NUnit.Framework;
//using FluentAssertions;

//using unirest_net;
//using unirest_net.http;
//using unirest_net.request;

//namespace unicorn_net_tests.request
//{
//    [TestFixture]
//    class HttpRequestTests
//    {
//        [Test]
//        public static void HttpRequest_Should_Construct()
//        {
//            Action get = () => new HttpRequest(HttpMethod.GET, "http://localhost");
//            Action Post = () => new HttpRequest(HttpMethod.Post, "http://localhost");
//            Action delete = () => new HttpRequest(HttpMethod.DELETE, "http://localhost");
//            Action patch = () => new HttpRequest(HttpMethod.PATCH, "http://localhost");
//            Action put = () => new HttpRequest(HttpMethod.PUT, "http://localhost");

//            get.ShouldNotThrow();
//            Post.ShouldNotThrow();
//            delete.ShouldNotThrow();
//            patch.ShouldNotThrow();
//            put.ShouldNotThrow();
//        }

//        [Test]
//        public static void HttpRequest_Should_Not_Construct_With_Invalid_URL()
//        {
//            Action get = () => new HttpRequest(HttpMethod.GET, "http:///invalid");
//            Action Post = () => new HttpRequest(HttpMethod.Post, "http:///invalid");
//            Action delete = () => new HttpRequest(HttpMethod.DELETE, "http:///invalid");
//            Action patch = () => new HttpRequest(HttpMethod.PATCH, "http:///invalid");
//            Action put = () => new HttpRequest(HttpMethod.PUT, "http:///invalid");

//            get.ShouldThrow<ArgumentException>();
//            Post.ShouldThrow<ArgumentException>();
//            delete.ShouldThrow<ArgumentException>();
//            patch.ShouldThrow<ArgumentException>();
//            put.ShouldThrow<ArgumentException>();
//        }

//        [Test]
//        public static void HttpRequest_Should_Not_Construct_With_None_HTTP_URL()
//        {
//            Action get = () => new HttpRequest(HttpMethod.GET, "ftp://localhost");
//            Action Post = () => new HttpRequest(HttpMethod.Post, "mailto:localhost");
//            Action delete = () => new HttpRequest(HttpMethod.DELETE, "news://localhost");
//            Action patch = () => new HttpRequest(HttpMethod.PATCH, "about:blank");
//            Action put = () => new HttpRequest(HttpMethod.PUT, "about:settings");

//            get.ShouldThrow<ArgumentException>();
//            Post.ShouldThrow<ArgumentException>();
//            delete.ShouldThrow<ArgumentException>();
//            patch.ShouldThrow<ArgumentException>();
//            put.ShouldThrow<ArgumentException>();  
//        }

//        [Test]
//        public static void HttpRequest_Should_Construct_With_Correct_Verb()
//        {
//            var get = new HttpRequest(HttpMethod.GET, "http://localhost");
//            var Post = new HttpRequest(HttpMethod.Post, "http://localhost");
//            var delete = new HttpRequest(HttpMethod.DELETE, "http://localhost");
//            var patch = new HttpRequest(HttpMethod.PATCH, "http://localhost");
//            var put = new HttpRequest(HttpMethod.PUT, "http://localhost");

//            get.HttpMethod.Should().Be(HttpMethod.GET);
//            Post.HttpMethod.Should().Be(HttpMethod.Post);
//            delete.HttpMethod.Should().Be(HttpMethod.DELETE);
//            patch.HttpMethod.Should().Be(HttpMethod.PATCH);
//            put.HttpMethod.Should().Be(HttpMethod.PUT);
//        }

//        [Test]
//        public static void HttpRequest_Should_Construct_With_Correct_URL()
//        {
//            var get = new HttpRequest(HttpMethod.GET, "http://localhost");
//            var Post = new HttpRequest(HttpMethod.Post, "http://localhost");
//            var delete = new HttpRequest(HttpMethod.DELETE, "http://localhost");
//            var patch = new HttpRequest(HttpMethod.PATCH, "http://localhost");
//            var put = new HttpRequest(HttpMethod.PUT, "http://localhost");

//            get.URL.OriginalString.Should().Be("http://localhost");
//            Post.URL.OriginalString.Should().Be("http://localhost");
//            delete.URL.OriginalString.Should().Be("http://localhost");
//            patch.URL.OriginalString.Should().Be("http://localhost");
//            put.URL.OriginalString.Should().Be("http://localhost");
//        }

//        [Test]
//        public static void HttpRequest_Should_Construct_With_Headers()
//        {
//            var get = new HttpRequest(HttpMethod.GET, "http://localhost");
//            var Post = new HttpRequest(HttpMethod.Post, "http://localhost");
//            var delete = new HttpRequest(HttpMethod.DELETE, "http://localhost");
//            var patch = new HttpRequest(HttpMethod.PATCH, "http://localhost");
//            var put = new HttpRequest(HttpMethod.PUT, "http://localhost");

//            get.Headers.Should().NotBeNull();
//            Post.URL.OriginalString.Should().NotBeNull();
//            delete.URL.OriginalString.Should().NotBeNull();
//            patch.URL.OriginalString.Should().NotBeNull();
//            put.URL.OriginalString.Should().NotBeNull();
//        }

//        [Test]
//        public static void HttpRequest_Should_Add_Headers()
//        {
//            var get = new HttpRequest(HttpMethod.GET, "http://localhost");
//            var Post = new HttpRequest(HttpMethod.Post, "http://localhost");
//            var delete = new HttpRequest(HttpMethod.DELETE, "http://localhost");
//            var patch = new HttpRequest(HttpMethod.PATCH, "http://localhost");
//            var put = new HttpRequest(HttpMethod.PUT, "http://localhost");

//            get.header("User-Agent", "unicorn-net/1.0");
//            Post.header("User-Agent", "unicorn-net/1.0");
//            delete.header("User-Agent", "unicorn-net/1.0");
//            patch.header("User-Agent", "unicorn-net/1.0");
//            put.header("User-Agent", "unicorn-net/1.0");

//            get.Headers.Should().Contain("User-Agent", "unicorn-net/1.0");
//            Post.Headers.Should().Contain("User-Agent", "unicorn-net/1.0");
//            delete.Headers.Should().Contain("User-Agent", "unicorn-net/1.0");
//            patch.Headers.Should().Contain("User-Agent", "unicorn-net/1.0");
//            put.Headers.Should().Contain("User-Agent", "unicorn-net/1.0");
//        }
//    }
//}
