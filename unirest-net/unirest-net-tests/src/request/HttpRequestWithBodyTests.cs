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
    class HttpRequestWithBodyTests
    {
        [Test]
        public static void HttpRequestWithBody_Should_Construct()
        {
            Action Post = () => new HttpRequestWithBody(HttpMethod.Post, "http://localhost");
            Action Delete = () => new HttpRequestWithBody(HttpMethod.Delete, "http://localhost");
            Action Patch = () => new HttpRequestWithBody(new HttpMethod("PATCH"), "http://localhost");
            Action Put = () => new HttpRequestWithBody(HttpMethod.Put, "http://localhost");

            Post.ShouldNotThrow();
            Delete.ShouldNotThrow();
            Patch.ShouldNotThrow();
            Put.ShouldNotThrow();
        }

        [Test]
        public static void HttpRequestWithBody_Should_Npt_Construct_For_Get()
        {
            Action Get = () => new HttpRequestWithBody(HttpMethod.Get, "http://localhost");
            Get.ShouldThrow<ArgumentException>();
        }

        [Test]
        public static void HttpRequestWithBody_Should_Not_Construct_With_Invalid_URL()
        {
            Action Post = () => new HttpRequestWithBody(HttpMethod.Post, "http:///invalid");
            Action delete = () => new HttpRequestWithBody(HttpMethod.Delete, "http:///invalid");
            Action patch = () => new HttpRequestWithBody(new HttpMethod("PATCH"), "http:///invalid");
            Action put = () => new HttpRequestWithBody(HttpMethod.Put, "http:///invalid");

            Post.ShouldThrow<ArgumentException>();
            delete.ShouldThrow<ArgumentException>();
            patch.ShouldThrow<ArgumentException>();
            put.ShouldThrow<ArgumentException>();
        }

        [Test]
        public static void HttpRequestWithBody_Should_Not_Construct_With_None_HTTP_URL()
        {
            Action Post = () => new HttpRequestWithBody(HttpMethod.Post, "mailto:localhost");
            Action delete = () => new HttpRequestWithBody(HttpMethod.Delete, "news://localhost");
            Action patch = () => new HttpRequestWithBody(new HttpMethod("PATCH"), "about:blank");
            Action put = () => new HttpRequestWithBody(HttpMethod.Put, "about:settings");

            Post.ShouldThrow<ArgumentException>();
            delete.ShouldThrow<ArgumentException>();
            patch.ShouldThrow<ArgumentException>();
            put.ShouldThrow<ArgumentException>();
        }

        [Test]
        public static void HttpRequestWithBody_Should_Construct_With_Correct_Verb()
        {
            var Post = new HttpRequestWithBody(HttpMethod.Post, "http://localhost");
            var Delete = new HttpRequestWithBody(HttpMethod.Delete, "http://localhost");
            var Patch = new HttpRequestWithBody(new HttpMethod("PATCH"), "http://localhost");
            var Put = new HttpRequestWithBody(HttpMethod.Put, "http://localhost");

            Post.HttpMethod.Should().Be(HttpMethod.Post);
            Delete.HttpMethod.Should().Be(HttpMethod.Delete);
            Patch.HttpMethod.Should().Be(new HttpMethod("PATCH"));
            Put.HttpMethod.Should().Be(HttpMethod.Put);
        }

        [Test]
        public static void HttpRequestWithBody_Should_Construct_With_Correct_URL()
        {
            var Post = new HttpRequestWithBody(HttpMethod.Post, "http://localhost");
            var Delete = new HttpRequestWithBody(HttpMethod.Delete, "http://localhost");
            var Patch = new HttpRequestWithBody(new HttpMethod("PATCH"), "http://localhost");
            var Put = new HttpRequestWithBody(HttpMethod.Put, "http://localhost");

            Post.URL.OriginalString.Should().Be("http://localhost");
            Delete.URL.OriginalString.Should().Be("http://localhost");
            Patch.URL.OriginalString.Should().Be("http://localhost");
            Put.URL.OriginalString.Should().Be("http://localhost");
        }

        [Test]
        public static void HttpRequestWithBody_Should_Construct_With_Headers()
        {
            var Post = new HttpRequestWithBody(HttpMethod.Post, "http://localhost");
            var Delete = new HttpRequestWithBody(HttpMethod.Delete, "http://localhost");
            var Patch = new HttpRequestWithBody(new HttpMethod("PATCH"), "http://localhost");
            var Put = new HttpRequestWithBody(HttpMethod.Put, "http://localhost");

            Post.URL.OriginalString.Should().NotBeNull();
            Delete.URL.OriginalString.Should().NotBeNull();
            Patch.URL.OriginalString.Should().NotBeNull();
            Put.URL.OriginalString.Should().NotBeNull();
        }

        [Test]
        public static void HttpRequestWithBody_Should_Add_Headers()
        {
            var Post = new HttpRequestWithBody(HttpMethod.Post, "http://localhost");
            var Delete = new HttpRequestWithBody(HttpMethod.Delete, "http://localhost");
            var Patch = new HttpRequestWithBody(new HttpMethod("PATCH"), "http://localhost");
            var Put = new HttpRequestWithBody(HttpMethod.Put, "http://localhost");

            Post.header("User-Agent", "unirest-net/1.0");
            Delete.header("User-Agent", "unirest-net/1.0");
            Patch.header("User-Agent", "unirest-net/1.0");
            Put.header("User-Agent", "unirest-net/1.0");

            Post.Headers.Should().Contain("User-Agent", "unirest-net/1.0");
            Delete.Headers.Should().Contain("User-Agent", "unirest-net/1.0");
            Patch.Headers.Should().Contain("User-Agent", "unirest-net/1.0");
            Put.Headers.Should().Contain("User-Agent", "unirest-net/1.0");
        }


        [Test]
        public static void HttpRequestWithBody_Should_Return_String()
        {
            var Post = new HttpRequestWithBody(HttpMethod.Post, "http://www.google.com");
            var Delete = new HttpRequestWithBody(HttpMethod.Delete, "http://www.google.com");
            var Patch = new HttpRequestWithBody(new HttpMethod("PATCH"), "http://www.google.com");
            var Put = new HttpRequestWithBody(HttpMethod.Put, "http://www.google.com");

            Post.asString().Body.Should().NotBeBlank();
            Delete.asString().Body.Should().NotBeBlank();
            Patch.asString().Body.Should().NotBeBlank();
            Put.asString().Body.Should().NotBeBlank();
        }

        [Test]
        public static void HttpRequestWithBody_Should_Return_Stream()
        {
            var Post = new HttpRequestWithBody(HttpMethod.Post, "http://www.google.com");
            var Delete = new HttpRequestWithBody(HttpMethod.Delete, "http://www.google.com");
            var Patch = new HttpRequestWithBody(new HttpMethod("PATCH"), "http://www.google.com");
            var Put = new HttpRequestWithBody(HttpMethod.Put, "http://www.google.com");

            Post.asBinary().Body.Should().NotBeNull();
            Delete.asBinary().Body.Should().NotBeNull();
            Patch.asBinary().Body.Should().NotBeNull();
            Put.asBinary().Body.Should().NotBeNull();
        }

        [Test]
        public static void HttpRequestWithBody_Should_Return_Parsed_JSON()
        {
            var Post = new HttpRequestWithBody(HttpMethod.Post, "http://www.google.com");
            var Delete = new HttpRequestWithBody(HttpMethod.Delete, "http://www.google.com");
            var Patch = new HttpRequestWithBody(new HttpMethod("PATCH"), "http://www.google.com");
            var Put = new HttpRequestWithBody(HttpMethod.Put, "http://www.google.com");

            Post.asJson<String>().Body.Should().NotBeBlank();
            Delete.asJson<String>().Body.Should().NotBeBlank();
            Patch.asJson<String>().Body.Should().NotBeBlank();
            Put.asJson<String>().Body.Should().NotBeBlank();
        }

        [Test]
        public static void HttpRequestWithBody_Should_Return_String_Async()
        {
            var Post = new HttpRequestWithBody(HttpMethod.Post, "http://www.google.com").asStringAsync();
            var Delete = new HttpRequestWithBody(HttpMethod.Delete, "http://www.google.com").asStringAsync();
            var Patch = new HttpRequestWithBody(new HttpMethod("PATCH"), "http://www.google.com").asStringAsync();
            var Put = new HttpRequestWithBody(HttpMethod.Put, "http://www.google.com").asStringAsync();

            Task.WaitAll(Post, Delete, Patch, Put);

            Post.Result.Body.Should().NotBeBlank();
            Delete.Result.Body.Should().NotBeBlank();
            Patch.Result.Body.Should().NotBeBlank();
            Put.Result.Body.Should().NotBeBlank();
        }

        [Test]
        public static void HttpRequestWithBody_Should_Return_Stream_Async()
        {
            var Post = new HttpRequestWithBody(HttpMethod.Post, "http://www.google.com").asBinaryAsync();
            var Delete = new HttpRequestWithBody(HttpMethod.Delete, "http://www.google.com").asBinaryAsync();
            var Patch = new HttpRequestWithBody(new HttpMethod("PATCH"), "http://www.google.com").asBinaryAsync();
            var Put = new HttpRequestWithBody(HttpMethod.Put, "http://www.google.com").asBinaryAsync();

            Task.WaitAll(Post, Delete, Patch, Put);

            Post.Result.Body.Should().NotBeNull();
            Delete.Result.Body.Should().NotBeNull();
            Patch.Result.Body.Should().NotBeNull();
            Put.Result.Body.Should().NotBeNull();
        }

        [Test]
        public static void HttpRequest_Should_Return_Parsed_JSON_Async()
        {
            var Post = new HttpRequestWithBody(HttpMethod.Post, "http://www.google.com").asJsonAsync<String>();
            var Delete = new HttpRequestWithBody(HttpMethod.Delete, "http://www.google.com").asJsonAsync<String>();
            var Patch = new HttpRequestWithBody(new HttpMethod("PATCH"), "http://www.google.com").asJsonAsync<String>();
            var Put = new HttpRequestWithBody(HttpMethod.Put, "http://www.google.com").asJsonAsync<String>();

            Task.WaitAll(Post, Delete, Patch, Put);

            Post.Result.Body.Should().NotBeBlank();
            Delete.Result.Body.Should().NotBeBlank();
            Patch.Result.Body.Should().NotBeBlank();
            Put.Result.Body.Should().NotBeBlank();
        }
    }
}
