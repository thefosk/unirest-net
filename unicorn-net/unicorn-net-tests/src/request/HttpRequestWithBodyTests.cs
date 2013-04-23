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
    class HttpRequestWithBodyTests
    {
        [Test]
        public static void HttpRequestWithBody_Should_Construct_With_Get()
        {
            Action construct = () => new HttpRequestWithBody(HttpMethod.GET, "http://localhost");
            construct.ShouldNotThrow();
        }

        [Test]
        public static void HttpRequestWithBody_Should_Construct_With_Post()
        {
            Action construct = () => new HttpRequestWithBody(HttpMethod.POST, "http://localhost");
            construct.ShouldNotThrow();
        }

        [Test]
        public static void HttpRequestWithBody_Should_Construct_With_Delete()
        {
            Action construct = () => new HttpRequestWithBody(HttpMethod.DELETE, "http://localhost");
            construct.ShouldNotThrow();
        }

        [Test]
        public static void HttpRequestWithBody_Should_Construct_With_Patch()
        {
            Action construct = () => new HttpRequestWithBody(HttpMethod.PATCH, "http://localhost");
            construct.ShouldNotThrow();
        }

        [Test]
        public static void HttpRequestWithBody_Should_Construct_With_Put()
        {
            Action construct = () => new HttpRequestWithBody(HttpMethod.PUT, "http://localhost");
            construct.ShouldNotThrow();
        }

        [Test]
        public static void HttpRequestWithBody_Should_Not_Construct_With_Invalid_URL()
        {
            Action get = () => new HttpRequestWithBody(HttpMethod.GET, "http:///invalid");
            Action post = () => new HttpRequestWithBody(HttpMethod.POST, "http:///invalid");
            Action delete = () => new HttpRequestWithBody(HttpMethod.DELETE, "http:///invalid");
            Action patch = () => new HttpRequestWithBody(HttpMethod.PATCH, "http:///invalid");
            Action put = () => new HttpRequestWithBody(HttpMethod.PUT, "http:///invalid");

            get.ShouldThrow<ArgumentException>();
            post.ShouldThrow<ArgumentException>();
            delete.ShouldThrow<ArgumentException>();
            patch.ShouldThrow<ArgumentException>();
            put.ShouldThrow<ArgumentException>();
        }

        [Test]
        public static void HttpRequestWithBody_Should_Not_Construct_With_None_HTTP_URL()
        {
            Action get = () => new HttpRequestWithBody(HttpMethod.GET, "ftp://localhost");
            Action post = () => new HttpRequestWithBody(HttpMethod.POST, "mailto:localhost");
            Action delete = () => new HttpRequestWithBody(HttpMethod.DELETE, "news://localhost");
            Action patch = () => new HttpRequestWithBody(HttpMethod.PATCH, "about:blank");
            Action put = () => new HttpRequestWithBody(HttpMethod.PUT, "about:settings");

            get.ShouldThrow<ArgumentException>();
            post.ShouldThrow<ArgumentException>();
            delete.ShouldThrow<ArgumentException>();
            patch.ShouldThrow<ArgumentException>();
            put.ShouldThrow<ArgumentException>();  
        }
    }
}
