﻿using NUnit.Framework;
using Neo4jClient.Gremlin;

namespace Neo4jClient.Test.Gremlin
{
    [TestFixture]
    public class BackTests
    {
        [Test]
        public void BackVShouldAppendStep()
        {
            var query = new NodeReference(123).BackV<object>("foo");
            Assert.AreEqual("g.v(p0).back(p1)", query.QueryText);
            Assert.AreEqual(123, query.QueryParameters["p0"]);
            Assert.AreEqual("foo", query.QueryParameters["p1"]);
        }

        [Test]
        public void BackVShouldReturnTypedNodeEnumerable()
        {
            var query = new NodeReference(123).BackV<object>("foo");
            Assert.IsInstanceOf<GremlinNodeEnumerable<object>>(query);
        }

        [Test]
        public void BackEShouldAppendStep()
        {
            var query = new NodeReference(123).BackE("foo");
            Assert.AreEqual("g.v(p0).back(p1)", query.QueryText);
            Assert.AreEqual(123, query.QueryParameters["p0"]);
            Assert.AreEqual("foo", query.QueryParameters["p1"]);
        }

        [Test]
        public void BackEShouldReturnRelationshipEnumerable()
        {
            var query = new NodeReference(123).BackE("foo");
            Assert.IsInstanceOf<GremlinRelationshipEnumerable>(query);
        }

        [Test]
        public void BackEWithTDataShouldAppendStep()
        {
            var query = new NodeReference(123).BackE<object>("foo");
            Assert.AreEqual("g.v(p0).back(p1)", query.QueryText);
            Assert.AreEqual(123, query.QueryParameters["p0"]);
            Assert.AreEqual("foo", query.QueryParameters["p1"]);
        }

        [Test]
        public void BackEWithTDataShouldReturnRelationshipEnumerable()
        {
            var query = new NodeReference(123).BackE<object>("foo");
            Assert.IsInstanceOf<GremlinRelationshipEnumerable<object>>(query);
        }
    }
}
