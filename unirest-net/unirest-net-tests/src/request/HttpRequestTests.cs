using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    class HttpRequestTests
    {
        [Test]
        public static void HttpRequest_Should_Construct()
        {
            Action Get = () => new HttpRequest(HttpMethod.Get, "http://localhost");
            Action Post = () => new HttpRequest(HttpMethod.Post, "http://localhost");
            Action Delete = () => new HttpRequest(HttpMethod.Delete, "http://localhost");
            Action Patch = () => new HttpRequest(new HttpMethod("PATCH"), "http://localhost");
            Action Put = () => new HttpRequest(HttpMethod.Put, "http://localhost");

            Get.ShouldNotThrow();
            Post.ShouldNotThrow();
            Delete.ShouldNotThrow();
            Patch.ShouldNotThrow();
            Put.ShouldNotThrow();
        }

        [Test]
        public static void HttpRequest_Should_Not_Construct_With_Invalid_URL()
        {
            Action Get = () => new HttpRequest(HttpMethod.Get, "http:///invalid");
            Action Post = () => new HttpRequest(HttpMethod.Post, "http:///invalid");
            Action Delete = () => new HttpRequest(HttpMethod.Delete, "http:///invalid");
            Action Patch = () => new HttpRequest(new HttpMethod("PATCH"), "http:///invalid");
            Action Put = () => new HttpRequest(HttpMethod.Put, "http:///invalid");

            Get.ShouldThrow<ArgumentException>();
            Post.ShouldThrow<ArgumentException>();
            Delete.ShouldThrow<ArgumentException>();
            Patch.ShouldThrow<ArgumentException>();
            Put.ShouldThrow<ArgumentException>();
        }

        [Test]
        public static void HttpRequest_Should_Not_Construct_With_None_HTTP_URL()
        {
            Action Get = () => new HttpRequest(HttpMethod.Get, "ftp://localhost");
            Action Post = () => new HttpRequest(HttpMethod.Post, "mailto:localhost");
            Action Delete = () => new HttpRequest(HttpMethod.Delete, "news://localhost");
            Action Patch = () => new HttpRequest(new HttpMethod("PATCH"), "about:blank");
            Action Put = () => new HttpRequest(HttpMethod.Put, "about:settings");

            Get.ShouldThrow<ArgumentException>();
            Post.ShouldThrow<ArgumentException>();
            Delete.ShouldThrow<ArgumentException>();
            Patch.ShouldThrow<ArgumentException>();
            Put.ShouldThrow<ArgumentException>();
        }

        [Test]
        public static void HttpRequest_Should_Construct_With_Correct_Verb()
        {
            var Get = new HttpRequest(HttpMethod.Get, "http://localhost");
            var Post = new HttpRequest(HttpMethod.Post, "http://localhost");
            var Delete = new HttpRequest(HttpMethod.Delete, "http://localhost");
            var Patch = new HttpRequest(new HttpMethod("PATCH"), "http://localhost");
            var Put = new HttpRequest(HttpMethod.Put, "http://localhost");

            Get.HttpMethod.Should().Be(HttpMethod.Get);
            Post.HttpMethod.Should().Be(HttpMethod.Post);
            Delete.HttpMethod.Should().Be(HttpMethod.Delete);
            Patch.HttpMethod.Should().Be(new HttpMethod("PATCH"));
            Put.HttpMethod.Should().Be(HttpMethod.Put);
        }

        [Test]
        public static void HttpRequest_Should_Construct_With_Correct_URL()
        {
            var Get = new HttpRequest(HttpMethod.Get, "http://localhost");
            var Post = new HttpRequest(HttpMethod.Post, "http://localhost");
            var Delete = new HttpRequest(HttpMethod.Delete, "http://localhost");
            var Patch = new HttpRequest(new HttpMethod("PATCH"), "http://localhost");
            var Put = new HttpRequest(HttpMethod.Put, "http://localhost");

            Get.URL.OriginalString.Should().Be("http://localhost");
            Post.URL.OriginalString.Should().Be("http://localhost");
            Delete.URL.OriginalString.Should().Be("http://localhost");
            Patch.URL.OriginalString.Should().Be("http://localhost");
            Put.URL.OriginalString.Should().Be("http://localhost");
        }

        [Test]
        public static void HttpRequest_Should_Construct_With_Headers()
        {
            var Get = new HttpRequest(HttpMethod.Get, "http://localhost");
            var Post = new HttpRequest(HttpMethod.Post, "http://localhost");
            var Delete = new HttpRequest(HttpMethod.Delete, "http://localhost");
            var Patch = new HttpRequest(new HttpMethod("PATCH"), "http://localhost");
            var Put = new HttpRequest(HttpMethod.Put, "http://localhost");

            Get.Headers.Should().NotBeNull();
            Post.URL.OriginalString.Should().NotBeNull();
            Delete.URL.OriginalString.Should().NotBeNull();
            Patch.URL.OriginalString.Should().NotBeNull();
            Put.URL.OriginalString.Should().NotBeNull();
        }

        [Test]
        public static void HttpRequest_Should_Add_Headers()
        {
            var Get = new HttpRequest(HttpMethod.Get, "http://localhost");
            var Post = new HttpRequest(HttpMethod.Post, "http://localhost");
            var Delete = new HttpRequest(HttpMethod.Delete, "http://localhost");
            var Patch = new HttpRequest(new HttpMethod("PATCH"), "http://localhost");
            var Put = new HttpRequest(HttpMethod.Put, "http://localhost");

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

        [Test]
        public static void HttpRequest_Should_Return_String()
        {
            var Get = new HttpRequest(HttpMethod.Get, "http://www.google.com");
            var Post = new HttpRequest(HttpMethod.Post, "http://www.google.com");
            var Delete = new HttpRequest(HttpMethod.Delete, "http://www.google.com");
            var Patch = new HttpRequest(new HttpMethod("PATCH"), "http://www.google.com");
            var Put = new HttpRequest(HttpMethod.Put, "http://www.google.com");

            Get.asString().Body.Should().NotBeBlank();
            Post.asString().Body.Should().NotBeBlank();
            Delete.asString().Body.Should().NotBeBlank();
            Patch.asString().Body.Should().NotBeBlank();
            Put.asString().Body.Should().NotBeBlank();
        }

        [Test]
        public static void HttpRequest_Should_Return_Stream()
        {
            var Get = new HttpRequest(HttpMethod.Get, "http://www.google.com");
            var Post = new HttpRequest(HttpMethod.Post, "http://www.google.com");
            var Delete = new HttpRequest(HttpMethod.Delete, "http://www.google.com");
            var Patch = new HttpRequest(new HttpMethod("PATCH"), "http://www.google.com");
            var Put = new HttpRequest(HttpMethod.Put, "http://www.google.com");

            Get.asBinary().Body.Should().NotBeNull();
            Post.asBinary().Body.Should().NotBeNull();
            Delete.asBinary().Body.Should().NotBeNull();
            Patch.asBinary().Body.Should().NotBeNull();
            Put.asBinary().Body.Should().NotBeNull();
        }

        [Test]
        public static void HttpRequest_Should_Return_Parsed_JSON()
        {
            var Get = new HttpRequest(HttpMethod.Get, "http://www.google.com");
            var Post = new HttpRequest(HttpMethod.Post, "http://www.google.com");
            var Delete = new HttpRequest(HttpMethod.Delete, "http://www.google.com");
            var Patch = new HttpRequest(new HttpMethod("PATCH"), "http://www.google.com");
            var Put = new HttpRequest(HttpMethod.Put, "http://www.google.com");

            Get.asJson<String>().Body.Should().NotBeBlank();
            Post.asJson<String>().Body.Should().NotBeBlank();
            Delete.asJson<String>().Body.Should().NotBeBlank();
            Patch.asJson<String>().Body.Should().NotBeBlank();
            Put.asJson<String>().Body.Should().NotBeBlank();
        }

        [Test]
        public static void HttpRequest_Should_Return_String_Async()
        {
            var Get = new HttpRequest(HttpMethod.Get, "http://www.google.com").asStringAsync();
            var Post = new HttpRequest(HttpMethod.Post, "http://www.google.com").asStringAsync();
            var Delete = new HttpRequest(HttpMethod.Delete, "http://www.google.com").asStringAsync();
            var Patch = new HttpRequest(new HttpMethod("PATCH"), "http://www.google.com").asStringAsync();
            var Put = new HttpRequest(HttpMethod.Put, "http://www.google.com").asStringAsync();

            Task.WaitAll(Get, Post, Delete, Patch, Put);

            Get.Result.Body.Should().NotBeBlank();
            Post.Result.Body.Should().NotBeBlank();
            Delete.Result.Body.Should().NotBeBlank();
            Patch.Result.Body.Should().NotBeBlank();
            Put.Result.Body.Should().NotBeBlank();
        }

        [Test]
        public static void HttpRequest_Should_Return_Stream_Async()
        {
            var Get = new HttpRequest(HttpMethod.Get, "http://www.google.com").asBinaryAsync();
            var Post = new HttpRequest(HttpMethod.Post, "http://www.google.com").asBinaryAsync();
            var Delete = new HttpRequest(HttpMethod.Delete, "http://www.google.com").asBinaryAsync();
            var Patch = new HttpRequest(new HttpMethod("PATCH"), "http://www.google.com").asBinaryAsync();
            var Put = new HttpRequest(HttpMethod.Put, "http://www.google.com").asBinaryAsync();

            Task.WaitAll(Get, Post, Delete, Patch, Put);

            Get.Result.Body.Should().NotBeNull();
            Post.Result.Body.Should().NotBeNull();
            Delete.Result.Body.Should().NotBeNull();
            Patch.Result.Body.Should().NotBeNull();
            Put.Result.Body.Should().NotBeNull();
        }

        [Test]
        public static void HttpRequest_Should_Return_Parsed_JSON_Async()
        {
            var Get = new HttpRequest(HttpMethod.Get, "http://www.google.com").asJsonAsync<String>();
            var Post = new HttpRequest(HttpMethod.Post, "http://www.google.com").asJsonAsync<String>();
            var Delete = new HttpRequest(HttpMethod.Delete, "http://www.google.com").asJsonAsync<String>();
            var Patch = new HttpRequest(new HttpMethod("PATCH"), "http://www.google.com").asJsonAsync<String>();
            var Put = new HttpRequest(HttpMethod.Put, "http://www.google.com").asJsonAsync<String>();

            Task.WaitAll(Get, Post, Delete, Patch, Put);

            Get.Result.Body.Should().NotBeBlank();
            Post.Result.Body.Should().NotBeBlank();
            Delete.Result.Body.Should().NotBeBlank();
            Patch.Result.Body.Should().NotBeBlank();
            Put.Result.Body.Should().NotBeBlank();
        }
    }
}
