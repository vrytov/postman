using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Postman.Models;

namespace Postman.Tests.Models
{
    [TestClass]
    public class MailkitMessageBuilderTest
    {
        public MailkitMessageBuilderTest()
        {
            
        }

        [TestMethod]
        public void TestBuildMessage()
        {
            var builder = new MailkitMessage.MessageBuilder();
            builder.AddFrom("name@example.com");
            builder.AddTo("to@example.com");
            builder.SetTextBody("TextBody");
            builder.SetHtmlBody("<p>HtmlBody</p>");
            var contentId = builder.AddResource("test.res");

            var result = builder.Result;
            Assert.AreEqual("name@example.com", result.From[0]);
            Assert.AreEqual("to@example.com", result.To[0]);
            Assert.AreEqual("TextBody", result.TextBody);
            Assert.AreEqual("<p>HtmlBody</p>", result.HtmlBody);
        }
    }
}
