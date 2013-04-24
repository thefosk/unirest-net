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

//using System.Net.Http;

//namespace unicorn_net_tests.request
//{
//    [TestFixture]
//    class HttpRequestWithBodyTests
//    {
//        [Test]
//        public static void HttpRequestWithBody_Should_Construct_With_Get()
//        {
//            Action construct = () => new HttpRequestWithBody(HttpMethod.Get, "http://localhost");
//            construct.ShouldNotThrow();
//        }

//        [Test]
//        public static void HttpRequestWithBody_Should_Construct_With_Post()
//        {
//            Action construct = () => new HttpRequestWithBody(HttpMethod.Post, "http://localhost");
//            construct.ShouldNotThrow();
//        }

//        [Test]
//        public static void HttpRequestWithBody_Should_Construct_With_Delete()
//        {
//            Action construct = () => new HttpRequestWithBody(HttpMethod.Delete, "http://localhost");
//            construct.ShouldNotThrow();
//        }

//        [Test]
//        public static void HttpRequestWithBody_Should_Construct_With_Patch()
//        {
//            Action construct = () => new HttpRequestWithBody(new HttpMethod("PATCH"), "http://localhost");
//            construct.ShouldNotThrow();
//        }

//        [Test]
//        public static void HttpRequestWithBody_Should_Construct_With_Put()
//        {
//            Action construct = () => new HttpRequestWithBody(HttpMethod.Put, "http://localhost");
//            construct.ShouldNotThrow();
//        }

//        [Test]
//        public static void HttpRequestWithBody_Should_Not_Construct_With_Invalid_URL()
//        {
//            Action get = () => new HttpRequestWithBody(HttpMethod.Get, "http:///invalid");
//            Action Post = () => new HttpRequestWithBody(HttpMethod.Post, "http:///invalid");
//            Action delete = () => new HttpRequestWithBody(HttpMethod.Delete, "http:///invalid");
//            Action patch = () => new HttpRequestWithBody(new HttpMethod("PATCH"), "http:///invalid");
//            Action put = () => new HttpRequestWithBody(HttpMethod.Put, "http:///invalid");

//            get.ShouldThrow<ArgumentException>();
//            Post.ShouldThrow<ArgumentException>();
//            delete.ShouldThrow<ArgumentException>();
//            patch.ShouldThrow<ArgumentException>();
//            put.ShouldThrow<ArgumentException>();
//        }

//        [Test]
//        public static void HttpRequestWithBody_Should_Not_Construct_With_None_HTTP_URL()
//        {
//            Action get = () => new HttpRequestWithBody(HttpMethod.Get, "ftp://localhost");
//            Action Post = () => new HttpRequestWithBody(HttpMethod.Post, "mailto:localhost");
//            Action delete = () => new HttpRequestWithBody(HttpMethod.Delete, "news://localhost");
//            Action patch = () => new HttpRequestWithBody(new HttpMethod("PATCH"), "about:blank");
//            Action put = () => new HttpRequestWithBody(HttpMethod.Put, "about:settings");

//            get.ShouldThrow<ArgumentException>();
//            Post.ShouldThrow<ArgumentException>();
//            delete.ShouldThrow<ArgumentException>();
//            patch.ShouldThrow<ArgumentException>();
//            put.ShouldThrow<ArgumentException>();  
//        }
//    }
//}
