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

namespace unicorn_net_tests.http
{
    [TestFixture]
    class UnicornTest
    {
        [Test]
        public static void Unicorn_Should_Return_Correct_Verb()
        {
            Unicorn.get("http://localhost").HttpMethod.Should().Be(HttpMethod.GET);
            Unicorn.post("http://localhost").HttpMethod.Should().Be(HttpMethod.POST);
            Unicorn.delete("http://localhost").HttpMethod.Should().Be(HttpMethod.DELETE);
            Unicorn.patch("http://localhost").HttpMethod.Should().Be(HttpMethod.PATCH);
            Unicorn.put("http://localhost").HttpMethod.Should().Be(HttpMethod.PUT);
        }

        [Test]
        public static void Unicorn_Should_Return_Correct_URL()
        {
            Unicorn.get("http://localhost").URL.OriginalString.Should().Be("http://localhost");
            Unicorn.post("http://localhost").URL.OriginalString.Should().Be("http://localhost");
            Unicorn.delete("http://localhost").URL.OriginalString.Should().Be("http://localhost");
            Unicorn.patch("http://localhost").URL.OriginalString.Should().Be("http://localhost");
            Unicorn.put("http://localhost").URL.OriginalString.Should().Be("http://localhost");
        }

        [Test]
        public static void Basic_Test()
        {
            
        }
    }
}
