using Microsoft.VisualStudio.TestTools.UnitTesting;
using Huobi.Market.WebSocketAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Huobi.Market.WebSocketAPI.Tests
{
    [TestClass()]
    public class HuoBiWebSocketAPITests
    {
        [TestMethod()]
        public void InitTest()
        {
            var result = HuobiMarket.Init();
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void AddSubscribeTest()
        {
            var result = HuobiMarket.Init();
            var topic = string.Format(HuobiMarket.MARKET_KLINE, "etcbtc", "1day");
            var guid = Guid.NewGuid().ToString();
            HuobiMarket.Subscribe(topic, guid);
            HuobiMarket.OnMessage += (sender, e) =>
            {
                Console.WriteLine("OnMessage:" + e.Message);
            };
            Thread.Sleep(1000 * 15);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void UnSubscribeTest()
        {
            var result = HuobiMarket.Init();
            var topic = string.Format(HuobiMarket.MARKET_KLINE, "etcbtc", "1day");
            var guid = Guid.NewGuid().ToString();
            HuobiMarket.Subscribe(topic, guid);
            HuobiMarket.OnMessage += (sender, e) =>
            {
                Console.WriteLine("OnMessage:" + e.Message);
                HuobiMarket.UnSubscribe(topic, guid);
            };
            Thread.Sleep(1000 * 15);
            Assert.IsTrue(result);
        }
    }
}