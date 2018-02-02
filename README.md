# Huobi.Market.WebSocketAPI
### Useage:
```csharp
            var result = HuobiMarket.Init();
            var topic = string.Format(HuobiMarket.MARKET_KLINE, "etcbtc", "1day");
            var guid = Guid.NewGuid().ToString();
            HuobiMarket.Subscribe(topic, guid);
            HuobiMarket.OnMessage += (sender, e) =>
            {
                Console.WriteLine("OnMessage:" + e.Message);
            };
           
```

