﻿// -------------------------------------------------------------------------------------------------
// <copyright file="AttributeValueRealTestFixture.cs" company="RHEA System S.A.">
//
//   Copyright 2017 RHEA System S.A.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace ReqIFLib.Tests
{
    using System;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Xml;

    using NUnit.Framework;
    using ReqIFSharp;

    /// <summary>
    /// Suite of tests for the <see cref="AttributeValueReal"/>
    /// </summary>
    [TestFixture]
    public class AttributeValueRealTestFixture
    {
        [Test]
        public void VerifyThatTheAttributeDefinitionCanBeSetOrGet()
        {
            var attributeDefinitionReal = new AttributeDefinitionReal();

            var attributeValueReal = new AttributeValueReal();
            attributeValueReal.Definition = attributeDefinitionReal;

            var attributeValue = (AttributeValue)attributeValueReal;

            Assert.AreEqual(attributeDefinitionReal, attributeValue.AttributeDefinition);

            attributeValue.AttributeDefinition = attributeDefinitionReal;

            Assert.AreEqual(attributeDefinitionReal, attributeValue.AttributeDefinition);
        }

        [Test]
        public void VerifyThatWriteXmlWithoutDefinitionSetThrowsSerializationException()
        {
            using (var writer = XmlWriter.Create("test.xml"))
            {
                var attributeValueReal = new AttributeValueReal();
                Assert.Throws<SerializationException>(() => attributeValueReal.WriteXml(writer));
            }
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void VerifytThatExceptionIsRaisedWhenInvalidAttributeDefinitionIsSet()
        {
            var attributeDefinitionString = new AttributeDefinitionString();
            var attributeValueReal = new AttributeValueReal();
            var attributeValue = (AttributeValue)attributeValueReal;

            attributeValue.AttributeDefinition = attributeDefinitionString;
        }
    }
}
